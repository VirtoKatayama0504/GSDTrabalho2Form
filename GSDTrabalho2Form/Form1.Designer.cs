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
            this.SuspendLayout();
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(30, 20);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(200, 30);
            this.btnVerificar.TabIndex = 0;
            this.btnVerificar.Text = "Verificar Rede";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // lstResultado
            // 
            this.lstResultado.FormattingEnabled = true;
            this.lstResultado.Location = new System.Drawing.Point(30, 70);
            this.lstResultado.Name = "lstResultado";
            this.lstResultado.Size = new System.Drawing.Size(400, 150);
            this.lstResultado.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(480, 250);
            this.Controls.Add(this.lstResultado);
            this.Controls.Add(this.btnVerificar);
            this.Name = "Form1";
            this.Text = "Verificação Segura de Rede";
            this.ResumeLayout(false);
        

        }

        #endregion

        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.ListBox lstResultado;
    }
}

