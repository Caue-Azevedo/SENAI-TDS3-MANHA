using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculadora_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnSomar.Text = "+";
            btnSomar.Font = new Font("Arial", 12, FontStyle.Bold);
            btnSomar.Size = new Size(50, 50);

            btnSubtrair.Text = "-";
            btnSubtrair.Font = new Font("Arial", 12, FontStyle.Bold);
            btnSubtrair.Size = new Size(50, 50);

            btnMultiplicar.Text = "*";
            btnMultiplicar.Font = new Font("Arial", 12, FontStyle.Bold);
            btnMultiplicar.Size = new Size(50, 50);

            btnDividir.Text = "/";
            btnDividir.Font = new Font("Arial", 12, FontStyle.Bold);
            btnDividir.Size = new Size(50, 50);
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtNum1.Text, out double num1) &&
                    double.TryParse(txtNum2.Text, out double num2))
                {
                    double resultado = num1 + num2;
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtNum1.Text, out double num1) &&
                    double.TryParse(txtNum2.Text, out double num2))
                {
                    double resultado = num1 - num2;
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtNum1.Text, out double num1) &&
                    double.TryParse(txtNum2.Text, out double num2))
                {
                    double resultado = num1 * num2;
                    lblResultado.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtNum1.Text, out double num1) &&
                    double.TryParse(txtNum2.Text, out double num2))
                {
                    if (num2 == 0)
                    {
                        MessageBox.Show("Erro: Não é possível dividir por zero.");
                    }
                    else
                    {
                        double resultado = num1 / num2;
                        lblResultado.Text = resultado.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, insira números válidos!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
