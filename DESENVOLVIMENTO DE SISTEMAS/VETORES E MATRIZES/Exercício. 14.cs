using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");
            Console.WriteLine("|       Verificação de Matriz Identidade          |");
            Console.WriteLine("+-------------------------------------------------+");

            MatrizIdentidade matrizIdentidade = new MatrizIdentidade(2);
            matrizIdentidade.PreencherMatriz();
            matrizIdentidade.ExibirMatriz();
            matrizIdentidade.VerificarMatrizIdentidade();

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class MatrizIdentidade
{
    private int[,] matriz;
    private int tamanho;

    public MatrizIdentidade(int tamanho)
    {
        this.tamanho = tamanho;
        matriz = new int[tamanho, tamanho];
    }

    public void PreencherMatriz()
    {
        Console.WriteLine("| Preencha a matriz 2x2 (digite os valores um por um):");
        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"| Digite o valor para a posição [{i + 1},{j + 1}]: ");
                        if (!int.TryParse(Console.ReadLine(), out matriz[i, j]))
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
    }

    public void ExibirMatriz()
    {
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine("| Matriz preenchida:");
        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
            {
                Console.Write($"| {matriz[i, j],2} ");
            }
            Console.WriteLine("|");
        }
    }

    public void VerificarMatrizIdentidade()
    {
        bool isIdentidade = true;

        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
            {
                if (i == j && matriz[i, j] != 1)
                {
                    isIdentidade = false;
                }
                else if (i != j && matriz[i, j] != 0)
                {
                    isIdentidade = false;
                }
            }
        }

        Console.WriteLine("| Resultado:");
        Console.WriteLine(isIdentidade
            ? "| A matriz é uma matriz identidade."
            : "| A matriz NÃO é uma matriz identidade.");
    }
}
