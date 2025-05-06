namespace JogoForca_
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
            this.btnTentarLetra = new System.Windows.Forms.Button();
            this.pnlPersonagem = new System.Windows.Forms.Panel();
            this.btnNovoJogo = new System.Windows.Forms.Button();
            this.lstLetrasTentadas = new System.Windows.Forms.ListBox();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.lblPalavraOculta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTentarLetra
            // 
            this.btnTentarLetra.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnTentarLetra.Location = new System.Drawing.Point(232, 312);
            this.btnTentarLetra.Name = "btnTentarLetra";
            this.btnTentarLetra.Size = new System.Drawing.Size(174, 58);
            this.btnTentarLetra.TabIndex = 0;
            this.btnTentarLetra.Text = "Tentar Letra";
            this.btnTentarLetra.UseVisualStyleBackColor = false;
            this.btnTentarLetra.Click += new System.EventHandler(this.btnTentarLetra_Click);
            // 
            // pnlPersonagem
            // 
            this.pnlPersonagem.Location = new System.Drawing.Point(41, 24);
            this.pnlPersonagem.Name = "pnlPersonagem";
            this.pnlPersonagem.Size = new System.Drawing.Size(199, 210);
            this.pnlPersonagem.TabIndex = 1;
            this.pnlPersonagem.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPersonagem_Paint);
            // 
            // btnNovoJogo
            // 
            this.btnNovoJogo.BackColor = System.Drawing.Color.Wheat;
            this.btnNovoJogo.Location = new System.Drawing.Point(559, 320);
            this.btnNovoJogo.Name = "btnNovoJogo";
            this.btnNovoJogo.Size = new System.Drawing.Size(210, 50);
            this.btnNovoJogo.TabIndex = 2;
            this.btnNovoJogo.Text = "Novo Jogo";
            this.btnNovoJogo.UseVisualStyleBackColor = false;
            this.btnNovoJogo.Click += new System.EventHandler(this.btnNovoJogo_Click);
            // 
            // lstLetrasTentadas
            // 
            this.lstLetrasTentadas.FormattingEnabled = true;
            this.lstLetrasTentadas.ItemHeight = 20;
            this.lstLetrasTentadas.Location = new System.Drawing.Point(748, 12);
            this.lstLetrasTentadas.Name = "lstLetrasTentadas";
            this.lstLetrasTentadas.Size = new System.Drawing.Size(40, 284);
            this.lstLetrasTentadas.TabIndex = 3;
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(271, 280);
            this.txtEntrada.MaxLength = 1;
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(100, 26);
            this.txtEntrada.TabIndex = 4;
            // 
            // lblPalavraOculta
            // 
            this.lblPalavraOculta.AutoSize = true;
            this.lblPalavraOculta.Location = new System.Drawing.Point(281, 214);
            this.lblPalavraOculta.Name = "lblPalavraOculta";
            this.lblPalavraOculta.Size = new System.Drawing.Size(111, 20);
            this.lblPalavraOculta.TabIndex = 5;
            this.lblPalavraOculta.Text = "Palavra Oculta";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPalavraOculta);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.lstLetrasTentadas);
            this.Controls.Add(this.btnNovoJogo);
            this.Controls.Add(this.pnlPersonagem);
            this.Controls.Add(this.btnTentarLetra);
            this.Name = "Form1";
            this.Text = "Jogo da Forca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTentarLetra;
        private System.Windows.Forms.Panel pnlPersonagem;
        private System.Windows.Forms.Button btnNovoJogo;
        private System.Windows.Forms.ListBox lstLetrasTentadas;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Label lblPalavraOculta;
    }
}

