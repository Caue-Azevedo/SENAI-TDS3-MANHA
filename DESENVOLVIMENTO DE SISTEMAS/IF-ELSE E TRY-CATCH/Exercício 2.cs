using System;
using System.IO;
using System.Threading;

class LeitorDeArquivo
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarCabecalho();

            string caminho = SolicitarCaminho();

            TentarLerArquivo(caminho);

            if (!DesejaContinuar())
            {
                MostrarSaida();
                break;
            }
        }
    }

    static void MostrarCabecalho()
    {
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine("|             LEITOR DE ARQUIVOS           |");
        Console.WriteLine("+------------------------------------------+");
    }

    static string SolicitarCaminho()
    {
        Console.Write("| Digite o caminho do arquivo: ");
        return Console.ReadLine();
    }

    static void TentarLerArquivo(string caminho)
    {
        try
        {
            string conteudo = LerArquivo(caminho);
            MostrarConteudo(conteudo);
        }
        catch (FileNotFoundException)
        {
            MostrarErro("        Arquivo não encontrado.          ");
        }
        catch (IOException)
        {
            MostrarErro("Erro ao ler o arquivo.                   ");
        }
    }

    static string LerArquivo(string caminho)
    {
        return File.ReadAllText(caminho);
    }

    static void MostrarConteudo(string conteudo)
    {
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine("| Conteúdo do arquivo:                     |");
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine(conteudo);
        Console.WriteLine("+------------------------------------------+");
    }

    static bool DesejaContinuar()
    {
        Console.Write("\n| Deseja tentar ler outro arquivo? (s/n): ");
        string resposta = Console.ReadLine().ToLower();
        return resposta == "s";
    }

    static void MostrarErro(string mensagem)
    {
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine("|                   ERRO!                  |");
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine($"| {mensagem}|");
        Console.WriteLine("+------------------------------------------+");
        Thread.Sleep(1500);
    }

    static void MostrarSaida()
    {
        Console.WriteLine("\n+------------------------------------------+");
        Console.WriteLine("|                 Saindo...                |");
        Console.WriteLine("+------------------------------------------+");
        Thread.Sleep(1000);
    }
}
