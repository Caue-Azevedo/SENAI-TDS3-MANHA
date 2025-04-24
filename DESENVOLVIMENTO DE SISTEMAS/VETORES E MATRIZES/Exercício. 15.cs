using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|           Multiplicação de Matrizes             |");
            Console.WriteLine("+-------------------------------------------------+");

            Console.Write("| Informe o número de linhas da primeira matriz: ");
            int linhasA = int.Parse(Console.ReadLine());

            Console.Write("| Informe o número de colunas da primeira matriz: ");
            int colunasA = int.Parse(Console.ReadLine());

            Console.Write("| Informe o número de colunas da segunda matriz: ");
            int colunasB = int.Parse(Console.ReadLine());

            int[,] matrizA = LerMatriz(linhasA, colunasA, "A");
            int[,] matrizB = LerMatriz(colunasA, colunasB, "B");

            int[,] resultado = MultiplicarMatrizes(matrizA, matrizB);

            Console.WriteLine("| Resultado da multiplicação:");
            ExibirMatriz(resultado);
            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    static int[,] LerMatriz(int linhas, int colunas, string nome)
    {
        int[,] matriz = new int[linhas, colunas];
        Console.WriteLine($"\n| Preencha a matriz {nome}:");

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                while (true)
                {
                    Console.Write($"| {nome}[{i + 1},{j + 1}]: ");
                    if (!int.TryParse(Console.ReadLine(), out matriz[i, j]))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número inteiro.");
                        continue;
                    }
                    break;
                }
            }
        }

        return matriz;
    }

    static int[,] MultiplicarMatrizes(int[,] A, int[,] B)
    {
        int linhasA = A.GetLength(0);
        int colunasA = A.GetLength(1);
        int colunasB = B.GetLength(1);

        int[,] resultado = new int[linhasA, colunasB];

        for (int i = 0; i < linhasA; i++)
        {
            for (int j = 0; j < colunasB; j++)
            {
                int soma = 0;
                for (int k = 0; k < colunasA; k++)
                {
                    soma += A[i, k] * B[k, j];
                }
                resultado[i, j] = soma;
            }
        }

        return resultado;
    }

    static void ExibirMatriz(int[,] matriz)
    {
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                Console.Write($"| {matriz[i, j],3} ");
            }
            Console.WriteLine("|");
        }
    }
}
