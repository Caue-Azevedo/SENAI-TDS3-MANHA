namespace Biblioteca_
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
            this.lblInicial = new System.Windows.Forms.Label();
            this.btnAdicionarLivro = new System.Windows.Forms.Button();
            this.btnEmprestarLivro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInicial
            // 
            this.lblInicial.AutoSize = true;
            this.lblInicial.BackColor = System.Drawing.Color.Pink;
            this.lblInicial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInicial.Location = new System.Drawing.Point(132, 38);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(317, 22);
            this.lblInicial.TabIndex = 0;
            this.lblInicial.Text = "Seja bem-vindo(a) ao sistema de biblioteca!";
            // 
            // btnAdicionarLivro
            // 
            this.btnAdicionarLivro.BackColor = System.Drawing.SystemColors.Info;
            this.btnAdicionarLivro.Location = new System.Drawing.Point(46, 145);
            this.btnAdicionarLivro.Name = "btnAdicionarLivro";
            this.btnAdicionarLivro.Size = new System.Drawing.Size(246, 99);
            this.btnAdicionarLivro.TabIndex = 1;
            this.btnAdicionarLivro.Text = "Adicionar um livro";
            this.btnAdicionarLivro.UseVisualStyleBackColor = false;
            this.btnAdicionarLivro.Click += new System.EventHandler(this.btnAdicionarLivro_Click);
            // 
            // btnEmprestarLivro
            // 
            this.btnEmprestarLivro.BackColor = System.Drawing.SystemColors.Info;
            this.btnEmprestarLivro.Location = new System.Drawing.Point(387, 145);
            this.btnEmprestarLivro.Name = "btnEmprestarLivro";
            this.btnEmprestarLivro.Size = new System.Drawing.Size(252, 99);
            this.btnEmprestarLivro.TabIndex = 2;
            this.btnEmprestarLivro.Text = "Emprestar um livro";
            this.btnEmprestarLivro.UseVisualStyleBackColor = false;
            this.btnEmprestarLivro.Click += new System.EventHandler(this.btnEmprestarLivro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.btnEmprestarLivro);
            this.Controls.Add(this.btnAdicionarLivro);
            this.Controls.Add(this.lblInicial);
            this.Name = "Form1";
            this.Text = "Biblioteca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.Button btnAdicionarLivro;
        private System.Windows.Forms.Button btnEmprestarLivro;
    }
}

