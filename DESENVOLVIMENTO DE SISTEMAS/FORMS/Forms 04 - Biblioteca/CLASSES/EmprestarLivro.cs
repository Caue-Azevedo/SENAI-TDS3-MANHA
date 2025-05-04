using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca_
{
    public partial class EmprestarLivro : UserControl
    {
        private Form1 formularioPrincipal;

        public EmprestarLivro(Form1 formPrincipal)
        {
            InitializeComponent();
            formularioPrincipal = formPrincipal;

            lblTituloEmprestar.Font = new Font("Arial", 12, FontStyle.Regular);
            lblLivro.Font = new Font("Arial", 9, FontStyle.Regular);
            lblUsuario.Font = new Font("Arial", 9, FontStyle.Regular);

            CarregarLivros();
        }

        private void CarregarLivros()
        {
            cmbLivros.Items.Clear();

            foreach (var livro in Form1.LivrosAdicionados)
            {
                cmbLivros.Items.Add(livro);
            }

            if (cmbLivros.Items.Count > 0)
            {
                cmbLivros.SelectedIndex = 0;
            }
        }

        public void AtualizarListaLivros()
        {
            CarregarLivros();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtUsuario.Clear();
            cmbLivros.SelectedIndex = -1;
        }

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLivros.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione um livro válido!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Nome do usuário é obrigatório!");
                    return;
                }

                Livro livroSelecionado = (Livro)cmbLivros.SelectedItem;

                Form1.LivrosAdicionados.Remove(livroSelecionado);

                AtualizarListaLivros();

                MessageBox.Show($"Livro '{livroSelecionado.Titulo}' emprestado com sucesso para o usuário '{txtUsuario.Text}'!");
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar emprestar o livro: {ex.Message}");
            }
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            formularioPrincipal.MostrarTelaInicial();
        }
    }
}
