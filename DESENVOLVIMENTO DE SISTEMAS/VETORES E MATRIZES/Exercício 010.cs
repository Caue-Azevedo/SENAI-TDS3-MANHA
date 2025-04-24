using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");

            LocacoesGratis locacoesGratis = new LocacoesGratis();
            locacoesGratis.LerVetor();
            locacoesGratis.CalcularLocacoesGratis();
            locacoesGratis.ImprimirResultado();

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class LocacoesGratis
{
    private int[] filmesRetirados = new int[50];
    private int[] locacoesGratuitas = new int[50];

    public void LerVetor()
    {
        Console.WriteLine("| Digite a quantidade de filmes retirados pelos clientes:");
        for (int i = 0; i < 50; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Cliente {i + 1}: ");
                    if (!int.TryParse(Console.ReadLine(), out filmesRetirados[i]) || filmesRetirados[i] < 0)
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido de filmes.");
                        continue;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler o número de filmes: {ex.Message}");
                }
            }
        }
    }

    public void CalcularLocacoesGratis()
    {
        for (int i = 0; i < 50; i++)
        {
            locacoesGratuitas[i] = filmesRetirados[i] / 10;
        }
    }

    public void ImprimirResultado()
    {
        Console.WriteLine("+-------------------------------------------------+\n");
        Console.WriteLine("+-------------------------------------------------+");

        Console.WriteLine("| Resultado das locações gratuitas: ");
        for (int i = 0; i < 50; i++)
        {
            Console.WriteLine($"| Cliente {i + 1} - Locações gratuitas: {locacoesGratuitas[i]}");
        }
    }
}
