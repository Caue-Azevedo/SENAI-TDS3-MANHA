using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class SelecionarLinhaParaRastreamento : UserControl
    {
        #region campos

        private readonly Form1 formularioPrincipal;
        private ComboBox cmbLinhas;
        private Button btnConfirmar;
        private Button btnVoltar;
        private Label lblTitulo;

        #endregion

        #region construtor

        public SelecionarLinhaParaRastreamento(Form1 formPrincipal)
        {
            formularioPrincipal = formPrincipal;
            InicializarComponentes();
            CarregarLinhasDoBanco();
        }

        #endregion

        #region interface visual

        private void InicializarComponentes()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.MediumTurquoise;

            Panel panelPrincipal = new Panel
            {
                BackColor = Color.LightCyan,
                Size = new Size(520, 300),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(panelPrincipal);

            lblTitulo = new Label
            {
                Text = "Selecione a linha para rastreamento",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            cmbLinhas = new ComboBox
            {
                Width = 360,
                Font = new Font("Segoe UI", 12),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            btnConfirmar = CriarBotao("Confirmar", Color.MediumSeaGreen);
            btnConfirmar.Click += BtnConfirmar_Click;

            btnVoltar = CriarBotao("Voltar", Color.LightGray);
            btnVoltar.Click += (s, e) => formularioPrincipal.TrocarControle(new MenuInicial(formularioPrincipal, "usuário"));

            panelPrincipal.Location = new Point((this.Width - panelPrincipal.Width) / 2, (this.Height - panelPrincipal.Height) / 2);
            panelPrincipal.Anchor = AnchorStyles.None;

            int centerX = (panelPrincipal.Width - cmbLinhas.Width) / 2;
            int posY = 30;

            lblTitulo.Location = new Point((panelPrincipal.Width - lblTitulo.PreferredWidth) / 2, posY);
            posY += 60;

            cmbLinhas.Location = new Point(centerX, posY);
            posY += 60;

            btnConfirmar.Location = new Point(centerX, posY);
            btnVoltar.Location = new Point(centerX + btnConfirmar.Width + 20, posY);

            panelPrincipal.Controls.AddRange(new Control[] {
                lblTitulo, cmbLinhas, btnConfirmar, btnVoltar
            });
        }

        private Button CriarBotao(string texto, Color cor, int largura = 130, int altura = 40)
        {
            return new Button
            {
                Text = texto,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(largura, altura),
                BackColor = cor,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.FromArgb(70, cor),
                    MouseDownBackColor = Color.FromArgb(100, cor)
                }
            };
        }

        #endregion

        #region lógica do sistema

        private void CarregarLinhasDoBanco()
        {
            try
            {
                string conexaoString = "server=localhost;database=transporte_curitiba;uid=root;pwd=;";
                using (MySqlConnection conexao = new MySqlConnection(conexaoString))
                {
                    conexao.Open();
                    string query = "SELECT codigo_linha, nome_linha FROM linhas_onibus ORDER BY nome_linha";
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string codigo = reader["codigo_linha"].ToString();
                                string nome = reader["nome_linha"].ToString();
                                cmbLinhas.Items.Add($"{codigo} - {nome}");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show($"Erro ao acessar o banco de dados: {mysqlEx.Message}", "Erro de banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado ao carregar linhas do banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbLinhas.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma linha", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string linhaSelecionada = cmbLinhas.SelectedItem.ToString();
            string codigoLinha = linhaSelecionada.Split('-')[0].Trim();

            formularioPrincipal.TrocarControle(new Rastreamento(formularioPrincipal, codigoLinha));
        }

        #endregion
    }
}
