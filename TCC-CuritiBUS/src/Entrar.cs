using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace TCC_SENAI_CAUE_GUEDES
{
    public partial class Entrar : UserControl
    {
        #region campos privados
        private TextBox txtIdentificador, txtSenha;            // campos de entrada do usuário //
        private Label lblTitulo, lblIdentificador, lblSenha;   // labels associadas //
        private Button btnVoltar, btnFazerLogin, btnLimpar;    // botões de ação //
        private readonly Form1 formularioPrincipal;            // referência ao formulário principal //
        private Panel panelForm;                                // painel contendo o formulário //
        private ToolTip toolTipValidacao;                       // tooltip para mensagens de validação //
        #endregion

        #region construtor
        public Entrar(Form1 formPrincipal)
        {
            formularioPrincipal = formPrincipal;
            InicializarComponentes();                            // inicializa controles visuais //
            CentralizarComponentesNoPanel();                     // centraliza controles no painel //
            this.Resize += (s, e) => CentralizarComponentesNoPanel(); // reajusta centralização ao redimensionar //

            // evento para tratar Backspace na máscara do CPF //
            txtIdentificador.KeyDown += TxtIdentificador_KeyDown;
            txtIdentificador.TextChanged += AplicarMascaraCpfSeNumerico;
        }
        #endregion

        #region inicialização de componentes
        private void InicializarComponentes()
        {
            this.Dock = DockStyle.Fill;                          // ocupa todo espaço disponível //
            this.BackColor = Color.MediumTurquoise;              // cor de fundo //

            panelForm = new Panel
            {
                BackColor = Color.LightCyan,                     // fundo do painel //
                Size = new Size(520, 400),                        // tamanho fixo //
                BorderStyle = BorderStyle.FixedSingle             // borda simples //
            };

            lblTitulo = new Label
            {
                Text = "Entrar no Sistema",                       // texto do título //
                Font = new Font("Segoe UI", 20, FontStyle.Bold), // fonte grande e negrito //
                ForeColor = Color.MediumBlue,                     // cor do texto //
                AutoSize = true,                                  // ajusta tamanho automaticamente //
                TextAlign = ContentAlignment.MiddleCenter        // centralizado //
            };

            lblIdentificador = CriarLabel("CPF ou Email:");       // label para identificador //
            txtIdentificador = CriarTextBox();                     // textbox para entrada //
            txtIdentificador.Leave += ValidarIdentificador;        // valida na saída do controle //
            txtIdentificador.KeyDown += EnterPressAvancar;         // enter avança campo //

            lblSenha = CriarLabel("Senha:");                        // label senha //
            txtSenha = CriarTextBox();
            txtSenha.PasswordChar = '*';                            // oculta caracteres digitados //
            txtSenha.KeyDown += EnterPressAvancar;                  // enter avança campo //

            btnFazerLogin = new Button
            {
                Text = "Fazer Login",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(180, 40),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnFazerLogin.FlatAppearance.BorderSize = 0;
            btnFazerLogin.Click += BtnEntrar_Click;                // evento do botão entrar //

            btnLimpar = new Button
            {
                Text = "Limpar",
                Font = new Font("Segoe UI", 10),
                Size = new Size(80, 30),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.Click += (s, e) => LimparFormulario();        // limpa campos //

            btnVoltar = new Button
            {
                Text = "Voltar",
                FlatAppearance = {
                    BorderSize = 23232,                              // erro? mantive como está //
                },
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(80, 30),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                Cursor = Cursors.Hand
            };
            btnVoltar.FlatAppearance.BorderSize = 0;
            btnVoltar.Click += (s, e) => formularioPrincipal.MostrarTelaInicial(); // voltar tela inicial //

            toolTipValidacao = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 500,
                ShowAlways = true
            };

            // adiciona controles ao painel //
            panelForm.Controls.Add(lblTitulo);
            panelForm.Controls.Add(lblIdentificador);
            panelForm.Controls.Add(txtIdentificador);
            panelForm.Controls.Add(lblSenha);
            panelForm.Controls.Add(txtSenha);
            panelForm.Controls.Add(btnFazerLogin);
            panelForm.Controls.Add(btnLimpar);

            // adiciona painel e botão voltar ao UserControl //
            this.Controls.Add(panelForm);
            this.Controls.Add(btnVoltar);

            ConfigurarTabIndex();                                   // configura tabulação //
        }
        #endregion

        #region criar label e textbox reutilizáveis
        private Label CriarLabel(string texto) => new Label
        {
            Text = texto,
            Font = new Font("Segoe UI", 12),
            Size = new Size(130, 30),
            TextAlign = ContentAlignment.MiddleLeft
        };

        private TextBox CriarTextBox() => new TextBox
        {
            Font = new Font("Segoe UI", 12),
            Size = new Size(280, 30),
            BorderStyle = BorderStyle.FixedSingle
        };
        #endregion

        #region centralização dos componentes
        private void CentralizarComponentesNoPanel()
        {
            if (panelForm == null) return;                         // evita erro se painel não criado //

            panelForm.Location = new Point((this.Width - panelForm.Width) / 2, (this.Height - panelForm.Height) / 2);

            int posY = 40;
            int espacamento = 50;
            int campoComLabelWidth = lblIdentificador.Width + txtIdentificador.Width + 10;
            int startX = (panelForm.Width - campoComLabelWidth) / 2;

            lblTitulo.Location = new Point((panelForm.Width - lblTitulo.Width) / 2, posY);
            posY += 60;

            lblIdentificador.Location = new Point(startX, posY);
            txtIdentificador.Location = new Point(startX + lblIdentificador.Width + 10, posY);
            posY += espacamento;

            lblSenha.Location = new Point(startX, posY);
            txtSenha.Location = new Point(startX + lblSenha.Width + 10, posY);
            posY += espacamento;

            btnFazerLogin.Location = new Point((panelForm.Width - btnFazerLogin.Width) / 2 - 45, posY);
            btnLimpar.Location = new Point(btnFazerLogin.Right + 10, posY);

            btnVoltar.Location = new Point(10, 10);
        }
        #endregion

        #region validações e eventos
        private void ConfigurarTabIndex()
        {
            txtIdentificador.TabIndex = 0;
            txtSenha.TabIndex = 1;
            btnFazerLogin.TabIndex = 2;
            btnLimpar.TabIndex = 3;
            btnVoltar.TabIndex = 4;
        }

        // avança para próximo campo ao pressionar Enter //
        private void EnterPressAvancar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control atual = (Control)sender;

                if (atual == txtIdentificador)
                    txtSenha.Focus();
                else if (atual == txtSenha)
                    btnFazerLogin.Focus();
                else if (atual == btnFazerLogin)
                    BtnEntrar_Click(btnFazerLogin, EventArgs.Empty);

                e.Handled = e.SuppressKeyPress = true;
            }
        }

        // valida se identificador é CPF ou email válido //
        private void ValidarIdentificador(object sender, EventArgs e)
        {
            string identificador = txtIdentificador.Text.Trim();

            if (!string.IsNullOrEmpty(identificador))
            {
                bool entradaEhEmail = Regex.IsMatch(identificador, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                bool entradaEhCpf = ValidaCPF.IsCpf(identificador.Replace(".", "").Replace("-", ""));

                if (!entradaEhEmail && !entradaEhCpf)
                {
                    toolTipValidacao.Show("Informe um CPF ou Email válido", txtIdentificador, 0, -20, 2000);
                }
            }
        }

        // aplica máscara de CPF se texto for numérico //
        private void AplicarMascaraCpfSeNumerico(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            int posicaoCursor = txt.SelectionStart;
            string textoOriginal = txt.Text;

            // cancela máscara se for texto com letras ou '@' //
            if (Regex.IsMatch(textoOriginal, @"[a-zA-Z@]"))
                return;

            // remove tudo que não for número //
            string apenasNumeros = Regex.Replace(textoOriginal, "[^0-9]", "");

            // limita a 11 dígitos //
            if (apenasNumeros.Length > 11)
                apenasNumeros = apenasNumeros.Substring(0, 11);

            // monta máscara CPF conforme dígitos //
            string mascarado = "";

            for (int i = 0; i < apenasNumeros.Length; i++)
            {
                mascarado += apenasNumeros[i];

                if (i == 2 || i == 5)
                    mascarado += ".";
                else if (i == 8)
                    mascarado += "-";
            }

            // atualiza texto apenas se diferente //
            if (txt.Text != mascarado)
            {
                txt.TextChanged -= AplicarMascaraCpfSeNumerico;

                txt.Text = mascarado;
                txt.SelectionStart = txt.Text.Length;

                txt.TextChanged += AplicarMascaraCpfSeNumerico;
            }
        }

        // permite apagar ponto ou traço junto com caractere no Backspace //
        private void TxtIdentificador_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (e.KeyCode == Keys.Back && txt.SelectionStart > 0)
            {
                int pos = txt.SelectionStart;

                if (txt.Text[pos - 1] == '.' || txt.Text[pos - 1] == '-')
                {
                    txt.Text = txt.Text.Remove(pos - 1, 1);
                    txt.SelectionStart = pos - 1;
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region evento click do botão entrar
        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string identificador = txtIdentificador.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(identificador) || string.IsNullOrEmpty(senha))
            {
                toolTipValidacao.Show("Preencha todos os campos", txtIdentificador, 0, -20, 2000);
                return;
            }

            bool entradaEhEmail = Regex.IsMatch(identificador, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            bool entradaEhCpf = ValidaCPF.IsCpf(identificador.Replace(".", "").Replace("-", ""));

            if (!entradaEhEmail && !entradaEhCpf)
            {
                toolTipValidacao.Show("Informe um CPF ou Email válido", txtIdentificador, 0, -20, 2000);
                return;
            }

            if (!SenhaForte(senha))
            {
                toolTipValidacao.Show("A senha deve ter no mínimo 6 caracteres, com letra maiúscula, minúscula e número. Sem símbolos.", txtSenha, 0, -20, 3000);
                return;
            }

            try
            {
                using (var conexao = new MySqlConnection("server=localhost;database=transporte_curitiba;uid=root;pwd=;"))
                {
                    conexao.Open();

                    string sql = "SELECT nome FROM usuarios WHERE senha = @senha AND ";
                    sql += entradaEhEmail ? "email = @identificador" : "cpf = @identificador";

                    using (var comando = new MySqlCommand(sql, conexao))
                    {
                        string identificadorLimpo = entradaEhCpf ? identificador.Replace(".", "").Replace("-", "") : identificador;

                        comando.Parameters.AddWithValue("@identificador", identificadorLimpo);
                        comando.Parameters.AddWithValue("@senha", senha);

                        var nomeUsuario = comando.ExecuteScalar()?.ToString();

                        if (!string.IsNullOrEmpty(nomeUsuario))
                        {
                            toolTipValidacao.Show("Login realizado com sucesso!", txtSenha, 0, -30, 1500);
                            formularioPrincipal.Controls.Clear();
                            formularioPrincipal.Controls.Add(new MenuInicial(formularioPrincipal, nomeUsuario));
                        }
                        else
                        {
                            toolTipValidacao.Show("Credenciais inválidas", txtSenha, 0, -20, 2000);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro ao acessar banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region validação de senha forte (padrão CADASTRAR)
        private bool SenhaForte(string senha)
        {
            if (senha.Length < 6) return false;

            bool temMaiuscula = Regex.IsMatch(senha, "[A-Z]");
            bool temMinuscula = Regex.IsMatch(senha, "[a-z]");
            bool temNumero = Regex.IsMatch(senha, "[0-9]");
            bool semSimbolos = !Regex.IsMatch(senha, "[^a-zA-Z0-9]");

            return temMaiuscula && temMinuscula && temNumero && semSimbolos;
        }
        #endregion

        #region limpar formulário
        private void LimparFormulario()
        {
            txtIdentificador.Clear();
            txtSenha.Clear();
            txtIdentificador.Focus();
        }
        #endregion
    }
}
