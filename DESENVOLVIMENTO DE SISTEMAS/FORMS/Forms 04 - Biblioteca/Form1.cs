using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca_
{
    public partial class Form1 : Form
    {
        public static List<Livro> LivrosAdicionados = new List<Livro>();

        public Form1()
        {
            InitializeComponent();

            lblInicial.Font = new Font("Arial", 12, FontStyle.Regular);
            btnAdicionarLivro.Font = new Font("Arial", 12, FontStyle.Regular);
            btnEmprestarLivro.Font = new Font("Arial", 12, FontStyle.Regular);
        }

        private void btnAdicionarLivro_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            AdicionarLivro adicionarLivro = new AdicionarLivro(this);
            adicionarLivro.Dock = DockStyle.Fill;

            this.Controls.Add(adicionarLivro);
        }

        private void btnEmprestarLivro_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            EmprestarLivro emprestarLivro = new EmprestarLivro(this);
            emprestarLivro.Dock = DockStyle.Fill;

            this.Controls.Add(emprestarLivro);
            emprestarLivro.AtualizarListaLivros();
        }

        public void MostrarTelaInicial()
        {
            this.Controls.Clear();

            InitializeComponent();

            lblInicial.Font = new Font("Arial", 12, FontStyle.Regular);
            btnAdicionarLivro.Font = new Font("Arial", 12, FontStyle.Regular);
            btnEmprestarLivro.Font = new Font("Arial", 12, FontStyle.Regular);
        }
    }
}
