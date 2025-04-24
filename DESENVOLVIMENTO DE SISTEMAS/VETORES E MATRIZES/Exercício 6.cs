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
            calculadora.LerEntradaVetor();

            Console.WriteLine("\n| Vetor original:");
            Console.WriteLine("| " + string.Join(", ", calculadora.Vetor));

            calculadora.TrocarElementos();

            Console.WriteLine("\n| Vetor após as trocas:");
            Console.WriteLine("| " + string.Join(", ", calculadora.Vetor));

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
    public int[] Vetor { get; private set; } = new int[20];

    public void LerEntradaVetor()
    {
        for (int i = 0; i < 20; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Digite o valor da posição {i} do vetor: ");
                    if (!int.TryParse(Console.ReadLine(), out Vetor[i]))
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

    public void TrocarElementos()
    {
        int meio = Vetor.Length / 2;
        for (int i = 0; i < meio; i++)
        {
            int temp = Vetor[i];
            Vetor[i] = Vetor[Vetor.Length - 1 - i];
            Vetor[Vetor.Length - 1 - i] = temp;
        }
    }
}
