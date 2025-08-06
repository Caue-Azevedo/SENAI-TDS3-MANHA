using System;
using System.Drawing;
using System.IO; // necessário para operações de arquivo, como File.Exists e Image.FromFile //
using System.Windows.Forms; // necessário para classes de UI do Windows Forms //

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class MenuInicial : UserControl
    {
        #region campos privados

        // referência para o formulário principal da aplicação, permitindo a troca de controles //
        private readonly Form1 formularioPrincipal;
        // nome do usuário logado, exibido na mensagem de boas-vindas //
        private readonly string nomeUsuario;

        // controles visuais do UserControl //
        private Label lblBemVindo;
        private PictureBox picImagemTopo;
        private Button btnConsultaLinhas, btnRastreamento, btnInformacoes, btnSair;
        private Panel painelCentral;

        #endregion

        #region construtor

        /// <summary>
        /// inicializa uma nova instância do UserControl MenuInicial //
        /// </summary>
        /// <param name="formPrincipal">a instância do formulário principal da aplicação //</param>
        /// <param name="nomeUsuarioLogado">o nome do usuário que fez login //</param>
        public MenuInicial(Form1 formPrincipal, string nomeUsuarioLogado)
        {
            // atribui as referências passadas para os campos readonly //
            formularioPrincipal = formPrincipal;
            nomeUsuario = nomeUsuarioLogado;

            // configurações para otimização da renderização e evitar "flickering" //
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // chama o método para configurar e adicionar os componentes visuais //
            InicializarComponentes();
            // associa o evento Resize do UserControl para centralizar os componentes quando o tamanho for alterado //
            this.Resize += (s, e) => CentralizarComponentes();
        }

        #endregion

        #region métodos privados

        /// <summary>
        /// inicializa e configura todos os componentes visuais do menu inicial //
        /// </summary>
        private void InicializarComponentes()
        {
            // define que o UserControl preencha todo o espaço disponível no container pai //
            this.Dock = DockStyle.Fill;
            // define o fundo do controle como transparente //
            this.BackColor = Color.Transparent;

            // configuração do PictureBox para a imagem do topo //
            picImagemTopo = new PictureBox
            {
                Size = new Size(180, 180), // define o tamanho da imagem //
                SizeMode = PictureBoxSizeMode.Zoom, // ajusta a imagem para caber, mantendo a proporção //
                BackColor = Color.Transparent // define o fundo da PictureBox como transparente //
            };
            // carrega a imagem especificada para o PictureBox //
            CarregarImagem(picImagemTopo, "img1-principal-superior.png");
            this.Controls.Add(picImagemTopo); // adiciona o PictureBox ao controle //

            // configuração do rótulo de boas-vindas //
            lblBemVindo = new Label
            {
                Text = $"Bem-vindo(a), {nomeUsuario}!", // mensagem personalizada com o nome do usuário //
                Font = new Font("Segoe UI", 22F, FontStyle.Italic), // define a fonte e estilo //
                ForeColor = Color.Black, // define a cor do texto //
                AutoSize = true, // ajusta o tamanho do rótulo automaticamente ao texto //
                BackColor = Color.Transparent // define o fundo do rótulo como transparente //
            };
            this.Controls.Add(lblBemVindo); // adiciona o rótulo ao controle //

            // configuração do painel central que conterá os botões //
            painelCentral = new Panel
            {
                Size = new Size(750, 350), // define o tamanho do painel //
                BackColor = Color.Transparent, // define o fundo do painel como transparente //
                Padding = new Padding(20) // adiciona preenchimento interno ao painel //
            };
            this.Controls.Add(painelCentral); // adiciona o painel central ao controle //

            // criação e configuração dos botões de navegação, utilizando um método auxiliar //
            btnConsultaLinhas = CriarBotaoModerno("CONSULTAR LINHAS", "img2-consultar-linhas.png", Color.SteelBlue);
            btnRastreamento = CriarBotaoModerno("RASTREAR ÔNIBUS", "img3-rastreamento-em-tempo-real.png", Color.MediumSeaGreen);
            btnInformacoes = CriarBotaoModerno("INFORMAÇÕES", "img4-informações-do-transporte.png", Color.Goldenrod);
            btnSair = CriarBotaoModerno("SAIR", "img5-sair.png", Color.Crimson);

            // associa os eventos de clique de cada botão para trocar os controles no formulário principal //
            btnConsultaLinhas.Click += (s, e) => formularioPrincipal.TrocarControle(new ConsultarLinhas(formularioPrincipal));
            btnRastreamento.Click += (s, e) => formularioPrincipal.TrocarControle(new SelecionarLinhaParaRastreamento(formularioPrincipal));
            btnInformacoes.Click += (s, e) => formularioPrincipal.TrocarControle(new InformacoesTransporte(formularioPrincipal));
            btnSair.Click += (s, e) => formularioPrincipal.MostrarTelaInicial(); // chama um método no formulário principal para voltar à tela de login //

            // adiciona todos os botões ao painel central //
            painelCentral.Controls.AddRange(new Control[] { btnConsultaLinhas, btnRastreamento, btnInformacoes, btnSair });

            // centraliza os componentes inicialmente após a sua criação //
            CentralizarComponentes();
        }

        /// <summary>
        /// cria e configura um botão com estilo moderno, ícone e efeitos de hover //
        /// </summary>
        /// <param name="texto">o texto a ser exibido no botão //</param>
        /// <param name="imagemNome">o nome do arquivo de imagem para o ícone do botão //</param>
        /// <param name="corBase">a cor de fundo base do botão //</param>
        /// <returns>um objeto Button configurado //</returns>
        private Button CriarBotaoModerno(string texto, string imagemNome, Color corBase)
        {
            var botao = new Button
            {
                Text = $"  {texto}", // adiciona um espaço para o ícone //
                Font = new Font("Segoe UI", 12, FontStyle.Bold), // define a fonte e estilo do texto //
                Size = new Size(340, 70), // define o tamanho padrão do botão //
                ForeColor = Color.White, // define a cor do texto //
                FlatStyle = FlatStyle.Flat, // define o estilo de borda do botão como plano //
                ImageAlign = ContentAlignment.MiddleLeft, // alinha a imagem à esquerda //
                TextAlign = ContentAlignment.MiddleLeft, // alinha o texto à esquerda //
                TextImageRelation = TextImageRelation.ImageBeforeText, // coloca a imagem antes do texto //
                Margin = new Padding(15), // define a margem externa do botão //
                Cursor = Cursors.Hand, // altera o cursor para uma mão ao passar sobre o botão //
                BackColor = corBase // define a cor de fundo inicial do botão //
            };
            botao.FlatAppearance.BorderSize = 0; // remove a borda do botão //

            // adiciona efeitos visuais ao passar o mouse por cima do botão (hover effects) //
            botao.MouseEnter += (s, e) =>
            {
                // clareia a cor de fundo e aumenta ligeiramente o tamanho do botão //
                botao.BackColor = ControlPaint.Light(corBase, 0.2f);
                botao.Size = new Size(345, 72);
                // ajusta a posição para que o aumento de tamanho pareça centralizado //
                botao.Location = new Point(botao.Location.X - 2, botao.Location.Y - 1);
            };
            botao.MouseLeave += (s, e) =>
            {
                // retorna a cor de fundo e o tamanho original do botão //
                botao.BackColor = corBase;
                botao.Size = new Size(340, 70);
                // ajusta a posição de volta ao original //
                botao.Location = new Point(botao.Location.X + 2, botao.Location.Y + 1);
            };
            // efeitos ao clicar no botão (clique down/up) //
            botao.MouseDown += (s, e) => botao.BackColor = ControlPaint.Dark(corBase, 0.2f); // escurece ao pressionar //
            botao.MouseUp += (s, e) => botao.BackColor = ControlPaint.Light(corBase, 0.2f); // clareia ao soltar //

            // carrega a imagem do ícone para o botão //
            CarregarImagemBotao(botao, imagemNome);
            return botao; // retorna o botão configurado //
        }

        /// <summary>
        /// carrega uma imagem de um arquivo para um PictureBox //
        /// se o arquivo não existir, usa um ícone padrão de "pergunta" //
        /// em caso de erro, exibe um ícone de exclamação e uma mensagem //
        /// </summary>
        /// <param name="pictureBox">o PictureBox onde a imagem será carregada //</param>
        /// <param name="nomeImagem">o nome do arquivo de imagem (esperado na pasta 'Imagens') //</param>
        private void CarregarImagem(PictureBox pictureBox, string nomeImagem)
        {
            try
            {
                // constrói o caminho completo para a imagem //
                string caminho = Path.Combine(Application.StartupPath, "Imagens", nomeImagem);
                // verifica se o arquivo de imagem existe e o carrega; caso contrário, usa um ícone de pergunta //
                pictureBox.Image = File.Exists(caminho)
                    ? Image.FromFile(caminho)
                    : SystemIcons.Question.ToBitmap();
            }
            catch (Exception ex)
            {
                // em caso de erro, define um ícone de exclamação e exibe uma mensagem de erro //
                pictureBox.Image = SystemIcons.Exclamation.ToBitmap();
                MessageBox.Show("Erro ao carregar imagem superior: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// carrega e redimensiona uma imagem para ser usada como ícone em um botão //
        /// em caso de erro, exibe um ícone de aviso //
        /// </summary>
        /// <param name="botao">o botão onde a imagem será definida //</param>
        /// <param name="imagemNome">o nome do arquivo de imagem (esperado na pasta 'Imagens') //</param>
        private void CarregarImagemBotao(Button botao, string imagemNome)
        {
            try
            {
                // constrói o caminho completo para a imagem //
                string caminho = Path.Combine(Application.StartupPath, "Imagens", imagemNome);
                // verifica se o arquivo de imagem existe //
                if (File.Exists(caminho))
                {
                    // carrega a imagem do arquivo //
                    Image img = Image.FromFile(caminho);
                    // cria um novo bitmap com o tamanho desejado para o ícone do botão (40x40) //
                    var bmp = new Bitmap(40, 40);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        // limpa o fundo do bitmap para garantir transparência //
                        g.Clear(Color.Transparent);
                        // desenha a imagem carregada no novo bitmap, redimensionando-a //
                        g.DrawImage(img, 0, 0, 40, 40);
                    }
                    botao.Image = bmp; // define o bitmap redimensionado como a imagem do botão //
                }
            }
            catch (Exception ex)
            {
                // em caso de erro, define um ícone de aviso e exibe uma mensagem de erro //
                botao.Image = SystemIcons.Warning.ToBitmap();
                MessageBox.Show("Erro ao carregar imagem do botão: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// centraliza dinamicamente os componentes visuais no UserControl //
        /// com base no seu tamanho atual e na hierarquia dos controles //
        /// </summary>
        private void CentralizarComponentes()
        {
            int larguraForm = this.Width; // largura atual do UserControl //

            // centraliza a imagem do topo //
            picImagemTopo.Location = new Point((larguraForm - picImagemTopo.Width) / 2, 40);
            // centraliza o rótulo de boas-vindas abaixo da imagem do topo //
            lblBemVindo.Location = new Point((larguraForm - lblBemVindo.Width) / 2, picImagemTopo.Bottom + 10);
            // centraliza o painel central abaixo do rótulo de boas-vindas //
            painelCentral.Location = new Point((larguraForm - painelCentral.Width) / 2, lblBemVindo.Bottom + 30);

            // define espaçamentos e layout para os botões dentro do painel central //
            int espacamento = 25; // espaçamento entre os botões //
            int colunas = 2; // número de colunas de botões //
            int larguraBotao = 340; // largura padrão dos botões //
            int alturaBotao = 70; // altura padrão dos botões //
            // calcula a margem horizontal para centralizar os botões dentro do painel central //
            int margemX = (painelCentral.Width - (colunas * larguraBotao) - (colunas - 1) * espacamento) / 2;

            // posiciona cada botão dentro do painel central em um layout de grid (2 colunas) //
            for (int i = 0; i < painelCentral.Controls.Count; i++)
            {
                int linha = i / colunas; // calcula a linha atual do botão //
                int coluna = i % colunas; // calcula a coluna atual do botão //
                // calcula a posição X do botão //
                int x = margemX + coluna * (larguraBotao + espacamento);
                // calcula a posição Y do botão //
                int y = 20 + linha * (alturaBotao + espacamento);
                // define a localização do botão //
                painelCentral.Controls[i].Location = new Point(x, y);
            }
        }

        #endregion
    }
}
