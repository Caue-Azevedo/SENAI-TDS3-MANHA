using System;
using System.Drawing;
using System.Windows.Forms;

namespace Agendamento_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblData.Font = new Font("Arial", 9, FontStyle.Regular);
            lblDescricao.Font = new Font("Arial", 9, FontStyle.Regular);
            lblHora.Font = new Font("Arial", 9, FontStyle.Regular);
            lblNome.Font = new Font("Arial", 9, FontStyle.Regular);
            lblLista.Font = new Font("Arial", 9, FontStyle.Regular);
            btnAgendar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnLimpar.Font = new Font("Arial", 8, FontStyle.Regular);
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Nome é obrigatório!");
                return;
            }

            if (!DateTime.TryParseExact(txtData.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                MessageBox.Show("Data inválida! Use o formato dd/MM/yyyy.");
                return;
            }

            if (!TimeSpan.TryParseExact(txtHora.Text, "hh\\:mm", null, out TimeSpan hora))
            {
                MessageBox.Show("Hora inválida! Use o formato HH:mm.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Descrição é obrigatória!");
                return;
            }

            Agendamento agendamento = new Agendamento(txtNome.Text, data, hora, txtDescricao.Text);
            lstAgendamentos.Items.Add(agendamento.ToString());
            LimparFormulario();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtNome.Clear();
            txtData.Clear();
            txtHora.Clear();
            txtDescricao.Clear();
        }
    }
    public class Agendamento
    {
        public string Nome { get; private set; }
        public DateTime DataHora { get; private set; }
        public string Descricao { get; private set; }

        public Agendamento(string nome, DateTime data, TimeSpan hora, string descricao)
        {
            Nome = nome;
            DataHora = data.Date + hora;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"{Nome} - {DataHora:dd/MM/yyyy HH:mm} - {Descricao}";
        }
    }
}
