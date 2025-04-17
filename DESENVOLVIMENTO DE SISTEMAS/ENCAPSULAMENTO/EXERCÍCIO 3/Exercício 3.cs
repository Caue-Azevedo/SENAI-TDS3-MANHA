using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

class Aluno
{
    private List<double> notas = new List<double>();

    public double Media
    {
        get
        {
            if (notas.Count == 0)
                return 0;
            return notas.Average();
        }
    }

    public void AdicionarNota(double nota)
    {
        if (nota >= 0 && nota <= 10)
        {
            notas.Add(nota);
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine($"|    Nota {nota} adicionada com sucesso.    |");
            Console.WriteLine("+--------------------------------------+");
        }
        else
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| Nota inválida. Use valor entre 0 e 10 |");
            Console.WriteLine("+---------------------------------------+");
        }
    }

    public void RemoverUltimaNota()
    {
        if (notas.Count > 0)
        {
            double removida = notas[notas.Count - 1];
            notas.RemoveAt(notas.Count - 1);
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine($"|       Nota {removida} removida da lista.      |");
            Console.WriteLine("+--------------------------------------+");
        }
        else
        {
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|      Nenhuma nota para remover.      |");
            Console.WriteLine("+--------------------------------------+");
        }
    }

    public void ExibirMedia()
    {
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"|        Média das notas: {Media:F2}         |");
        Console.WriteLine("+--------------------------------------+");
    }
}

class Program
{
    static void Main()
    {
        Aluno aluno = new Aluno();
        int opcao = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|        Sistema de Notas - Aluno      |");
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("| 1 - Adicionar nota                   |");
            Console.WriteLine("| 2 - Remover última nota              |");
            Console.WriteLine("| 3 - Exibir média                     |");
            Console.WriteLine("| 0 - Sair                             |");
            Console.WriteLine("+--------------------------------------+");
            Console.Write("| Escolha uma opção: ");
            string entrada = Console.ReadLine();
            bool valida = int.TryParse(entrada, out opcao);

            if (!valida)
            {
                Console.Clear();
                Console.WriteLine("| Opção inválida!");
                Thread.Sleep(1000);
                continue;
            }

            switch (opcao)
            {
                case 1:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("+--------------------------------------+");
                        Console.WriteLine("|         Adicionar Nota               |");
                        Console.WriteLine("+--------------------------------------+");
                        Console.Write("| Digite a nota (0 a 10): ");
                        double nota = double.Parse(Console.ReadLine());
                        aluno.AdicionarNota(nota);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("| Erro: Digite um número válido.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"| Erro inesperado: {ex.Message}");
                    }
                    Thread.Sleep(1500);
                    break;

                case 2:
                    Console.Clear();
                    aluno.RemoverUltimaNota();
                    Thread.Sleep(1500);
                    break;

                case 3:
                    Console.Clear();
                    aluno.ExibirMedia();
                    Console.WriteLine();
                    break;

                case 0:
                    Console.Clear();
                    Console.WriteLine("+-------------------+");
                    Console.WriteLine("|     Saindo...     |");
                    Console.WriteLine("+-------------------+");
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("+-------------------+");
                    Console.WriteLine("|  Opção inválida.  |");
                    Console.WriteLine("+-------------------+");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|   Pressione qualquer tecla para continuar...   |");
            Console.WriteLine("+------------------------------------------------+");
            Console.ReadKey();

        } while (true);
    }
}
