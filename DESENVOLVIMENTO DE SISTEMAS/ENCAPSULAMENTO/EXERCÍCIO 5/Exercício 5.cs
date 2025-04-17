using System;
using System.Collections.Generic;
using System.Threading;

class Playlist
{
    private List<(string Nome, int Duracao)> musicas = new List<(string, int)>();

    public int DuracaoTotal
    {
        get
        {
            int duracaoTotal = 0;
            foreach (var musica in musicas)
            {
                duracaoTotal += musica.Duracao;
            }
            return duracaoTotal;
        }
    }

    public void AdicionarMusica(string nome, int duracaoSegundos)
    {
        if (musicas.Exists(m => m.Nome == nome))
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| Música já adicionada na playlist!     |");
            Console.WriteLine("+---------------------------------------+");
            return;
        }

        if (duracaoSegundos <= 0)
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| Duração inválida! Use um valor maior que zero.");
            Console.WriteLine("+---------------------------------------+");
            return;
        }

        musicas.Add((nome, duracaoSegundos));
        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine($"| Música '{nome}' adicionada com sucesso! |");
        Console.WriteLine("+---------------------------------------+");
    }

    public void RemoverMusica(string nome)
    {
        var musicaRemovida = musicas.Find(m => m.Nome == nome);
        if (musicaRemovida.Nome == null)
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| Música não encontrada na playlist!    |");
            Console.WriteLine("+---------------------------------------+");
            return;
        }

        musicas.Remove(musicaRemovida);
        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine($"| Música '{nome}' removida da playlist!");
        Console.WriteLine("+---------------------------------------+");
    }

    public void ListarMusicas()
    {
        if (musicas.Count == 0)
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|            Playlist vazia!            |");
            Console.WriteLine("+---------------------------------------+");
            return;
        }

        Console.WriteLine("+------------------------ Playlist ------------------------+");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"| {musica.Nome} - {musica.Duracao} segundos");
        }
        Console.WriteLine("+----------------------------------------------------------+");
    }
}

class Program
{
    static void Main()
    {
        Playlist playlist = new Playlist();
        int opcao = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|          Gerenciador de Playlist      |");
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| 1 - Adicionar música                  |");
            Console.WriteLine("| 2 - Remover música                    |");
            Console.WriteLine("| 3 - Listar músicas                    |");
            Console.WriteLine("| 0 - Sair                              |");
            Console.WriteLine("+---------------------------------------+");
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
                        Console.WriteLine("+---------------------------------------+");
                        Console.WriteLine("|            Adicionar Música           |");
                        Console.WriteLine("+---------------------------------------+");

                        Console.Write("| Nome da música: ");
                        string nomeMusica = Console.ReadLine();

                        Console.Write("| Duração da música (em segundos): ");
                        int duracaoMusica = int.Parse(Console.ReadLine());

                        playlist.AdicionarMusica(nomeMusica, duracaoMusica);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("| Erro: Duração deve ser um número inteiro.");
                    }
                    Thread.Sleep(1500);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("+---------------------------------------+");
                    Console.WriteLine("|             Remover Música            |");
                    Console.WriteLine("+---------------------------------------+");

                    Console.Write("| Nome da música: ");
                    string nomeRemover = Console.ReadLine();

                    playlist.RemoverMusica(nomeRemover);
                    Thread.Sleep(1500);
                    break;

                case 3:
                    Console.Clear();
                    playlist.ListarMusicas();
                    Thread.Sleep(1500);
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
