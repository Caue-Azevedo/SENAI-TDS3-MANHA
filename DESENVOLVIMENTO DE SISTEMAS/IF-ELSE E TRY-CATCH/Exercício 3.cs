using System;
using System.Threading;

class SimuladorDeBancoDeDados
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            MostrarCabecalho();

            ConectarBancoDeDados();

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
        Console.WriteLine("|          SIMULADOR DE CONEXÃO DB         |");
        Console.WriteLine("+------------------------------------------+");
    }

    static void ConectarBancoDeDados()
    {
        bool conexaoAberta = false;
        try
        {
            AbrirConexao();
            conexaoAberta = true;
            Console.WriteLine("|     Conexão estabelecida com sucesso!    |");
            Console.WriteLine("+------------------------------------------+");
        }
        catch (Exception ex)
        {
            MostrarErro(ex.Message);
        }
        finally
        {
            if (conexaoAberta)
            {
                FecharConexao();
            }
            else
            {
                Console.WriteLine("| Tentando fechar conexão (mesmo com erro) |");
                Console.WriteLine("+------------------------------------------+");
            }
            Thread.Sleep(1000);
        }
    }

    static void AbrirConexao()
    {
        Console.WriteLine("| Tentando conectar ao banco de dados...   |");
        Console.WriteLine("+------------------------------------------+");
        Thread.Sleep(1000);

        Random aleatorio = new Random();
        bool sucesso = aleatorio.Next(0, 2) == 0;

        if (!sucesso)
        {
            throw new Exception("  Falha ao conectar ao banco de dados.   ");
        }
    }

    static void FecharConexao()
    {
        Console.WriteLine("| Fechando a conexão com o banco de dados. |");
        Console.WriteLine("+------------------------------------------+");
    }

    static bool DesejaContinuar()
    {
        Console.Write("\n| Deseja tentar outra conexão? (s/n): ");
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
