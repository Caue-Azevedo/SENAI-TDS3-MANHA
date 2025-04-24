using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|               Busca em Matriz                   |");
            Console.WriteLine("+-------------------------------------------------+");

            Console.Write("| Informe o número de linhas da matriz: ");
            int linhas = int.Parse(Console.ReadLine());

            Console.Write("| Informe o número de colunas da matriz: ");
            int colunas = int.Parse(Console.ReadLine());

            int[,] matriz = new int[linhas, colunas];

            Console.WriteLine("\n| Preencha a matriz:");
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    while (true)
                    {
                        Console.Write($"| Valor para posição [{i + 1},{j + 1}]: ");
                        if (!int.TryParse(Console.ReadLine(), out matriz[i, j]))
                        {
                            Console.WriteLine("| Valor inválido. Digite um número inteiro.");
                            continue;
                        }
                        break;
                    }
                }
            }

            Console.Write("\n| Informe o valor a ser buscado: ");
            int alvo = int.Parse(Console.ReadLine());

            List<string> posicoes = new List<string>();

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    if (matriz[i, j] == alvo)
                    {
                        posicoes.Add($"[{i + 1},{j + 1}]");
                    }
                }
            }

            Console.WriteLine("+-------------------------------------------------+");
            if (posicoes.Count > 0)
            {
                Console.WriteLine($"| Valor {alvo} encontrado nas posições:");
                foreach (string pos in posicoes)
                {
                    Console.WriteLine($"| {pos}");
                }
            }
            else
            {
                Console.WriteLine($"| Valor {alvo} não encontrado na matriz.");
            }
            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}
