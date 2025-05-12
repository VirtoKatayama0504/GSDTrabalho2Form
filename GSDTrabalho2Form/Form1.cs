using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerificarRedeSegura
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private readonly string[] sitesParaMonitorar =
        {
            "www.google.com",
            "www.microsoft.com",
            "www.github.com",
            "www.cloudflare.com",
            "www.uol.com.br"
        };

        public Form1()
        {
            InitializeComponent();
            lblStatusConexao = new Label();
            lblStatusConexao.AutoSize = true;
            lblStatusConexao.Location = new System.Drawing.Point(10, 10); // Posição do label
            lblStatusConexao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblStatusConexao.Text = "Status: aguardando...";
            lblStatusConexao.ForeColor = System.Drawing.Color.Gray;
            Controls.Add(lblStatusConexao);
        }

        private async void btnVerificar_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            btnVerificar.Enabled = false;
            btnCancelar.Enabled = true;
            lstResultado.Items.Clear();

            // Camada 1: Verifica se há rede
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                lstResultado.Items.Add("✅ Camada 1: Interface de rede ativa");
            }
            else
            {
                lstResultado.Items.Add("❌ Camada 1: Nenhuma interface de rede ativa");
                return;
            }

            // Camada 3: Teste HTTP/HTTPS simples
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(3);
                    var response = await client.GetAsync("https://www.google.com", token);
                    if (response.IsSuccessStatusCode)
                    {
                        lstResultado.Items.Add("✅ Camada 3: Acesso HTTPS bem-sucedido");
                    }
                    else
                    {
                        lstResultado.Items.Add("❌ Camada 3: Acesso HTTPS falhou");
                    }
                }
            }
            catch (Exception ex)
            {
                lstResultado.Items.Add("❌ Camada 3: Erro ao acessar HTTPS - " + ex.Message);
            }

            lstResultado.Items.Add("📡 Iniciando monitoramento contínuo de ping para múltiplos sites...");

            // Iniciar o monitoramento da conexão
            await MonitorarConexao(token); // Chama o método MonitorarConexao para começar a monitorar
        }

        private async Task MonitorarConexao(CancellationToken token)
        {
            bool algumPingOk = false;

            while (!token.IsCancellationRequested)
            {
                algumPingOk = false; // Reseta a flag a cada nova rodada de ping

                foreach (string site in sitesParaMonitorar)
                {
                    try
                    {
                        using (Ping ping = new Ping())
                        {
                            var reply = await ping.SendPingAsync(site, 1000);
                            if (reply.Status == IPStatus.Success)
                            {
                                lstResultado.Items.Add($"✅ {site}: {reply.RoundtripTime} ms - {DateTime.Now:T}");
                                algumPingOk = true;
                            }
                            else
                            {
                                lstResultado.Items.Add($"❌ {site}: Falhou ({reply.Status}) - {DateTime.Now:T}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lstResultado.Items.Add($"❌ {site}: Erro - {ex.Message} - {DateTime.Now:T}");
                    }
                }

                // Atualiza o status da conexão
                if (algumPingOk)
                {
                    lblStatusConexao.Text = "🟢 Conexão ativa";
                    lblStatusConexao.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblStatusConexao.Text = "🔴 Sem conexão";
                    lblStatusConexao.ForeColor = System.Drawing.Color.Red;
                }

                // Limita a lista de resultados para 100 itens
                while (lstResultado.Items.Count > 100)
                {
                    lstResultado.Items.RemoveAt(0);
                }

                // Aguardar 5 segundos antes de repetir
                await Task.Delay(5000, token);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lstResultado.Items.Add("⛔ Cancelando monitoramento...");
            cancellationTokenSource?.Cancel(); // Cancela a tarefa de monitoramento

            btnVerificar.Enabled = true;
            btnCancelar.Enabled = false;
        }
    }
}