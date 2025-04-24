using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("+---------------------------------------+");
            double[] numeros = LerNumeros();
            double media = CalcularMedia(numeros);
            Console.WriteLine("+---------------------------------------+\n");
            Console.WriteLine("\n+---------------------------------------+");
            Console.WriteLine($"| Média dos números: {media:F2}");
            Console.WriteLine("+---------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    static double[] LerNumeros()
    {
        int quantidadeNumeros;
        while (true)
        {
            Console.Write("| Quantos números você quer inserir?: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out quantidadeNumeros) && quantidadeNumeros > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("| Valor inválido. Digite um número inteiro positivo.");
            }
        }

        double[] numeros = new double[quantidadeNumeros];

        for (int i = 0; i < quantidadeNumeros; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Digite o {i + 1}º número: ");
                    string entrada = Console.ReadLine();

                    if (double.TryParse(entrada, out double numero))
                    {
                        numeros[i] = numero;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler o número: {ex.Message}");
                }
            }
        }

        return numeros;
    }

    static double CalcularMedia(double[] numeros)
    {
        double soma = 0;
        for (int i = 0; i < numeros.Length; i++)
        {
            soma += numeros[i];
        }
        return numeros.Length > 0 ? soma / numeros.Length : 0;
    }
}
