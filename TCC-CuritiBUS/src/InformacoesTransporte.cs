using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class InformacoesTransporte : UserControl
    {
        #region cabeçalho e campos iniciais

        // referência ao formulário principal para navegação //
        private readonly Form1 formularioPrincipal;

        // componentes visuais da tela //
        private Label lblTitulo;
        private Button btnVoltar;
        private ListBox lstHorarios;
        private ListBox lstPontos;
        private TextBox txtCodigoLinha;
        private Button btnBuscarInfo;
        private Label lblCodigoLinha;
        private ComboBox cmbDiaSemana;
        private ComboBox cmbDestinoHorario;
        private ComboBox cmbFiltroPontoFinal;
        private Button btnRastrear;

        // conexão com o banco de dados //
        private readonly string connectionString = "server=localhost;database=transporte_curitiba;uid=root;pwd=;";

        // variáveis para armazenar a linha selecionada //
        private string codigoLinhaSelecionada;
        private string nomeLinhaSelecionada;

        // estrutura com os dados dos pontos obtidos da api //
        private JArray pontosDaLinha;

        public InformacoesTransporte(Form1 form, string codigoLinha = null, string nomeLinha = null)
        {
            formularioPrincipal = form;
            codigoLinhaSelecionada = codigoLinha;
            nomeLinhaSelecionada = nomeLinha;
            InicializarComponentes();
            CarregarSugestoesCodigos();

            // ajustar layout sempre que o tamanho do controle for alterado //
            this.Resize += (s, e) => AjustarLayout();

            // se já veio uma linha selecionada, preenche automaticamente o campo e busca as informações //
            if (!string.IsNullOrEmpty(codigoLinhaSelecionada))
            {
                txtCodigoLinha.Text = codigoLinhaSelecionada;
                _ = BuscarInformacoesLinha();
            }
        }

        #endregion

        #region inicialização da interface

        private void InicializarComponentes()
        {
            // configurações básicas da tela //
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.SkyBlue;

            // título com nome da linha (se houver) //
            lblTitulo = new Label
            {
                Text = !string.IsNullOrEmpty(nomeLinhaSelecionada)
                    ? $"Informações da Linha: {nomeLinhaSelecionada}"
                    : "Informações do Transporte",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.Navy,
                AutoSize = true,
                Location = new Point(30, 20)
            };
            this.Controls.Add(lblTitulo);

            // botão para rastrear linha //
            btnRastrear = new Button
            {
                Text = "Rastrear Linha",
                Location = new Point(410, 70),
                Size = new Size(110, 30),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Visible = false
            };
            btnRastrear.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(codigoLinhaSelecionada))
                {
                    formularioPrincipal.TrocarControle(new Rastreamento(formularioPrincipal, codigoLinhaSelecionada, nomeLinhaSelecionada));
                }
            };
            this.Controls.Add(btnRastrear);
            btnRastrear.Visible = true;

            // botão para retornar ao menu inicial //
            btnVoltar = new Button
            {
                Text = "Voltar",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Size = new Size(90, 32),
                Location = new Point(30, 60),
                BackColor = Color.CornflowerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnVoltar.Click += (s, e) => formularioPrincipal.TrocarControle(new MenuInicial(formularioPrincipal, "usuário"));
            this.Controls.Add(btnVoltar);

            // rótulo do campo de código ou nome //
            lblCodigoLinha = new Label
            {
                Text = "Código ou Nome da Linha:",
                Font = new Font("Segoe UI", 9),
                Location = new Point(130, 55),
                AutoSize = true,
                ForeColor = Color.DimGray
            };
            this.Controls.Add(lblCodigoLinha);

            // campo de entrada do código/nome da linha //
            txtCodigoLinha = new TextBox
            {
                Location = new Point(130, 72),
                Width = 180,
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(txtCodigoLinha);

            // botão para iniciar a busca da linha //
            btnBuscarInfo = new Button
            {
                Text = "Buscar",
                Location = new Point(320, 70),
                Size = new Size(80, 30),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.MediumPurple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBuscarInfo.Click += async (s, e) => await BuscarInformacoesLinha();
            this.Controls.Add(btnBuscarInfo);

            // seleção de dia da semana //
            cmbDiaSemana = new ComboBox
            {
                Location = new Point(410, 72),
                Width = 130,
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbDiaSemana.Items.AddRange(new object[] { "Dia Útil", "Sábado", "Domingo/Feriado" });
            cmbDiaSemana.SelectedIndex = 0;
            cmbDiaSemana.SelectedIndexChanged += async (s, e) => await AtualizarHorarios();
            this.Controls.Add(cmbDiaSemana);

            // seleção de destino para horários //
            cmbDestinoHorario = new ComboBox
            {
                Location = new Point(650, 72),
                Width = 160,
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbDestinoHorario.SelectedIndexChanged += async (s, e) => await AtualizarHorarios();
            this.Controls.Add(cmbDestinoHorario);

            // rótulo dos pontos da linha //
            Label lblPontos = new Label
            {
                Text = "Sentido Pontos da Linha",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(30, 110),
                AutoSize = true,
                ForeColor = Color.Navy
            };
            this.Controls.Add(lblPontos);

            // rótulo dos horários //
            Label lblHorarios = new Label
            {
                Text = "Horários",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(360, 110),
                AutoSize = true,
                ForeColor = Color.Navy
            };
            this.Controls.Add(lblHorarios);

            // lista dos pontos da linha //
            lstPontos = new ListBox
            {
                Location = new Point(30, 140),
                Size = new Size(310, 300),
                Font = new Font("Consolas", 9),
                BackColor = Color.Lavender,
                BorderStyle = BorderStyle.None,
                ForeColor = Color.DimGray
            };
            this.Controls.Add(lstPontos);

            // lista dos horários da linha //
            lstHorarios = new ListBox
            {
                Location = new Point(360, 140),
                Size = new Size(360, 300),
                Font = new Font("Consolas", 9),
                BackColor = Color.Lavender,
                BorderStyle = BorderStyle.None,
                ForeColor = Color.DimGray
            };
            this.Controls.Add(lstHorarios);

            // filtro para exibir pontos de acordo com o destino //
            cmbFiltroPontoFinal = new ComboBox
            {
                Location = new Point(720, 72),
                Width = 180,
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbFiltroPontoFinal.SelectedIndexChanged += (s, e) => FiltrarPontosPorDestinoFinal();
            this.Controls.Add(cmbFiltroPontoFinal);

            AjustarLayout(); // organiza os componentes na tela
        }
        #endregion

        #region busca e exibição das informações da linha

        // busca informações da linha no banco e exibe pontos e horários //
        private async Task BuscarInformacoesLinha()
        {
            string entrada = txtCodigoLinha.Text.Trim();

            // impede busca com campo vazio //
            if (string.IsNullOrEmpty(entrada))
            {
                MessageBox.Show("Informe o código ou nome da linha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // busca no banco de dados a linha correspondente //
            using (var conexao = new MySqlConnection(connectionString))
            {
                conexao.Open();
                var cmd = new MySqlCommand("SELECT codigo_linha, nome_linha FROM linhas_onibus WHERE codigo_linha = @entrada OR nome_linha LIKE @nome", conexao);
                cmd.Parameters.AddWithValue("@entrada", entrada);
                cmd.Parameters.AddWithValue("@nome", "%" + entrada + "%");

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        codigoLinhaSelecionada = reader.GetString("codigo_linha");
                        nomeLinhaSelecionada = reader.GetString("nome_linha");
                    }
                    else
                    {
                        MessageBox.Show("Linha não encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            // atualiza título com o nome da linha //
            lblTitulo.Text = $"Informações da Linha: {nomeLinhaSelecionada}";

            try
            {
                // busca os pontos da linha na api //
                pontosDaLinha = await UrbsApi.ObterPontosDaLinha(codigoLinhaSelecionada);

                // ordena os pontos pela sequência e agrupa por sentido //
                var pontosOrdenados = pontosDaLinha
                    .OrderBy(p => Convert.ToInt32(p["SEQ"]?.ToString() ?? "0"))
                    .GroupBy(p => p["SENTIDO"]?.ToString() ?? "")
                    .SelectMany(g => g)
                    .ToList();

                // extrai os destinos finais únicos //
                var destinosFinais = pontosOrdenados
                    .Select(p => p["SENTIDO"]?.ToString())
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Distinct()
                    .ToList();

                // alimenta a combo de filtro de pontos //
                cmbFiltroPontoFinal.Items.Clear();
                cmbFiltroPontoFinal.Items.Add("Todos");
                cmbFiltroPontoFinal.Items.AddRange(destinosFinais.ToArray());
                cmbFiltroPontoFinal.SelectedIndex = 0;

                // exibe os pontos na lista //
                lstPontos.Items.Clear();
                foreach (var ponto in pontosOrdenados)
                {
                    string nome = ponto["NOME"]?.ToString() ?? "?";
                    string num = ponto["NUM"]?.ToString() ?? "?";
                    string sentido = ponto["SENTIDO"]?.ToString() ?? "?";
                    lstPontos.Items.Add($"{num} - {nome} ({sentido})");
                }

                // limpa e atualiza destinos e horários //
                cmbDestinoHorario.Items.Clear();
                await AtualizarHorarios();
            }
            catch (Exception ex)
            {
                lstPontos.Items.Clear();
                lstHorarios.Items.Clear();
                lstPontos.Items.Add("Erro ao buscar pontos: " + ex.Message);
                lstHorarios.Items.Add("Erro ao buscar horários: " + ex.Message);
            }
        }

        // atualiza os horários conforme a linha, dia e destino selecionados //
        private async Task AtualizarHorarios()
        {
            if (string.IsNullOrEmpty(codigoLinhaSelecionada)) return;

            try
            {
                lstHorarios.Items.Clear();
                lstHorarios.Items.Add("Carregando horários...");
                Application.DoEvents();

                var horarios = await UrbsApi.ObterTabelaHoraria(codigoLinhaSelecionada);

                if (horarios != null && horarios.Count > 0)
                {
                    string diaSelecionado = (cmbDiaSemana.SelectedIndex + 1).ToString();

                    // carrega os destinos apenas se ainda não estiverem preenchidos //
                    if (cmbDestinoHorario.Items.Count == 0)
                    {
                        var destinos = horarios
                            .Select(h => h["PONTO"]?.ToString())
                            .Where(dest => !string.IsNullOrWhiteSpace(dest) && dest != "?")
                            .Distinct()
                            .ToList();

                        if (destinos.Count == 0) destinos.Add("Todos");
                        cmbDestinoHorario.Items.AddRange(destinos.ToArray());
                        cmbDestinoHorario.SelectedIndex = 0;
                    }

                    string destinoSelecionado = cmbDestinoHorario.SelectedItem?.ToString();
                    lstHorarios.Items.Clear();

                    // filtra e ordena os horários //
                    var horariosOrdenados = horarios
                        .Where(h => h["DIA"]?.ToString() == diaSelecionado &&
                                   (destinoSelecionado == "Todos" || h["PONTO"]?.ToString() == destinoSelecionado))
                        .OrderBy(h => h["HORA"]?.ToString())
                        .ToList();

                    foreach (var horario in horariosOrdenados)
                    {
                        string hora = horario["HORA"]?.ToString() ?? "?";
                        string ponto = horario["PONTO"]?.ToString() ?? "?";
                        lstHorarios.Items.Add($"[{ObterDescricaoDia(diaSelecionado)}] {hora} - {ponto}");
                    }

                    // se nenhum horário foi encontrado, exibe aviso //
                    if (horariosOrdenados.Count == 0)
                    {
                        lstHorarios.Items.Add($"Nenhum horário encontrado para {cmbDiaSemana.SelectedItem}");
                    }

                    // destaca na lista o primeiro ponto relacionado ao destino //
                    if (pontosDaLinha != null && destinoSelecionado != "Todos")
                    {
                        var primeiroPonto = pontosDaLinha
                            .FirstOrDefault(p => p["NOME"]?.ToString().Contains(destinoSelecionado) == true ||
                                                 p["NUM"]?.ToString().Contains(destinoSelecionado) == true);

                        if (primeiroPonto != null)
                        {
                            string nomePonto = primeiroPonto["NOME"]?.ToString() ?? "?";
                            string numPonto = primeiroPonto["NUM"]?.ToString() ?? "?";
                            string sentidoPonto = primeiroPonto["SENTIDO"]?.ToString() ?? "?";
                            string itemParaSelecionar = $"{numPonto} - {nomePonto} ({sentidoPonto})";

                            int index = lstPontos.Items.IndexOf(itemParaSelecionar);
                            if (index >= 0)
                            {
                                lstPontos.SelectedIndex = index;
                                lstPontos.TopIndex = Math.Max(0, index - 3);
                            }
                        }
                    }
                }
                else
                {
                    lstHorarios.Items.Clear();
                    lstHorarios.Items.Add("Nenhum horário cadastrado para esta linha.");
                }
            }
            catch (Exception ex)
            {
                lstHorarios.Items.Clear();
                lstHorarios.Items.Add("Erro ao carregar horários:");
                lstHorarios.Items.Add(ex.Message);
            }
        }

        // traduz o código numérico do dia da semana //
        private string ObterDescricaoDia(string codigoDia)
        {
            switch (codigoDia)
            {
                case "1": return "Dia Útil";
                case "2": return "Sábado";
                case "3": return "Domingo/Feriado";
                default: return "?";
            }
        }

        #endregion

        #region sugestões de auto-complete

        // carrega todos os códigos e nomes de linhas para sugerir ao usuário //
        private void CarregarSugestoesCodigos()
        {
            try
            {
                txtCodigoLinha.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCodigoLinha.AutoCompleteSource = AutoCompleteSource.CustomSource;
                var source = new AutoCompleteStringCollection();

                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT codigo_linha, nome_linha FROM linhas_onibus", conexao);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            source.Add(reader["codigo_linha"].ToString());
                            source.Add(reader["nome_linha"].ToString());
                        }
                    }
                }

                txtCodigoLinha.AutoCompleteCustomSource = source;
            }
            catch { }
        }

        #endregion

        #region layout dinâmico

        // ajusta a posição dos componentes conforme tamanho da tela //
        private void AjustarLayout()
        {
            int margem = 30;
            int larguraTotal = this.ClientSize.Width;
            int alturaTotal = this.ClientSize.Height;

            lblTitulo.Location = new Point(margem, margem);
            btnVoltar.Location = new Point(margem, lblTitulo.Bottom + 10);

            int linhaTop = btnVoltar.Bottom + 35;
            int x = margem;

            txtCodigoLinha.Location = new Point(x, linhaTop);
            txtCodigoLinha.Width = 160;
            x += txtCodigoLinha.Width + 10;

            btnBuscarInfo.Location = new Point(x, linhaTop);
            btnBuscarInfo.Width = 80;
            x += btnBuscarInfo.Width + 10;

            btnRastrear.Location = new Point(x, linhaTop);
            btnRastrear.Width = 120;
            x += btnRastrear.Width + 10;

            cmbDiaSemana.Location = new Point(x, linhaTop);
            cmbDiaSemana.Width = 130;

            lblCodigoLinha.Location = new Point(txtCodigoLinha.Left, txtCodigoLinha.Top - 18);

            int larguraMetade = (larguraTotal - (margem * 3)) / 2;

            Label lblPontos = Controls.OfType<Label>().FirstOrDefault(l => l.Text == "Sentido Pontos da Linha");
            Label lblHorarios = Controls.OfType<Label>().FirstOrDefault(l => l.Text == "Horários");

            int topoListas = txtCodigoLinha.Bottom + 30;

            if (lblPontos != null) lblPontos.Location = new Point(margem, topoListas);
            if (lblHorarios != null) lblHorarios.Location = new Point(margem + larguraMetade + margem, topoListas);

            cmbFiltroPontoFinal.Location = new Point(margem, (lblPontos?.Bottom ?? topoListas) + 5);
            cmbFiltroPontoFinal.Width = larguraMetade;

            cmbDestinoHorario.Location = new Point(margem + larguraMetade + margem, (lblHorarios?.Bottom ?? topoListas) + 5);
            cmbDestinoHorario.Width = larguraMetade;

            lstPontos.Location = new Point(margem, cmbFiltroPontoFinal.Bottom + 5);
            lstPontos.Size = new Size(larguraMetade, alturaTotal - lstPontos.Top - margem);

            lstHorarios.Location = new Point(lstPontos.Right + margem, lstPontos.Top);
            lstHorarios.Size = new Size(larguraMetade, lstPontos.Height);
        }

        #endregion

        #region filtro de pontos

        // atualiza a lista de pontos exibida com base no sentido selecionado pelo usuário //
        private void FiltrarPontosPorDestinoFinal()
        {
            // verifica se há dados disponíveis antes de aplicar o filtro //
            if (pontosDaLinha == null || pontosDaLinha.Count == 0)
                return;

            // obtém o valor escolhido no combo de sentidos //
            string destinoSelecionado = cmbFiltroPontoFinal.SelectedItem?.ToString();

            // filtra os pontos conforme o sentido ou exibe todos caso selecionado //
            var pontosFiltrados = pontosDaLinha
                .Where(p => destinoSelecionado == "Todos" || p["SENTIDO"]?.ToString() == destinoSelecionado)
                .OrderBy(p => Convert.ToInt32(p["SEQ"]?.ToString() ?? "0"))
                .ToList();

            // limpa a lista atual antes de mostrar os pontos filtrados //
            lstPontos.Items.Clear();

            // preenche a lista com os pontos do sentido selecionado, mantendo a ordem da linha //
            foreach (var ponto in pontosFiltrados)
            {
                string nome = ponto["NOME"]?.ToString() ?? "?";
                string num = ponto["NUM"]?.ToString() ?? "?";
                string sentido = ponto["SENTIDO"]?.ToString() ?? "?";
                lstPontos.Items.Add($"{num} - {nome} ({sentido})");
            }
        }

        #endregion
    }
}