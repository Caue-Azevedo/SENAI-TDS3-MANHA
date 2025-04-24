using System;

class Program
{
    static void Main()
    {
        Console.Clear();    
        try
        {
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|            Transposição de Matriz               |");
            Console.WriteLine("+-------------------------------------------------+");

            MatrizTransposta matrizTransposta = new MatrizTransposta();
            matrizTransposta.PreencherMatriz();
            matrizTransposta.ExibirMatriz("Matriz Original:");
            matrizTransposta.ExibirMatriz("Matriz Transposta:", matrizTransposta.TransporMatriz());

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class MatrizTransposta
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

    public int[,] TransporMatriz()
    {
        int[,] transposta = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                transposta[j, i] = matriz[i, j];
            }
        }
        return transposta;
    }

    public void ExibirMatriz(string titulo, int[,] matrizExibir = null)
    {
        if (matrizExibir == null) matrizExibir = matriz;
        Console.WriteLine($"\n| {titulo} ");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"| {matrizExibir[i, j],2} ");
            }
            Console.WriteLine("|");
        }        
    }
}
