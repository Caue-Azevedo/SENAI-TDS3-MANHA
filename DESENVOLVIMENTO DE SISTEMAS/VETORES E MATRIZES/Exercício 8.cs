using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");

            VetorDividido vetorDividido = new VetorDividido();
            vetorDividido.LerVetor();
            vetorDividido.DividirVetor();
            vetorDividido.ImprimirVetores();

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class VetorDividido
{
    private int[] vetorOriginal = new int[10];
    private int[] vetorImpares = new int[5];
    private int[] vetorPares = new int[5];

    public void LerVetor()
    {
        Console.WriteLine("| Digite 10 números inteiros:");
        for (int i = 0; i < 10; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Posição {i + 1}: ");
                    if (!int.TryParse(Console.ReadLine(), out vetorOriginal[i]))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número inteiro.");
                        continue;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler o número: {ex.Message}");
                }
            }
        }
    }

    public void DividirVetor()
    {
        int imparIndex = 0;
        int parIndex = 0;

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                vetorPares[parIndex] = vetorOriginal[i];
                parIndex++;
            }
            else
            {
                vetorImpares[imparIndex] = vetorOriginal[i];
                imparIndex++;
            }
        }
    }

    public void ImprimirVetores()
    {
        Console.WriteLine("+-------------------------------------------------+\n");
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine("| Vetor de elementos nas posições ímpares: ");
        Console.Write("| ");
        foreach (var item in vetorImpares)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\n|\n| Vetor de elementos nas posições pares: ");
        Console.Write("| ");
        foreach (var item in vetorPares)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
