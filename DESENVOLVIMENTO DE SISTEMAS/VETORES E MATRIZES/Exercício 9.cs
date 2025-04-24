using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");

            VetorPrimos vetorPrimos = new VetorPrimos();
            vetorPrimos.LerVetor();
            vetorPrimos.EncontrarPrimos();
            vetorPrimos.ImprimirVetores();

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class VetorPrimos
{
    private int[] vetorK = new int[15];
    private int[] vetorP = new int[15];
    private int quantidadePrimos = 0;

    public void LerVetor()
    {
        Console.WriteLine("| Digite 15 números inteiros para o vetor K:");
        for (int i = 0; i < 15; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Posição {i + 1}: ");
                    if (!int.TryParse(Console.ReadLine(), out vetorK[i]))
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

    public void EncontrarPrimos()
    {
        foreach (var numero in vetorK)
        {
            if (EhPrimo(numero))
            {
                vetorP[quantidadePrimos] = numero;
                quantidadePrimos++;
            }
        }
    }

    public void ImprimirVetores()
    {
        Console.WriteLine("+-------------------------------------------------+\n");
        Console.WriteLine("+-------------------------------------------------+");

        Console.WriteLine("| Vetor K (original): ");
        Console.Write("| ");
        foreach (var item in vetorK)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine("| Vetor P (números primos): ");
        Console.Write("| ");
        for (int i = 0; i < quantidadePrimos; i++)
        {
            Console.Write(vetorP[i] + " ");
        }
        Console.WriteLine();
    }

    private bool EhPrimo(int numero)
    {
        if (numero <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0) return false;
        }
        return true;
    }
}
