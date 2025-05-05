namespace Biblioteca_
{
    partial class EmprestarLivro
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTituloEmprestar = new System.Windows.Forms.Label();
            this.lblLivro = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbLivros = new System.Windows.Forms.ComboBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnEmprestar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloEmprestar
            // 
            this.lblTituloEmprestar.AutoSize = true;
            this.lblTituloEmprestar.BackColor = System.Drawing.Color.Pink;
            this.lblTituloEmprestar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTituloEmprestar.Location = new System.Drawing.Point(174, 53);
            this.lblTituloEmprestar.Name = "lblTituloEmprestar";
            this.lblTituloEmprestar.Size = new System.Drawing.Size(272, 22);
            this.lblTituloEmprestar.TabIndex = 12;
            this.lblTituloEmprestar.Text = "Opção escolhida: Emprestar um livro.";
            this.lblTituloEmprestar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblLivro
            // 
            this.lblLivro.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblLivro.Location = new System.Drawing.Point(77, 172);
            this.lblLivro.Name = "lblLivro";
            this.lblLivro.Size = new System.Drawing.Size(92, 28);
            this.lblLivro.TabIndex = 18;
            this.lblLivro.Text = "Livro:";
            this.lblLivro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(187, 105);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(420, 26);
            this.txtUsuario.TabIndex = 21;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblUsuario.Location = new System.Drawing.Point(77, 105);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(92, 26);
            this.lblUsuario.TabIndex = 20;
            this.lblUsuario.Text = "Usuário:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbLivros
            // 
            this.cmbLivros.FormattingEnabled = true;
            this.cmbLivros.Location = new System.Drawing.Point(187, 172);
            this.cmbLivros.Name = "cmbLivros";
            this.cmbLivros.Size = new System.Drawing.Size(420, 28);
            this.cmbLivros.TabIndex = 22;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnVoltar.Location = new System.Drawing.Point(28, 21);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(97, 43);
            this.btnVoltar.TabIndex = 24;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click_1);
            // 
            // btnEmprestar
            // 
            this.btnEmprestar.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnEmprestar.Location = new System.Drawing.Point(241, 253);
            this.btnEmprestar.Name = "btnEmprestar";
            this.btnEmprestar.Size = new System.Drawing.Size(152, 35);
            this.btnEmprestar.TabIndex = 25;
            this.btnEmprestar.Text = "EMPRESTAR";
            this.btnEmprestar.UseVisualStyleBackColor = false;
            this.btnEmprestar.Click += new System.EventHandler(this.btnEmprestar_Click);
            // 
            // EmprestarLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEmprestar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.cmbLivros);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblLivro);
            this.Controls.Add(this.lblTituloEmprestar);
            this.Name = "EmprestarLivro";
            this.Size = new System.Drawing.Size(627, 381);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloEmprestar;
        private System.Windows.Forms.Label lblLivro;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbLivros;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnEmprestar;
    }
}
