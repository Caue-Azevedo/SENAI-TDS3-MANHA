using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------+");

            double[] numeros = LerEntradaVetores();

            double soma = CalcularSoma(numeros);
            double subtracao = CalcularSubtracao(numeros);
            double multiplicacao = CalcularMultiplicacao(numeros);
            double divisao = CalcularDivisao(numeros);

            Console.WriteLine($"| Soma dos elementos: {soma}");
            Console.WriteLine($"| Subtração dos elementos: {subtracao}");
            Console.WriteLine($"| Multiplicação dos elementos: {multiplicacao}");
            Console.WriteLine($"| Divisão dos elementos: {divisao}");

            Console.WriteLine("+---------------------------------------+\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    static double[] LerEntradaVetores()
    {
        double[] vet1 = new double[5];
        double[] vet2 = new double[5];
        double[] resultados = new double[5];

        for (int i = 0; i < 5; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Digite o valor da posição {i} do vetor 1: ");
                    string entradaVet1 = Console.ReadLine();
                    if (!double.TryParse(entradaVet1, out double vetor1))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                        continue;
                    }

                    Console.Write($"| Digite o valor da posição {i} do vetor 2: ");
                    string entradaVet2 = Console.ReadLine();
                    if (!double.TryParse(entradaVet2, out double vetor2))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                        continue;
                    }

                    vet1[i] = vetor1;
                    vet2[i] = vetor2;
                    resultados[i] = vetor1 + vetor2;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler os valores: {ex.Message}");
                }
            }
        }

        return resultados;
    }

    static double CalcularSoma(double[] valores)
    {
        double soma = 0;
        foreach (var valor in valores)
        {
            soma += valor;
        }
        return soma;
    }

    static double CalcularSubtracao(double[] valores)
    {
        double subtracao = valores[0];
        for (int i = 1; i < valores.Length; i++)
        {
            subtracao -= valores[i];
        }
        return subtracao;
    }

    static double CalcularMultiplicacao(double[] valores)
    {
        double multiplicacao = 1;
        foreach (var valor in valores)
        {
            multiplicacao *= valor;
        }
        return multiplicacao;
    }

    static double CalcularDivisao(double[] valores)
    {
        double divisao = valores[0];
        for (int i = 1; i < valores.Length; i++)
        {
            if (valores[i] != 0)
                divisao /= valores[i];
            else
                return double.NaN;
        }
        return divisao;
    }
}
