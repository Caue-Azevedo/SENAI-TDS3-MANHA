using System;
using System.Drawing;
using System.Windows.Forms;

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class Form1 : Form
    {
        #region construtor do formulário principal
        public Form1()
        {
            InitializeComponent(); // método padrão gerado pelo designer //

            this.Text = "CuritiBUS"; // define o título da janela //
            this.StartPosition = FormStartPosition.CenterScreen; // centraliza a janela na tela //
            this.BackColor = Color.LightBlue; // define cor de fundo suave //

            InicializarComponentes(); // configura os elementos da tela inicial //
        }
        #endregion

        #region método para inicializar os componentes da tela inicial
        private void InicializarComponentes()
        {
            this.Controls.Clear(); // remove quaisquer controles anteriores para garantir tela limpa //

            // cria botão "Entrar" //
            var btnEntrar = new Button
            {
                Text = "Entrar", // texto do botão para acesso //
                Font = new Font("Segoe UI", 16, FontStyle.Bold), // fonte destacada //
                Size = new Size(250, 50), // tamanho definido //
                Location = new Point((this.Width - 250) / 2, 250), // centraliza horizontalmente //
                BackColor = Color.SteelBlue, // azul padrão //
                ForeColor = Color.White, // cor do texto para contraste //
                FlatStyle = FlatStyle.Flat, // estilo moderno //
                Cursor = Cursors.Hand // cursor indicador de clique //
            };
            btnEntrar.FlatAppearance.BorderSize = 0; // remove borda padrão //
            btnEntrar.Click += (s, e) => TrocarControle(new Entrar(this)); // troca para controle de login //

            // cria botão "Cadastrar" //
            var btnCadastrar = new Button
            {
                Text = "Cadastrar", // texto para novo usuário //
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(250, 50),
                Location = new Point((this.Width - 250) / 2, 320), // posiciona abaixo do botão entrar //
                BackColor = Color.SeaGreen, // verde característico //
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCadastrar.FlatAppearance.BorderSize = 0; // remove borda //
            btnCadastrar.Click += (s, e) => TrocarControle(new Cadastrar(this)); // troca para controle de cadastro //

            // cria label do título principal //
            var lblTitulo = new Label
            {
                Text = "CuritiBUS", // título principal da aplicação //
                Font = new Font("Segoe UI", 24, FontStyle.Bold), // fonte em destaque //
                ForeColor = Color.Teal, // cor sóbria para título //
                Size = new Size(500, 50),
                Location = new Point((this.Width - 500) / 2, 80), // centraliza no topo //
                TextAlign = ContentAlignment.MiddleCenter // alinha texto no centro //
            };

            // cria label do subtítulo explicativo //
            var lblSubtitulo = new Label
            {
                Text = "Sistema Integrado de Transporte Público", // texto explicativo //
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.Teal,
                Size = new Size(500, 30),
                Location = new Point((this.Width - 500) / 2, 140),
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(lblTitulo); // adiciona título ao formulário //
            this.Controls.Add(lblSubtitulo); // adiciona subtítulo explicativo //
            this.Controls.Add(btnEntrar); // adiciona botão de acesso //
            this.Controls.Add(btnCadastrar); // adiciona botão de cadastro //
        }
        #endregion

        #region método para exibir tela inicial limpa
        public void MostrarTelaInicial()
        {
            this.BackColor = Color.LightBlue; // mantém fundo consistente //
            InicializarComponentes(); // redesenha os controles da tela inicial //
        }
        #endregion

        #region método para trocar o controle exibido
        public void TrocarControle(UserControl controle)
        {
            this.Controls.Clear(); // remove todos os controles atuais //
            controle.Dock = DockStyle.Fill; // faz controle ocupar toda a área //
            this.Controls.Add(controle); // adiciona controle à interface //
        }
        #endregion

        #region método para abrir a tela de rastreamento passando o código da linha
        public void AbrirRastreamentoComLinha(string codigoLinha, string nomeLinha = null)
        {
            this.Controls.Clear();
            var rastreamento = new Rastreamento(this, codigoLinha, nomeLinha);
            rastreamento.Dock = DockStyle.Fill;
            this.Controls.Add(rastreamento);
        }
        #endregion
    }
}
