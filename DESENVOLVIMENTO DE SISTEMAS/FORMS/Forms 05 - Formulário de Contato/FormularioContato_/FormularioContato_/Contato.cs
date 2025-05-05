using System.Text.RegularExpressions;

namespace FormularioContato_
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public bool ReceberNews { get; set; }

        public bool Validar(out string erro)
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                erro = "Nome é obrigatório!";
                return false;
            }

            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                erro = "Por favor, insira um e-mail válido.";
                return false;
            }

            if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$"))
            {
                erro = "Por favor, insira um número de telefone válido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Assunto))
            {
                erro = "Assunto é obrigatório!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Mensagem))
            {
                erro = "Mensagem é obrigatória!";
                return false;
            }

            erro = null;
            return true;
        }

        public override string ToString()
        {
            return $"   Nome: {Nome}\n   Email: {Email}\n   Telefone: {Telefone}\n   Assunto: {Assunto}\n   Mensagem: {Mensagem}\n   Receber NewsLetter: {(ReceberNews ? "Sim" : "Não")}";
        }
    }
}
