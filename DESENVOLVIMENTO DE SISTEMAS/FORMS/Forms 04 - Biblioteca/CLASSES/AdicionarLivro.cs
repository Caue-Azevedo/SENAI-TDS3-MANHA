using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca_
{
    public partial class AdicionarLivro : UserControl
    {
        private Form1 formularioPrincipal;

        public AdicionarLivro(Form1 formPrincipal)
        {
            InitializeComponent();
            formularioPrincipal = formPrincipal;

            lblTituloAdicionar.Font = new Font("Arial", 12, FontStyle.Regular);
            lblAno.Font = new Font("Arial", 9, FontStyle.Regular);
            lblAutor.Font = new Font("Arial", 9, FontStyle.Regular);
            lblGenero.Font = new Font("Arial", 9, FontStyle.Regular);
            lblTitulo.Font = new Font("Arial", 9, FontStyle.Regular);
            btnLimpar.Font = new Font("Arial", 8, FontStyle.Regular);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtAno.Clear();
            txtAutor.Clear();
            txtTitulo.Clear();
            cmbGenero.SelectedIndex = -1;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                    MessageBox.Show("Título é obrigatório!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAutor.Text))
                {
                    MessageBox.Show("Autor é obrigatório!");
                    return;
                }

                if (!int.TryParse(txtAno.Text, out int ano))
                {
                    MessageBox.Show("Ano inválido! Digite um número.");
                    return;
                }

                if (cmbGenero.SelectedIndex == -1)
                {
                    MessageBox.Show("Gênero é obrigatório!");
                    return;
                }

                string generoSelecionado = cmbGenero.SelectedItem.ToString();

                Livro livro = new Livro(txtTitulo.Text, txtAutor.Text, ano, generoSelecionado);

                Form1.LivrosAdicionados.Add(livro);

                MessageBox.Show("Livro adicionado com sucesso!");
                LimparFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            formularioPrincipal.MostrarTelaInicial();
        }
    }
}
