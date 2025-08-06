using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class Rastreamento : UserControl
    {
        #region campos
        private readonly Form1 formularioPrincipal; // referência ao formulário principal //
        private readonly string codigoLinha; // código da linha de ônibus a ser rastreada //
        private readonly string nomeLinha; // nome da linha associado ao código //
        private Label lblTitulo, lblStatus; // rótulos de título e status //
        private ListBox lstVeiculos; // lista que exibe os veículos encontrados //
        private Button btnAtualizar, btnVoltar; // botões de ação da interface //
        private readonly string connectionString = "server=localhost;database=transporte_curitiba;uid=root;pwd=;"; // string de conexão com o banco de dados //
        private JArray veiculos; // array que armazena os veículos retornados pela api //
        private Button btnVerInfo; // botão que exibe informações detalhadas da linha //
        #endregion

        #region construtor
        public Rastreamento(Form1 form, string codigo, string nomeLinha = null)
        {
            formularioPrincipal = form;
            codigoLinha = codigo;
            this.nomeLinha = nomeLinha ?? ObterNomeLinha(codigo); // se o nome não for passado, obtém pelo banco //

            InicializarComponentes();
            _ = CarregarVeiculos(); // inicia o carregamento dos veículos //
        }
        #endregion

        #region método para obter nome da linha
        private string ObterNomeLinha(string codigo)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT nome_linha FROM linhas_onibus WHERE codigo_linha = @codigo", conexao);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"erro ao buscar nome da linha: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region inicializar interface
        private void InicializarComponentes()
        {
            SuspendLayout();
            this.Dock = DockStyle.Fill; // ocupa toda a área do controle //
            this.BackColor = Color.MediumTurquoise;

            Panel panelPrincipal = new Panel
            {
                BackColor = Color.LightCyan,
                Size = new Size(680, 450),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(panelPrincipal);

            lblTitulo = new Label
            {
                Text = !string.IsNullOrEmpty(nomeLinha)
                    ? $"Rastreamento - {nomeLinha} ({codigoLinha})"
                    : $"Rastreamento - Linha {codigoLinha}",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblStatus = new Label
            {
                Text = "Carregando veículos...",
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.DimGray,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lstVeiculos = new ListBox
            {
                Font = new Font("Segoe UI", 11),
                Size = new Size(500, 220),
                BackColor = Color.White,
                ForeColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };
            lstVeiculos.MouseClick += LstVeiculos_MouseClick;

            btnAtualizar = CriarBotao("Atualizar", Color.MediumSeaGreen);
            btnAtualizar.Click += async (s, e) => await CarregarVeiculos();

            btnVoltar = CriarBotao("Voltar", Color.LightGray);
            btnVoltar.Click += (s, e) => formularioPrincipal.TrocarControle(new MenuInicial(formularioPrincipal, "usuário"));

            panelPrincipal.Location = new Point((this.Width - panelPrincipal.Width) / 2, (this.Height - panelPrincipal.Height) / 2);
            panelPrincipal.Anchor = AnchorStyles.None;

            int centerX = (panelPrincipal.Width - 500) / 2;
            int posY = 30;

            lblTitulo.Location = new Point((panelPrincipal.Width - lblTitulo.PreferredWidth) / 2, posY);
            posY += 50;

            lblStatus.Location = new Point((panelPrincipal.Width - lblStatus.PreferredWidth) / 2, posY);
            posY += 30;

            lstVeiculos.Location = new Point(centerX, posY);
            posY += lstVeiculos.Height + 20;

            btnAtualizar.Location = new Point(centerX, posY);
            btnVoltar.Location = new Point(centerX + btnAtualizar.Width + 20, posY);

            btnVerInfo = CriarBotao("Ver informações da linha", Color.Goldenrod, 240, 40);
            btnVerInfo.Click += (s, e) =>
            {
                formularioPrincipal.TrocarControle(new InformacoesTransporte(formularioPrincipal, codigoLinha, nomeLinha));
            };

            btnVerInfo.Location = new Point((panelPrincipal.Width - btnVerInfo.Width) / 2, btnAtualizar.Bottom + 5);

            panelPrincipal.Controls.AddRange(new Control[] {
                lblTitulo, lblStatus, lstVeiculos, btnAtualizar, btnVoltar, btnVerInfo
            });

            ResumeLayout(false);
            PerformLayout();
        }

        private Button CriarBotao(string texto, Color cor, int largura = 120, int altura = 40)
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
                FlatAppearance = {
                    BorderSize = 0,
                    MouseOverBackColor = Color.LightBlue,
                    MouseDownBackColor = Color.DeepSkyBlue
                }
            };
        }
        #endregion

        #region carregar veículos
        private async Task CarregarVeiculos()
        {
            try
            {
                lblStatus.Text = "Buscando veículos da linha...";
                lstVeiculos.Items.Clear();
                lstVeiculos.Items.Add("Carregando...");
                btnAtualizar.Enabled = false;
                Application.DoEvents();

                veiculos = await UrbsApi.ObterVeiculos(codigoLinha); // busca os dados da api da urbs //

                lstVeiculos.Items.Clear();

                if (veiculos != null && veiculos.Count > 0)
                {
                    foreach (var v in veiculos)
                    {
                        string prefixo = v["COD"]?.ToString() ?? "???"; // prefixo do ônibus //
                        string hora = v["REFRESH"]?.ToString() ?? "-"; // horário da última atualização //

                        lstVeiculos.Items.Add($"[{prefixo}] Última atualização: {hora}");
                        lstVeiculos.Items.Add($"   → Mostrar no mapa");
                    }
                    lblStatus.Text = $"{veiculos.Count} veículos encontrados";
                }
                else
                {
                    lstVeiculos.Items.Add("Nenhum veículo encontrado no momento.");
                    lblStatus.Text = "Nenhum veículo em operação";
                }
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Busca cancelada";
                lstVeiculos.Items.Clear();
                lstVeiculos.Items.Add("A requisição foi interrompida.");
                lstVeiculos.Items.Add("Clique em Atualizar para tentar novamente.");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro ao buscar veículos";
                lstVeiculos.Items.Clear();
                lstVeiculos.Items.Add("Ocorreu um erro:");
                lstVeiculos.Items.Add(ex.Message);
                Console.WriteLine($"erro: {ex}");
            }
            finally
            {
                btnAtualizar.Enabled = true;
            }
        }
        #endregion

        #region clique na lista
        private void LstVeiculos_MouseClick(object sender, MouseEventArgs e)
        {
            int index = lstVeiculos.IndexFromPoint(e.Location); // identifica o item clicado //
            if (index >= 0 && lstVeiculos.Items[index].ToString().Contains("Mostrar no mapa"))
            {
                string urbsUrl = $"https://www.urbs.curitiba.pr.gov.br/itibus/{codigoLinha}"; // link do mapa da urbs //

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = urbsUrl,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir o rastreamento URBS: {ex.Message}", "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string FormatarCoordenadas(double latitude, double longitude)
        {
            return $"{latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}," +
                   $"{longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}"; // formata coordenadas para exibição //
        }
        #endregion
    }
}