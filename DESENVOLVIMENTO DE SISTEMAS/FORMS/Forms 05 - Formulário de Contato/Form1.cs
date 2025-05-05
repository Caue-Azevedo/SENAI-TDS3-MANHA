using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string telefone = txtTelefone.Text;
                string assunto = cmbAssunto.Text;
                string mensagem = txtMensagem.Text;
                bool receberNews = chkNewsLetter.Checked;

                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Nome é obrigatório!");
                    return;
                }

                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(email, emailPattern))
                {
                    MessageBox.Show("Por favor, insira um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string telefonePattern = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";
                if (!Regex.IsMatch(telefone, telefonePattern))
                {
                    MessageBox.Show("Por favor, insira um número de telefone válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbAssunto.SelectedIndex == -1)
                {
                    MessageBox.Show("Assunto é obrigatório!");
                    return;
                }

                if (string.IsNullOrEmpty(txtMensagem.Text))
                {
                    MessageBox.Show("Mensagem é obrigatória!");
                    return;
                }



                string mensagemEnviada = $"   Nome: {nome}\n   Email: {email}\n   Telefone: {telefone}\n   Assunto: {assunto}\n   Mensagem: {mensagem}\n   Receber NewsLetter: {(receberNews ? "Sim" : "Não")}";
                MessageBox.Show(mensagemEnviada, "Mensagem Enviada");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtEmail.Clear();
            txtMensagem.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            cmbAssunto.SelectedIndex = -1;
        }
    }
}
