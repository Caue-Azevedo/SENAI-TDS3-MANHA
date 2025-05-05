namespace Biblioteca_
{
    partial class CadastroLivro
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
            this.lblOpcaoAdicionar = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOpcaoAdicionar
            // 
            this.lblOpcaoAdicionar.AutoSize = true;
            this.lblOpcaoAdicionar.BackColor = System.Drawing.Color.Pink;
            this.lblOpcaoAdicionar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOpcaoAdicionar.Location = new System.Drawing.Point(143, 42);
            this.lblOpcaoAdicionar.Name = "lblOpcaoAdicionar";
            this.lblOpcaoAdicionar.Size = new System.Drawing.Size(264, 22);
            this.lblOpcaoAdicionar.TabIndex = 4;
            this.lblOpcaoAdicionar.Text = "Opção escolhida: Adicionar um livro.";
            this.lblOpcaoAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(201, 153);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(158, 35);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "Limpar Formulário";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // CadastroLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lblOpcaoAdicionar);
            this.Name = "CadastroLivro";
            this.Size = new System.Drawing.Size(561, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOpcaoAdicionar;
        private System.Windows.Forms.Button btnLimpar;
    }
}
