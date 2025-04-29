using System;
using System.Linq;
using System.Threading;

class ProgramaCalculoMedia
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarCabecalho();

            try
            {
                // Solicitar e processar a lista de números
                string entrada = LerNumeros();
                double media = CalcularMedia(entrada);
                MostrarMensagem($"A média dos números é: {media:F2}");
            }
            catch (ArgumentNullException)
            {
                MostrarErro("Entrada vazia. Por favor, digite uma lista de números.");
            }
            catch (FormatException)
            {
                MostrarErro("Formato inválido. Certifique-se de digitar apenas números separados por vírgula.");
            }
            catch (OverflowException)
            {
                MostrarErro("Número muito grande ou muito pequeno. Tente novamente.");
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
        Console.WriteLine("|          CÁLCULO DE MÉDIA DE NÚMEROS     |");
        Console.WriteLine("+------------------------------------------+");
    }

    static string LerNumeros()
    {
        Console.Write("| Digite uma lista de números separados por vírgula: ");
        string entrada = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(entrada))
        {
            throw new ArgumentNullException();
        }

        return entrada;
    }

    static double CalcularMedia(string entrada)
    {
        string[] numerosString = entrada.Split(',');

        double soma = 0;
        int contador = 0;

        foreach (var numero in numerosString)
        {
            if (double.TryParse(numero.Trim(), out double numeroConvertido))
            {
                soma += numeroConvertido;
                contador++;
            }
            else
            {
                throw new FormatException();
            }
        }

        if (contador == 0)
        {
            throw new ArgumentNullException();
        }

        return soma / contador;
    }

    static bool DesejaContinuar()
    {
        Console.Write("\n| Deseja calcular outra média? (s/n): ");
        string resposta = Console.ReadLine().ToLower();
        return resposta == "s";
    }

    static void MostrarMensagem(string mensagem)
    {
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine($"| {mensagem} |");
        Console.WriteLine("+------------------------------------------+");
        Thread.Sleep(1500);
    }

    static void MostrarErro(string mensagem)
    {
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine("|                   ERRO!                  |");
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine($"| {mensagem}     |");
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
