using System;

namespace TCC_SENAI_CAUE_GUEDES
{
    public static class ValidaCPF
    {
        #region método público

        // valida a estrutura de um cpf com base em regras oficiais de cálculo //
        public static bool IsCpf(string cpf)
        {
            try
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }; // pesos do primeiro dígito //
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 }; // pesos do segundo dígito //

                string tempCpf, digito;
                int soma, resto;

                cpf = cpf.Trim().Replace(".", "").Replace("-", ""); // remove pontuação e espaços //

                if (cpf.Length != 11) return false; // cpf válido deve ter 11 dígitos //

                // rejeita sequência com todos os dígitos iguais //
                if (new string(cpf[0], cpf.Length) == cpf)
                    return false;

                tempCpf = cpf.Substring(0, 9); // obtém os nove primeiros dígitos //
                soma = 0;

                // calcula o primeiro dígito verificador com base nos nove dígitos //
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;
                resto = (resto < 2) ? 0 : 11 - resto;

                digito = resto.ToString();
                tempCpf += digito; // adiciona o primeiro dígito ao cpf temporário //
                soma = 0;

                // calcula o segundo dígito usando os dez primeiros caracteres //
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;
                resto = (resto < 2) ? 0 : 11 - resto;

                digito += resto.ToString(); // completa com o segundo dígito //

                // retorna true se os dois dígitos finais forem válidos //
                return cpf.EndsWith(digito);
            }
            catch
            {
                // se ocorrer erro durante a validação, considera o cpf inválido //
                return false;
            }
        }

        #endregion
    }
}