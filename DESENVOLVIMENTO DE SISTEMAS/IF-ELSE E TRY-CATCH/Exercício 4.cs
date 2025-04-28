using System;
using System.Threading;

// Exceção personalizada
class IdadeInvalidaException : Exception
{
    public IdadeInvalidaException(string mensagem) : base(mensagem) { }
}

class ProgramaValidacaoIdade
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarCabecalho();

            try
            {
                int idade = LerIdade();
                MostrarMensagem($"Idade registrada: {idade} anos.");
            }
            catch (IdadeInvalidaException ex)
            {
                MostrarErro(ex.Message);
            }
            catch (FormatException)
            {
                MostrarErro("Formato inválido. Digite apenas números.");
            }

            if (!DesejaContinuar())
            {
                MostrarSaida();
                break;
            }
        }
    }

    static void MostrarCabecalho()
    {
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine("|           VALIDAÇÃO DE IDADE             |");
        Console.WriteLine("+------------------------------------------+");
    }

    static int LerIdade()
    {
        Console.Write("| Digite sua idade: ");
        string entrada = Console.ReadLine();
        
        if (!int.TryParse(entrada, out int idade))
        {
            throw new FormatException();
        }

        if (idade < 0 || idade > 120)
        {
            throw new IdadeInvalidaException("Idade inválida. Informe entre 0 e 120.");
        }

        return idade;
    }

    static bool DesejaContinuar()
    {
        Console.Write("\n| Deseja validar outra idade? (s/n): ");
        string resposta = Console.ReadLine().ToLower();
        return resposta == "s";
    }

    static void MostrarMensagem(string mensagem)
    {
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine($"| {mensagem.PadRight(40)}|");
        Console.WriteLine("+------------------------------------------+");
        Thread.Sleep(1500);
    }

    static void MostrarErro(string mensagem)
    {
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine("|                   ERRO!                  |");
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine($"| {mensagem.PadRight(40)}|");
        Console.WriteLine("+------------------------------------------+");
        Thread.Sleep(1500);
    }

    static void MostrarSaida()
    {
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine("|                 Saindo...                |");
        Console.WriteLine("+------------------------------------------+");
        Thread.Sleep(1000);
    }
}
