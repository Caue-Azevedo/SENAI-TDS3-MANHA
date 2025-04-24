using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|               Soma de Linhas                    |");
            Console.WriteLine("+-------------------------------------------------+");

            MatrizSomaLinhas matrizSomaLinhas = new MatrizSomaLinhas();
            matrizSomaLinhas.PreencherMatriz();
            matrizSomaLinhas.ExibirMatriz();
            matrizSomaLinhas.CalcularSomaLinhas();

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class MatrizSomaLinhas
{
    private int[,] matriz = new int[3, 3];

    public void PreencherMatriz()
    {
        Random random = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matriz[i, j] = random.Next(1, 11);
            }
        }
    }

    public void CalcularSomaLinhas()
    {
        Console.WriteLine("\n+-------------------------------------------------+");
        Console.WriteLine("| Soma de cada linha:");
        for (int i = 0; i < 3; i++)
        {
            int soma = 0;
            for (int j = 0; j < 3; j++)
            {
                soma += matriz[i, j];
            }
            Console.WriteLine($"| Soma da linha {i + 1}: {soma}");
        }
    }

    public void ExibirMatriz()
    {
        Console.WriteLine("| Matriz 3x3 preenchida com valores aleatórios:   |");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"| {matriz[i, j],2} ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("+-------------------------------------------------+");
    }
}
