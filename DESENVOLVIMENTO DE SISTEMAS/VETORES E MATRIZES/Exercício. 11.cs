using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            MatrizPreenchimento matrizPreenchimento = new MatrizPreenchimento();
            matrizPreenchimento.PreencherMatriz();
            matrizPreenchimento.ExibirMatriz();

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class MatrizPreenchimento
{
    private int[,] matriz = new int[4, 4];

    public void PreencherMatriz()
    {
        int valor = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matriz[i, j] = valor++;
            }
        }
    }

    public void ExibirMatriz()
    {
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine("| Matriz 4x4 preenchida com valores sequenciais:  |");
        Console.WriteLine("+-------------------------------------------------+");

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"| {matriz[i, j],2} ");
            }
            Console.WriteLine("|");
        }
    }
}
