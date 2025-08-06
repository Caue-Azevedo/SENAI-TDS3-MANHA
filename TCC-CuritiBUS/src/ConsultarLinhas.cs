using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCC_SENAI_CAUE_GUEDES
{
    public class ConsultarLinhas : UserControl
    {
        #region campos privados
        // referência ao formulário principal //
        private Form1 formularioPrincipal;

        // controles de busca e listagem //
        private TextBox txtBuscar;
        private ListBox listLinhas;
        private Button btnVoltar;
        private Button btnOrdenarAZ;
        private Button btnOrdenarNum;
        private Label lblTitulo;
        private Label lblNoResults;

        // painéis para organização visual //
        private Panel panelBusca;
        private Panel panelLista;

        // controle de ordenação atual //
        private bool ordenacaoNumerica = false;

        // string de conexão com banco de dados //
        private readonly string connectionString = "server=localhost;database=transporte_curitiba;uid=root;pwd=;";

        // cores usadas na interface //
        private readonly Color CorFundo = Color.SkyBlue;
        private readonly Color CorTitulo = Color.Navy;
        private readonly Color CorTextoNormal = Color.DimGray;
        private readonly Color CorTextoPlaceholder = Color.SlateGray;
        private readonly Color CorFundoCaixaTexto = Color.White;
        private readonly Color CorFundoLista = Color.Lavender;
        private readonly Color CorItemSelecionado = Color.DodgerBlue;
        private readonly Color CorTextoSelecionado = Color.White;
        private readonly Color CorDivisoria = Color.MediumSlateBlue;
        private readonly Color CorBotaoNormal = Color.CornflowerBlue;
        private readonly Color CorBotaoHover = Color.MediumSlateBlue;
        private readonly Color CorBotaoClick = Color.MediumBlue;
        private readonly Color CorSemResultados = Color.DarkSlateGray;
        private readonly Color CorBotaoSecundario = Color.MediumPurple;
        #endregion

        #region construtor e inicialização
        // construtor recebe instância do formulário principal //
        public ConsultarLinhas(Form1 formPrincipal)
        {
            formularioPrincipal = formPrincipal;
            InitializeComponent();   // inicializa componentes visuais //
            ConfigurarEventos();     // associa eventos aos controles //
            PopularLista();          // carrega lista de linhas inicialmente //
        }
        #endregion

        #region configuração de componentes visuais
        // cria e organiza os controles visuais do UserControl //
        private void InitializeComponent()
        {
            this.BackColor = CorFundo;            // cor de fundo geral //
            this.Size = new Size(600, 500);       // tamanho fixo do controle //
            this.Padding = new Padding(20);       // padding interno //

            // painel do título //
            var panelTitulo = new Panel() { Dock = DockStyle.Top, Height = 80, BackColor = Color.Transparent, Padding = new Padding(0, 10, 0, 10) };
            lblTitulo = new Label()
            {
                Text = "CONSULTAR LINHAS DE ÔNIBUS",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = CorTitulo
            };
            panelTitulo.Controls.Add(lblTitulo);

            // painel da busca e botões //
            panelBusca = new Panel() { Dock = DockStyle.Top, Height = 60, BackColor = Color.Transparent, Padding = new Padding(0, 10, 0, 10) };
            txtBuscar = new TextBox()
            {
                Dock = DockStyle.Fill,
                Height = 40,
                Font = new Font("Segoe UI", 11),
                Text = "Buscar linha...",
                BorderStyle = BorderStyle.None,
                BackColor = CorFundoCaixaTexto,
                ForeColor = CorTextoPlaceholder
            };

            // painel para arredondar bordas da busca //
            var roundedPanelBusca = new Panel() { Dock = DockStyle.Fill, BackColor = CorFundoCaixaTexto, Padding = new Padding(15, 0, 15, 0) };
            roundedPanelBusca.Controls.Add(txtBuscar);

            // botão ordenar A-Z //
            btnOrdenarAZ = new Button()
            {
                Dock = DockStyle.Right,
                Width = 100,
                Text = "Ordenar A-Z",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = CorBotaoSecundario,
                ForeColor = Color.White
            };
            btnOrdenarAZ.FlatAppearance.BorderSize = 0;

            // botão ordenar numérico //
            btnOrdenarNum = new Button()
            {
                Dock = DockStyle.Right,
                Width = 100,
                Text = "Ordenar Num",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = CorBotaoSecundario,
                ForeColor = Color.White
            };
            btnOrdenarNum.FlatAppearance.BorderSize = 0;

            // botão voltar //
            btnVoltar = new Button()
            {
                Dock = DockStyle.Right,
                Width = 100,
                Text = "Voltar",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = CorBotaoNormal,
                ForeColor = Color.White
            };
            btnVoltar.FlatAppearance.BorderSize = 0;

            // adiciona botões e caixa de texto ao painel de busca //
            panelBusca.Controls.Add(btnVoltar);
            panelBusca.Controls.Add(btnOrdenarNum);
            panelBusca.Controls.Add(btnOrdenarAZ);
            panelBusca.Controls.Add(roundedPanelBusca);

            // painel para lista de linhas //
            panelLista = new Panel() { Dock = DockStyle.Fill, BackColor = Color.Transparent };
            listLinhas = new ListBox()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.None,
                BackColor = CorFundoLista,
                ForeColor = CorTextoNormal,
                DrawMode = DrawMode.OwnerDrawVariable,
            };
            listLinhas.DrawItem += ListLinhas_DrawItem;    // desenho customizado //
            listLinhas.MeasureItem += (s, e) => { e.ItemHeight = 40; }; // altura fixa por item //

            // painel arredondado para lista //
            var roundedPanelLista = new Panel() { Dock = DockStyle.Fill, BackColor = CorFundoLista, Padding = new Padding(5) };
            roundedPanelLista.Controls.Add(listLinhas);

            // label exibida quando não há resultados //
            lblNoResults = new Label()
            {
                Dock = DockStyle.Fill,
                Text = "Nenhuma linha encontrada.",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                ForeColor = CorSemResultados,
                Visible = false
            };

            // adiciona label e lista ao painel de lista //
            panelLista.Controls.Add(lblNoResults);
            panelLista.Controls.Add(roundedPanelLista);

            // adiciona os painéis ao UserControl //
            this.Controls.Add(panelLista);
            this.Controls.Add(panelBusca);
            this.Controls.Add(panelTitulo);
        }
        #endregion

        #region configuração de eventos
        // associa eventos aos controles para interação //
        private void ConfigurarEventos()
        {
            // limpa placeholder ao entrar na caixa de busca //
            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == "Buscar linha...")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = CorTextoNormal;
                }
            };

            // restaura placeholder ao sair da caixa de busca //
            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Buscar linha...";
                    txtBuscar.ForeColor = CorTextoPlaceholder;
                }
            };

            // atualiza lista conforme texto digitado //
            txtBuscar.TextChanged += (s, e) =>
            {
                PopularLista(txtBuscar.Text == "Buscar linha..." ? "" : txtBuscar.Text);
            };

            // botão voltar para menu inicial //
            btnVoltar.Click += (s, e) =>
            {
                formularioPrincipal.TrocarControle(new MenuInicial(formularioPrincipal, "Usuário"));
            };

            // ordenar alfabeticamente //
            btnOrdenarAZ.Click += (s, e) =>
            {
                ordenacaoNumerica = false;
                PopularLista(txtBuscar.Text == "Buscar linha..." ? "" : txtBuscar.Text);
            };

            // ordenar numericamente //
            btnOrdenarNum.Click += (s, e) =>
            {
                ordenacaoNumerica = true;
                PopularLista(txtBuscar.Text == "Buscar linha..." ? "" : txtBuscar.Text);
            };

            // exibe menu de opções ao selecionar linha //
            listLinhas.SelectedIndexChanged += ListLinhas_SelectedIndexChanged;
        }
        #endregion

        #region métodos de manipulação da lista
        // preenche a lista de linhas filtrando e ordenando //
        private void PopularLista(string filtro = "")
        {
            try
            {
                List<string> linhasExibicao = new List<string>();  // lista temporária para itens exibidos //

                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    string sql = "SELECT nome_linha, codigo_linha FROM linhas_onibus"; // consulta linhas //

                    using (var cmd = new MySqlCommand(sql, conexao))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nome = reader.GetString("nome_linha");    // nome da linha //
                            string codigo = reader.GetString("codigo_linha");// código da linha //
                            string linha = $"{nome} [{codigo}]";             // formato exibido //

                            // aplica filtro se informado //
                            if (string.IsNullOrEmpty(filtro) || linha.ToLower().Contains(filtro.ToLower()))
                                linhasExibicao.Add(linha);
                        }
                    }
                }

                // ordena lista conforme modo selecionado //
                if (ordenacaoNumerica)
                    linhasExibicao = linhasExibicao.OrderBy(l => ExtrairNumero(l)).ThenBy(l => l).ToList();
                else
                    linhasExibicao = linhasExibicao.OrderBy(l => l).ToList();

                // atualiza lista visual //
                listLinhas.BeginUpdate();
                listLinhas.Items.Clear();
                foreach (var linha in linhasExibicao)
                    listLinhas.Items.Add(linha);
                listLinhas.EndUpdate();

                // mostra mensagem se não houver resultados //
                lblNoResults.Visible = linhasExibicao.Count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar linhas: " + ex.Message); // mensagem de erro //
            }
        }

        // extrai número do código da linha para ordenação numérica //
        private int ExtrairNumero(string linha)
        {
            string numeros = "";
            int i = linha.IndexOf("[");
            int j = linha.IndexOf("]");
            if (i >= 0 && j > i)
            {
                string codigo = linha.Substring(i + 1, j - i - 1);
                foreach (char c in codigo)
                {
                    if (char.IsDigit(c)) numeros += c;
                    else break;
                }
            }
            return int.TryParse(numeros, out int num) ? num : int.MaxValue; // retorna número ou valor alto para não números //
        }
        #endregion

        #region desenho customizado da lista
        // desenha cada item da lista com estilo customizado //
        private void ListLinhas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected; // verifica seleção //
            Color back = selected ? CorItemSelecionado : CorFundoLista;                   // cor fundo //
            Color fore = selected ? CorTextoSelecionado : CorTextoNormal;                // cor texto //

            e.Graphics.FillRectangle(new SolidBrush(back), e.Bounds);                     // pinta fundo //
            e.Graphics.DrawString(listLinhas.Items[e.Index].ToString(), e.Font, new SolidBrush(fore), new PointF(e.Bounds.X + 10, e.Bounds.Y + 8)); // texto //

            // linha divisória entre itens, exceto último //
            if (e.Index < listLinhas.Items.Count - 1)
                e.Graphics.DrawLine(new Pen(CorDivisoria, 0.5f), e.Bounds.X + 5, e.Bounds.Bottom - 1, e.Bounds.Right - 5, e.Bounds.Bottom - 1);

            e.DrawFocusRectangle();  // retângulo de foco //
        }
        #endregion

        #region seleção e menu contextual
        // exibe menu contextual ao selecionar uma linha da lista //
        private void ListLinhas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listLinhas.SelectedIndex < 0) return;

            string selecionada = listLinhas.SelectedItem.ToString();
            int i = selecionada.IndexOf("[");
            int j = selecionada.IndexOf("]");
            if (i >= 0 && j > i)
            {
                string nome = selecionada.Substring(0, i).Trim();            // nome da linha //
                string codigo = selecionada.Substring(i + 1, j - i - 1);    // código da linha //

                var menu = new ContextMenuStrip();

                // opção para ver informações da linha //
                var info = new ToolStripMenuItem("Ver Informações da Linha");
                info.Click += (s, ev) => formularioPrincipal.TrocarControle(new InformacoesTransporte(formularioPrincipal, codigo, nome));
                menu.Items.Add(info);

                // opção para rastrear veículos da linha //
                var rastrear = new ToolStripMenuItem("Rastrear Veículos");
                rastrear.Click += (s, ev) => formularioPrincipal.AbrirRastreamentoComLinha(codigo, nome);
                menu.Items.Add(rastrear);

                // posiciona menu logo abaixo do item selecionado //
                var pos = listLinhas.PointToScreen(new Point(listLinhas.GetItemRectangle(listLinhas.SelectedIndex).X, listLinhas.GetItemRectangle(listLinhas.SelectedIndex).Bottom));
                menu.Show(pos);
            }
        }
        #endregion
    }
}