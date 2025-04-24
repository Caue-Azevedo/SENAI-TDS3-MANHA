using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------+");

            Loteria loteria = new Loteria();
            loteria.LerGabarito();
            loteria.LerApostas();
            loteria.VerificarAcertos();

            Console.WriteLine("+-------------------------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class Aposta
{
    public int NumeroApostador { get; set; }
    public int[] RespostasApostador { get; set; }
}

class Loteria
{
    private int[] gabaritoLoteria = new int[13];
    private Aposta[] apostasApostadores;

    public void LerGabarito()
    {
        Console.WriteLine("| Digite o gabarito da loteria (13 números entre 1, 2, e 3):");
        for (int i = 0; i < 13; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Gabarito posição {i + 1}: ");
                    if (!int.TryParse(Console.ReadLine(), out gabaritoLoteria[i]) || gabaritoLoteria[i] < 1 || gabaritoLoteria[i] > 3)
                    {
                        Console.WriteLine("| Valor inválido. O número deve ser 1, 2 ou 3.");
                        continue;
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler o gabarito: {ex.Message}");
                }
            }
        }
    }

    public void LerApostas()
    {
        Console.WriteLine("+-------------------------------------------------+\n");
        Console.WriteLine("+-------------------------------------------------+");
        Console.Write("| Digite o número de apostadores: ");
        int numeroDeApostadores;
        while (!int.TryParse(Console.ReadLine(), out numeroDeApostadores) || numeroDeApostadores <= 0)
        {
            Console.WriteLine("| Valor inválido. Digite um número válido de apostadores.");
        }

        apostasApostadores = new Aposta[numeroDeApostadores];
        for (int i = 0; i < numeroDeApostadores; i++)
        {
            while (true)
            {
                Console.WriteLine("+-------------------------------------------------+\n");
                Console.WriteLine("+-------------------------------------------------+");
                try
                {
                    Console.Write($"| Digite o nome do apostador {i + 1}: ");
                    int numeroDoApostador = int.Parse(Console.ReadLine());

                    int[] respostasDoApostador = new int[13];
                    Console.WriteLine("| Digite as respostas (13 números entre 1, 2, e 3):");
                    for (int j = 0; j < 13; j++)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write($"| Resposta {j + 1}: ");
                                if (!int.TryParse(Console.ReadLine(), out respostasDoApostador[j]) || respostasDoApostador[j] < 1 || respostasDoApostador[j] > 3)
                                {
                                    Console.WriteLine("| Valor inválido. O número deve ser 1, 2 ou 3.");
                                    continue;
                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"| Erro ao ler as respostas: {ex.Message}");
                            }
                        }
                    }

                    apostasApostadores[i] = new Aposta { NumeroApostador = numeroDoApostador, RespostasApostador = respostasDoApostador };
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler as apostas: {ex.Message}");
                }
            }
        }
    }

    public void VerificarAcertos()
    {
        Console.WriteLine("+-------------------------------------------------+");
        Console.WriteLine("| Resultados dos apostadores:");

        foreach (var aposta in apostasApostadores)
        {
            int numeroDeAcertos = 0;
            for (int i = 0; i < 13; i++)
            {
                if (gabaritoLoteria[i] == aposta.RespostasApostador[i])
                {
                    numeroDeAcertos++;
                }
            }

            Console.WriteLine($"| Apostador {aposta.NumeroApostador} - Acertos: {numeroDeAcertos}");
            if (numeroDeAcertos == 13)
            {
                Console.WriteLine("| Ganhador!");
            }
        }
    }
}
