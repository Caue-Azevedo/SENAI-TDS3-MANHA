using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class Cadastrar : UserControl
    {
        #region cabeçalho e campos iniciais
        // controles visuais do formulário de cadastro //
        private TextBox txtNome, txtEmail, txtCPF, txtSenha;
        private Label lblNome, lblEmail, lblCPF, lblSenha, lblTitulo;
        private Button btnVoltar, btnCadastrar, btnLimpar;
        private readonly Form1 formularioPrincipal; // referência ao formulário principal //
        private Panel panelForm;                    // painel que contém os controles do formulário //
        private ToolTip toolTipSenha;               // dica para validação da senha //
        #endregion

        #region construtor e inicialização
        // construtor recebe a instância do formulário principal //
        public Cadastrar(Form1 formPrincipal)
        {
            formularioPrincipal = formPrincipal;
            InicializarComponentes();          // cria e configura controles visuais //
            AdicionarToolTipSenha();           // configura dica da senha //
            ConfigurarEventosTeclado();        // ajusta ordem de tabulação //
            CentralizarComponentesNoPanel();   // posiciona controles no painel //
            this.Resize += (s, e) => CentralizarComponentesNoPanel(); // centraliza ao redimensionar //
        }
        #endregion

        #region inicialização de componentes
        // cria e adiciona controles no formulário e painel //
        private void InicializarComponentes()
        {
            this.Dock = DockStyle.Fill;              // ocupa todo o espaço do container //
            this.BackColor = Color.MediumTurquoise; // cor de fundo do UserControl //

            panelForm = new Panel
            {
                BackColor = Color.LightCyan,          // fundo claro para destaque //
                Size = new Size(520, 480),             // tamanho fixo do painel //
                BorderStyle = BorderStyle.FixedSingle  // borda fina ao redor do painel //
            };

            // cria rótulos e caixas de texto com eventos personalizados //
            lblTitulo = CriarLabel("Cadastro de Usuário", 20, true);

            lblNome = CriarLabel("Nome:");
            txtNome = CriarTextBox();
            txtNome.KeyPress += BloquearCaracteresInvalidos; // bloqueia caracteres proibidos //
            txtNome.KeyDown += EnterPressAvancar;             // avança com Enter //

            lblEmail = CriarLabel("Email:");
            txtEmail = CriarTextBox();
            txtEmail.KeyPress += BloquearCaracteresInvalidos; // bloqueia caracteres proibidos //
            txtEmail.KeyDown += EnterPressAvancar;             // avança com Enter //
            txtEmail.Leave += (s, e) => ValidarEmail();        // valida email ao sair do campo //

            lblCPF = CriarLabel("CPF:");
            txtCPF = CriarTextBox();
            txtCPF.KeyPress += ValidarCPFTeclado;              // formata e valida entrada de cpf //
            txtCPF.Leave += (s, e) => ValidarCPF();            // valida cpf ao sair do campo //
            txtCPF.MaxLength = 14;                              // limite máximo de caracteres //
            txtCPF.KeyDown += EnterPressAvancar;                // avança com Enter //

            lblSenha = CriarLabel("Senha:");
            txtSenha = CriarTextBox(password: true);           // caixa de senha (oculta texto) //
            txtSenha.KeyPress += BloquearCaracteresInvalidos;  // bloqueia caracteres proibidos //
            txtSenha.KeyDown += EnterPressAvancar;              // avança com Enter //
            txtSenha.TextChanged += ValidarSenhaEmTempoReal;   // valida senha em tempo real //

            btnCadastrar = CriarBotao("Cadastrar", Color.MediumSeaGreen);
            btnCadastrar.Click += BtnCadastrar_Click;          // evento de cadastro no banco //

            btnLimpar = CriarBotao("Limpar", Color.LightGray, 80, 30);
            btnLimpar.Click += (s, e) => LimparCampos();        // limpa campos do formulário //

            btnVoltar = CriarBotao("Voltar", Color.LightCoral, 80, 30);
            btnVoltar.Click += (s, e) => formularioPrincipal.MostrarTelaInicial(); // volta à tela principal //

            // adiciona controles ao painel //
            panelForm.Controls.AddRange(new Control[] {
                lblTitulo, lblNome, txtNome,
                lblEmail, txtEmail,
                lblCPF, txtCPF,
                lblSenha, txtSenha,
                btnCadastrar, btnLimpar
            });

            // adiciona painel e botão voltar ao UserControl //
            this.Controls.Add(panelForm);
            this.Controls.Add(btnVoltar);
        }
        #endregion

        #region criação de controles auxiliares
        // método para criar label customizada //
        private Label CriarLabel(string texto, int tamanhoFonte = 12, bool bold = false) =>
            new Label
            {
                Text = texto,
                Font = new Font("Segoe UI", tamanhoFonte, bold ? FontStyle.Bold : FontStyle.Regular),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft
            };

        // método para criar textbox customizada //
        private TextBox CriarTextBox(bool password = false) =>
            new TextBox
            {
                Font = new Font("Segoe UI", 12),
                Size = new Size(280, 30),
                BorderStyle = BorderStyle.FixedSingle,
                UseSystemPasswordChar = password  // oculta texto se for senha //
            };

        // método para criar botão customizado //
        private Button CriarBotao(string texto, Color cor, int largura = 180, int altura = 40) =>
            new Button
            {
                Text = texto,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(largura, altura),
                BackColor = cor,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                Cursor = Cursors.Hand
            };
        #endregion

        #region centralização visual dos controles
        // posiciona os controles centralizados dentro do painel //
        private void CentralizarComponentesNoPanel()
        {
            if (panelForm == null) return;

            // centraliza o painel dentro do UserControl //
            panelForm.Location = new Point((this.Width - panelForm.Width) / 2, (this.Height - panelForm.Height) / 2);

            int posY = 30;                 // posição vertical inicial //
            int espacamento = 50;          // espaço entre controles vertical //
            int startX = (panelForm.Width - (txtNome.Width + 90)) / 2; // posição horizontal dos labels //

            // posiciona título centralizado //
            lblTitulo.Location = new Point((panelForm.Width - lblTitulo.Width) / 2, posY);
            posY += 60;

            // posiciona cada label e textbox com espaçamento definido //
            lblNome.Location = new Point(startX, posY);
            txtNome.Location = new Point(startX + 90, posY);
            posY += espacamento;

            lblEmail.Location = new Point(startX, posY);
            txtEmail.Location = new Point(startX + 90, posY);
            posY += espacamento;

            lblCPF.Location = new Point(startX, posY);
            txtCPF.Location = new Point(startX + 90, posY);
            posY += espacamento;

            lblSenha.Location = new Point(startX, posY);
            txtSenha.Location = new Point(startX + 90, posY);
            posY += espacamento + 10;

            // posiciona botões cadastrar e limpar lado a lado //
            btnCadastrar.Location = new Point(startX, posY);
            btnLimpar.Location = new Point(startX + btnCadastrar.Width + 20, posY);
            btnVoltar.Location = new Point(10, 10); // botão voltar no canto superior esquerdo //
        }
        #endregion

        #region eventos e validações de campos
        // configura dica (tooltip) para senha com regras de validação //
        private void AdicionarToolTipSenha()
        {
            toolTipSenha = new ToolTip
            {
                AutoPopDelay = 5000, // tempo que tooltip fica visível //
                InitialDelay = 500,  // atraso antes de aparecer //
                ReshowDelay = 500,   // atraso para reaparecer //
                ShowAlways = true
            };

            toolTipSenha.SetToolTip(txtSenha, "a senha deve ter no mínimo 6 caracteres, incluindo uma maiúscula, uma minúscula e um número. não são permitidos caracteres especiais");
        }

        // valida senha conforme usuário digita e atualiza tooltip //
        private void ValidarSenhaEmTempoReal(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;
            string mensagem = "";

            if (senha.Length > 0 && senha.Length < 6)
            {
                mensagem = "senha muito curta! mínimo 6 caracteres";
            }
            else if (senha.Length >= 6)
            {
                bool temMaiuscula = Regex.IsMatch(senha, "[A-Z]");
                bool temMinuscula = Regex.IsMatch(senha, "[a-z]");
                bool temNumero = Regex.IsMatch(senha, "[0-9]");
                bool temCaractereInvalido = Regex.IsMatch(senha, "[^a-zA-Z0-9]");

                if (temCaractereInvalido)
                {
                    mensagem = "a senha não pode conter símbolos ou caracteres especiais";
                }
                else if (!temMaiuscula || !temMinuscula || !temNumero)
                {
                    mensagem = "a senha deve conter ao menos: uma maiúscula, uma minúscula e um número";
                }
                else
                {
                    mensagem = "senha válida";
                }
            }

            toolTipSenha.SetToolTip(txtSenha, mensagem);
        }

        // valida se a senha cumpre os critérios mínimos de segurança //
        private bool ValidarSenhaSegura(string senha)
        {
            if (senha.Length < 6) return false;

            bool temMaiuscula = Regex.IsMatch(senha, "[A-Z]");
            bool temMinuscula = Regex.IsMatch(senha, "[a-z]");
            bool temNumero = Regex.IsMatch(senha, "[0-9]");
            bool semSimbolos = !Regex.IsMatch(senha, "[^a-zA-Z0-9]");

            return temMaiuscula && temMinuscula && temNumero && semSimbolos;
        }

        // valida formato do email e exibe tooltip de aviso //
        private void ValidarEmail()
        {
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !Validacoes.EmailValido(email))
            {
                toolTipSenha.Show("formato de e-mail inválido", txtEmail, 0, -20, 2000);
            }
        }

        // valida CPF formatado e exibe tooltip de aviso //
        private void ValidarCPF()
        {
            string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
            if (!string.IsNullOrEmpty(cpf) && !Validacoes.CpfValido(cpf))
            {
                toolTipSenha.Show("cpf inválido", txtCPF, 0, -20, 2000);
            }
        }

        // valida entrada do teclado no campo CPF, formatando conforme digitação //
        private void ValidarCPFTeclado(object sender, KeyPressEventArgs e)
        {
            // permite apenas dígitos e controles (ex: backspace) //
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            string texto = txtCPF.Text;

            // insere pontos e hífen automaticamente nas posições corretas //
            if (char.IsDigit(e.KeyChar))
            {
                if (texto.Length == 3 || texto.Length == 7)
                {
                    txtCPF.Text += ".";
                    txtCPF.SelectionStart = txtCPF.Text.Length; // posiciona cursor no fim //
                }
                else if (texto.Length == 11)
                {
                    txtCPF.Text += "-";
                    txtCPF.SelectionStart = txtCPF.Text.Length;
                }
            }
        }

        // bloqueia caracteres inválidos específicos, ex: '#', e mostra aviso //
        private void BloquearCaracteresInvalidos(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#')
            {
                e.Handled = true; // cancela a inserção do caractere //
                toolTipSenha.Show("caractere '#' não é permitido", (Control)sender, 0, -20, 1000);
            }
        }

        // permite avançar o foco para o próximo controle ao pressionar Enter //
        private void EnterPressAvancar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control atual = (Control)sender;

                if (atual == txtNome)
                    txtEmail.Focus();
                else if (atual == txtEmail)
                    txtCPF.Focus();
                else if (atual == txtCPF)
                    txtSenha.Focus();
                else if (atual == txtSenha)
                    btnCadastrar.Focus();

                e.Handled = e.SuppressKeyPress = true; // evita som do beep padrão //
            }
        }

        // define a ordem de tabulação dos controles //
        private void ConfigurarEventosTeclado()
        {
            txtNome.TabIndex = 0;
            txtEmail.TabIndex = 1;
            txtCPF.TabIndex = 2;
            txtSenha.TabIndex = 3;
            btnCadastrar.TabIndex = 4;
            btnLimpar.TabIndex = 5;
            btnVoltar.TabIndex = 6;
        }
        #endregion

        #region botão cadastrar e integração com banco de dados
        // evento disparado ao clicar no botão cadastrar //
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            // obtém e limpa os valores digitados nos campos //
            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cpf = txtCPF.Text.Replace(".", "").Replace("-", "").Trim();
            string senha = txtSenha.Text.Trim();

            // valida preenchimento de todos os campos //
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("preencha todos os campos antes de prosseguir!", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // valida formato do email //
            if (!Validacoes.EmailValido(email))
            {
                MessageBox.Show("email inválido.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // valida CPF //
            if (!Validacoes.CpfValido(cpf))
            {
                MessageBox.Show("cpf inválido.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // valida a segurança da senha //
            if (!ValidarSenhaSegura(senha))
            {
                MessageBox.Show("a senha deve ter no mínimo 6 caracteres e conter pelo menos uma letra maiúscula, uma minúscula e um número. caracteres especiais não são permitidos.", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // obtém conexão com o banco de dados //
                using (var conn = Database.GetConnection())
                {
                    // verifica se email já está cadastrado //
                    string sqlEmail = "SELECT COUNT(*) FROM usuarios WHERE email = @Email";
                    using (var cmdEmail = new MySqlCommand(sqlEmail, conn))
                    {
                        cmdEmail.Parameters.AddWithValue("@Email", email);
                        int countEmail = Convert.ToInt32(cmdEmail.ExecuteScalar());
                        if (countEmail > 0)
                        {
                            MessageBox.Show("email já cadastrado.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtEmail.Focus();
                            return;
                        }
                    }

                    // verifica se CPF já está cadastrado //
                    string sqlCpf = "SELECT COUNT(*) FROM usuarios WHERE cpf = @Cpf";
                    using (var cmdCpf = new MySqlCommand(sqlCpf, conn))
                    {
                        cmdCpf.Parameters.AddWithValue("@Cpf", cpf);
                        int countCpf = Convert.ToInt32(cmdCpf.ExecuteScalar());
                        if (countCpf > 0)
                        {
                            MessageBox.Show("cpf já cadastrado.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCPF.Focus();
                            return;
                        }
                    }

                    // insere novo usuário no banco de dados //
                    string sqlInsert = "INSERT INTO usuarios (nome, email, cpf, senha) VALUES (@Nome, @Email, @Cpf, @Senha)";
                    using (var cmdInsert = new MySqlCommand(sqlInsert, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@Nome", nome);
                        cmdInsert.Parameters.AddWithValue("@Email", email);
                        cmdInsert.Parameters.AddWithValue("@Cpf", cpf);
                        cmdInsert.Parameters.AddWithValue("@Senha", senha);

                        int resultado = cmdInsert.ExecuteNonQuery();
                        if (resultado > 0)
                        {
                            MessageBox.Show("usuário cadastrado com sucesso!", "sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            formularioPrincipal.MostrarTelaInicial();
                        }
                        else
                        {
                            MessageBox.Show("erro ao cadastrar o usuário.", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("erro no banco de dados: " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro inesperado: " + ex.Message, "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region método para limpar os campos
        
        // método para limpar todos os campos e focar no nome //
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtCPF.Text = "";
            txtSenha.Text = "";
            txtNome.Focus();
        }

        #endregion
    }
}