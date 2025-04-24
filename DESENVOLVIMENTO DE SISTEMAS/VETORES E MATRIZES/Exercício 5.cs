using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");

            CalculadoraVetores calculadora = new CalculadoraVetores();
            calculadora.LerEntradaVetores();

            Console.WriteLine("\n| Resultados das operações:");
            Console.WriteLine("| Soma:           " + string.Join(", ", calculadora.Operar('+')));
            Console.WriteLine("| Subtração:      " + string.Join(", ", calculadora.Operar('-')));
            Console.WriteLine("| Multiplicação:  " + string.Join(", ", calculadora.Operar('*')));
            Console.WriteLine("| Divisão:        " + string.Join(", ", calculadora.Operar('/')));

            Console.WriteLine("+-------------------------------------------------+\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class CalculadoraVetores
{
    private double[] vet1 = new double[5];
    private double[] vet2 = new double[5];

    public void LerEntradaVetores()
    {
        for (int i = 0; i < 5; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Digite o valor da posição {i} do vetor 1: ");
                    if (!double.TryParse(Console.ReadLine(), out vet1[i]))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                        continue;
                    }

                    Console.Write($"| Digite o valor da posição {i} do vetor 2: ");
                    if (!double.TryParse(Console.ReadLine(), out vet2[i]))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                        continue;
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler os valores: {ex.Message}");
                }
            }
        }
    }

    public double[] Operar(char operacao)
    {
        double[] resultado = new double[5];

        for (int i = 0; i < 5; i++)
        {
            switch (operacao)
            {
                case '+':
                    resultado[i] = vet1[i] + vet2[i];
                    break;
                case '-':
                    resultado[i] = vet1[i] - vet2[i];
                    break;
                case '*':
                    resultado[i] = vet1[i] * vet2[i];
                    break;
                case '/':
                    resultado[i] = vet2[i] != 0 ? vet1[i] / vet2[i] : double.NaN;
                    break;
            }
        }

        return resultado;
    }
}
