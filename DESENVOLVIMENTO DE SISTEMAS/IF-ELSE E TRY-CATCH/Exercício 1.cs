using System;
using System.Threading;

class Calculadora
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------+");
            Console.WriteLine("|               CALCULADORA                |");
            Console.WriteLine("+------------------------------------------+");

            double numero1 = LerNumero("| Digite o primeiro número: ");
            double numero2 = LerNumero("| Digite o segundo número : ");
            string operacao = LerOperacao("| Digite a operação (+, -, *, /): ");

            try
            {
                double resultado = Calcular(numero1, numero2, operacao);

                Console.WriteLine("+------------------------------------------+");
                Console.WriteLine($"|  Resultado: {resultado} ");
                Console.WriteLine("+------------------------------------------+");
            }
            catch (DivideByZeroException ex)
            {
                MostrarErro(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MostrarErro(ex.Message);
            }

            Console.Write("\n| Deseja fazer outra operação? (s/n): ");
            string continuar = Console.ReadLine().ToLower();
            if (continuar != "s")
            {
                Console.WriteLine("\n+------------------------------------------+");
                Console.WriteLine("|                 Saindo...                |");
                Console.WriteLine("+------------------------------------------+");
                Thread.Sleep(1000);
                break;
            }
        }
    }

    static double LerNumero(string mensagem)
    {
        double numero;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out numero))
            {
                return numero;
            }
            else
            {
                MostrarErro("Você digitou um número inválido.         ");
            }
        }
    }

    static string LerOperacao(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string op = Console.ReadLine();
            if (op == "+" || op == "-" || op == "*" || op == "/")
            {
                return op;
            }
            else
            {
                MostrarErro("Operação inválida. Use apenas +, -, *, /.");
            }
        }
    }

    static double Calcular(double n1, double n2, string operacao)
    {
        return operacao switch
        {
            "+" => n1 + n2,
            "-" => n1 - n2,
            "*" => n1 * n2,
            "/" => n2 != 0 ? n1 / n2 : throw new DivideByZeroException("Não é possível dividir por zero.         "),
            _ => throw new ArgumentException("Operação inválida.")
        };
    }

    static void MostrarErro(string mensagem)
    {
        Console.WriteLine("+------------------------------------------+\n");
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine("|                   ERRO!                  |");
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine($"| {mensagem}|");
        Console.WriteLine("+------------------------------------------+\n");
        Thread.Sleep(1500);
    }
}
