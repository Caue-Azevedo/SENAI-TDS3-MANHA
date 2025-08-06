using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TCC_SENAI_CAUE_GUEDES
{
    // a classe Validacoes oferece um conjunto de métodos para validar dados comuns //
    public static class Validacoes
    {
        #region validação de e-mail

        // verifica se o e-mail segue um padrão válido de estrutura com uso de regex //
        public static bool EmailValido(string email)
        {
            try
            {
                // usa uma expressão regular para validar o formato do e-mail //
                return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            }
            catch (ArgumentException regexEx) // Alterado de RegexParseException para ArgumentException //
            {
                // captura erros na própria expressão regular, embora improvável com uma regex fixa //
                MessageBox.Show($"erro na expressão regular de e-mail: {regexEx.Message}", "erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // captura qualquer outra exceção inesperada durante a validação //
                MessageBox.Show($"erro inesperado ao validar e-mail: {ex.Message}", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region validação de cpf

        // realiza a validação do cpf com base nos dígitos verificadores e estrutura correta //
        public static bool CpfValido(string cpf)
        {
            try
            {
                // pesos aplicados ao primeiro cálculo //
                int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                // pesos aplicados ao segundo cálculo //
                int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                // remove pontos e traço do cpf //
                cpf = cpf.Replace(".", "").Replace("-", "").Trim();

                // valida tamanho //
                if (cpf.Length != 11) return false;

                // rejeita sequência de dígitos iguais //
                if (new string(cpf[0], cpf.Length) == cpf) return false;

                // extrai os nove primeiros dígitos //
                string tempCpf = cpf.Substring(0, 9);
                int soma = 0;

                // calcula a soma ponderada dos nove dígitos //
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                int resto = soma % 11;
                resto = (resto < 2) ? 0 : 11 - resto;

                string digito = resto.ToString();
                tempCpf += digito;
                soma = 0;

                // repete o processo com 10 dígitos //
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;
                resto = (resto < 2) ? 0 : 11 - resto;

                digito += resto.ToString();

                // verifica os dois últimos dígitos //
                return cpf.EndsWith(digito);
            }
            catch (FormatException fEx)
            {
                // captura erro se a string não puder ser convertida em int //
                MessageBox.Show($"formato inválido de cpf: {fEx.Message}", "erro de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (OverflowException oEx)
            {
                // captura erro se a conversão numérica resultar em overflow //
                MessageBox.Show($"o valor do cpf é muito grande: {oEx.Message}", "erro de overflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (ArgumentOutOfRangeException argEx)
            {
                // captura erros de índice ao acessar substrings ou arrays //
                MessageBox.Show($"erro de argumento na validação de cpf: {argEx.Message}", "erro interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // em caso de erro genérico, CPF é inválido //
                MessageBox.Show($"ocorreu um erro inesperado ao validar cpf: {ex.Message}", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region validação de senha

        // verifica se a senha possui uma estrutura forte baseada em múltiplos critérios //
        public static bool SenhaValida(string senha)
        {
            try
            {
                /*
                    Requisitos da senha:
                    - Mínimo de 8 caracteres
                    - Pelo menos uma letra maiúscula
                    - Pelo menos uma letra minúscula
                    - Pelo menos um número
                    - Pelo menos um caractere especial
                */
                // utiliza regex para verificar todos os critérios de complexidade da senha //
                return Regex.IsMatch(senha, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#+=._-])[A-Za-z\d@$!%*?&#+=._-]{8,}$");
            }
            catch (ArgumentException regexEx) // Alterado de RegexParseException para ArgumentException //
            {
                // captura erros na própria expressão regular, caso seja modificada incorretamente //
                MessageBox.Show($"erro na expressão regular de senha: {regexEx.Message}", "erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // captura qualquer outra exceção inesperada durante a validação //
                MessageBox.Show($"erro inesperado ao validar senha: {ex.Message}", "erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
    }
}