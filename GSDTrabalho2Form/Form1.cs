using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace VerificarRedeSegura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnVerificar_Click(object sender, EventArgs e)
        {
            lstResultado.Items.Clear();

            bool camada1 = false;
            bool camada2 = false;
            bool camada3 = false;
           
            // Camada 1: Interface de rede ativa
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                lstResultado.Items.Add("✅ Camada 1: Interface de rede ativa");
                camada1 = true;
            }
            else
            {
                lstResultado.Items.Add("❌ Camada 1: Nenhuma interface de rede ativa");
            }

            // Camada 2: Conectividade com gateway
            // Camada 3: DNS e ping externo
            try
            {
                using (Ping ping = new Ping())
                {
                    var reply = ping.Send("www.google.com", 1000);
                    if (reply.Status == IPStatus.Success)
                    {
                        lstResultado.Items.Add("✅ Camada 2: DNS e ping ao Google OK");
                        camada2 = true;
                    }
                    else
                    {
                        lstResultado.Items.Add("❌ Camada 2: Ping ao Google falhou");
                    }
                }
            }
            catch
            {
                lstResultado.Items.Add("❌ Camada 2: Erro ao resolver DNS/ping");
            }

            // Camada 4: HTTP/HTTPS
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(3);
                    var response = await client.GetAsync("https://www.google.com");
                    if (response.IsSuccessStatusCode)
                    {
                        lstResultado.Items.Add("✅ Camada 3: Acesso HTTPS bem-sucedido");
                        camada3 = true;
                    }
                    else
                    {
                        lstResultado.Items.Add("❌ Camada 3: Acesso HTTPS falhou (status != 200)");
                    }
                }
            }
            catch
            {
                lstResultado.Items.Add("❌ Camada 3: Exceção ao tentar HTTP/HTTPS");
            }

            // Camada 5: Conclusão com if
            if (camada1 && camada2 && camada3)
            {
                lstResultado.Items.Add("");
                lstResultado.Items.Add("✅ Camada 4: Conexão totalmente funcional!");
            }
            else
            {
                lstResultado.Items.Add("");
                lstResultado.Items.Add("❌ Camada 4: Conexão incompleta. Alguma verificação falhou.");
            }
        }
    }
}