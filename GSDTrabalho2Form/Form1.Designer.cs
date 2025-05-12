namespace VerificarRedeSegura
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVerificar = new System.Windows.Forms.Button();
            this.lstResultado = new System.Windows.Forms.ListBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblStatusConexao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(245, 60);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(185, 30);
            this.btnVerificar.TabIndex = 0;
            this.btnVerificar.Text = "Verificar Rede";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // lstResultado
            // 
            this.lstResultado.FormattingEnabled = true;
            this.lstResultado.Location = new System.Drawing.Point(30, 96);
            this.lstResultado.Name = "lstResultado";
            this.lstResultado.Size = new System.Drawing.Size(400, 121);
            this.lstResultado.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(246, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(184, 30);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar Verificação";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblStatusConexao
            // 
            this.lblStatusConexao.AutoSize = true;
            this.lblStatusConexao.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatusConexao.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatusConexao.Location = new System.Drawing.Point(266, 29);
            this.lblStatusConexao.Name = "lblStatusConexao";
            this.lblStatusConexao.Size = new System.Drawing.Size(10, 13);
            this.lblStatusConexao.TabIndex = 3;
            this.lblStatusConexao.Text = ".";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(480, 250);
            this.Controls.Add(this.lblStatusConexao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lstResultado);
            this.Controls.Add(this.btnVerificar);
            this.Name = "Form1";
            this.Text = "Verificação Segura de Rede";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.ListBox lstResultado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblStatusConexao;
    }
}

