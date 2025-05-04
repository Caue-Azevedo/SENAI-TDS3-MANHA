namespace Biblioteca_
{
    partial class AdicionarLivro
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
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblTituloAdicionar = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(26, 338);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(158, 35);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar Formulário";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblTituloAdicionar
            // 
            this.lblTituloAdicionar.AutoSize = true;
            this.lblTituloAdicionar.BackColor = System.Drawing.Color.Pink;
            this.lblTituloAdicionar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTituloAdicionar.Location = new System.Drawing.Point(186, 58);
            this.lblTituloAdicionar.Name = "lblTituloAdicionar";
            this.lblTituloAdicionar.Size = new System.Drawing.Size(264, 22);
            this.lblTituloAdicionar.TabIndex = 11;
            this.lblTituloAdicionar.Text = "Opção escolhida: Adicionar um livro.";
            this.lblTituloAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(161, 221);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(155, 26);
            this.txtAno.TabIndex = 19;
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(161, 168);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(155, 26);
            this.txtAutor.TabIndex = 18;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(161, 116);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(155, 26);
            this.txtTitulo.TabIndex = 17;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblGenero.Location = new System.Drawing.Point(76, 268);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(67, 20);
            this.lblGenero.TabIndex = 16;
            this.lblGenero.Text = "Gênero:";
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblAno.Location = new System.Drawing.Point(101, 221);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(42, 20);
            this.lblAno.TabIndex = 15;
            this.lblAno.Text = "Ano:";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblAutor.Location = new System.Drawing.Point(91, 171);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(52, 20);
            this.lblAutor.TabIndex = 14;
            this.lblAutor.Text = "Autor:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblTitulo.Location = new System.Drawing.Point(79, 122);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(64, 20);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "Título:";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnAdicionar.Location = new System.Drawing.Point(208, 338);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(152, 35);
            this.btnAdicionar.TabIndex = 21;
            this.btnAdicionar.Text = "ADICIONAR";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Ação",
            "Aventura",
            "Cinema de arte",
            "Chanchada",
            "Comédia",
            "Comédia de ação",
            "Comédia de terror",
            "Comédia dramática",
            "Comédia romântica",
            "Dança",
            "Documentário",
            "Docuficção",
            "Drama",
            "Espionagem",
            "Faroeste",
            "Fantasia",
            "Fantasia científica",
            "Ficção científica",
            "Filme épico",
            "Filmes com truques",
            "Filmes de guerra",
            "Filme policial",
            "Mistério",
            "Musical",
            "Romance",
            "Terror",
            "Thriller"});
            this.cmbGenero.Location = new System.Drawing.Point(161, 268);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(155, 28);
            this.cmbGenero.TabIndex = 22;
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnVoltar.Location = new System.Drawing.Point(26, 25);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(97, 43);
            this.btnVoltar.TabIndex = 23;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // AdicionarLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lblTituloAdicionar);
            this.Name = "AdicionarLivro";
            this.Size = new System.Drawing.Size(614, 420);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblTituloAdicionar;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Button btnVoltar;
    }
}
