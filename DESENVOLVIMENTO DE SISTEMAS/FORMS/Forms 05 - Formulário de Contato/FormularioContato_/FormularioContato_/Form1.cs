using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormularioContato_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            lblAssunto.Font = new Font("Arial", 9, FontStyle.Regular);
            lblEmail.Font = new Font("Arial", 9, FontStyle.Regular);
            lblMensagem.Font = new Font("Arial", 9, FontStyle.Regular);
            lblNome.Font = new Font("Arial", 9, FontStyle.Regular);
            lblTelefone.Font = new Font("Arial", 9, FontStyle.Regular);
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Regular);
            chkNewsLetter.Font = new Font("Arial", 9, FontStyle.Regular);
            btnEnviar.Font = new Font("Arial", 10, FontStyle.Regular);
            btnLimpar.Font = new Font("Arial", 10, FontStyle.Regular);

            cmbAssunto.Items.Add("Dúvida");
            cmbAssunto.Items.Add("Reclamação");
            cmbAssunto.Items.Add("Sugestão");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Contato contato = new Contato
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text,
                    Assunto = cmbAssunto.Text,
                    Mensagem = txtMensagem.Text,
                    ReceberNews = chkNewsLetter.Checked
                };

                if (!contato.Validar(out string erro))
                {
                    MessageBox.Show(erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(contato.ToString(), "Mensagem Enviada");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtMensagem.Clear();
            cmbAssunto.SelectedIndex = -1;
            chkNewsLetter.Checked = false;
        }
    }
}
