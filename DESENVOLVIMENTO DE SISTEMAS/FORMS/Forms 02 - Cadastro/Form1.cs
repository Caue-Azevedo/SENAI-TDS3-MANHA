using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cadastro_
{
    public partial class Form1 : Form
    {
        private string nome;
        private string email;
        private bool ativo;
        private string sexo;
        private string cidade;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public Form1()
        {
            InitializeComponent();
            lblNome.Font = new Font("Arial", 12, FontStyle.Bold);
            lblEmail.Font = new Font("Arial", 12, FontStyle.Bold);
            lblAtivo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblSexo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblCidade.Font = new Font("Arial", 12, FontStyle.Bold);
            btnCadastrar.Font = new Font("Arial", 12, FontStyle.Bold);
            btnCadastrar.Size = new Size(160, 40);
            chkAtivo.Font = new Font("Arial", 12, FontStyle.Bold);
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxSexo.Items.Add("Masculino");
            comboBoxSexo.Items.Add("Feminino");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Nome = txtNome.Text;
            Email = txtEmail.Text;
            Ativo = chkAtivo.Checked;
            Sexo = comboBoxSexo.Text;
            Cidade = txtCidade.Text;

            if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Sexo) || string.IsNullOrEmpty(Cidade))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(Email, emailPattern))
            {
                MessageBox.Show("Por favor, insira um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensagem = $"Nome: {Nome}\nEmail: {Email}\nAtivo: {(Ativo ? "Sim" : "Não")}\nSexo: {Sexo}\nCidade: {Cidade}";
            MessageBox.Show(mensagem, "Dados Cadastrados");
        }
    }
}
