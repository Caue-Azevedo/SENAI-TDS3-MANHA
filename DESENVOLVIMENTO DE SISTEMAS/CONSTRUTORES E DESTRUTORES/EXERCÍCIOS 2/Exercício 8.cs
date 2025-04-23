using System;
using System.Collections.Generic;

public class Conexao
{
    public int id { get; }
    public bool emUso { get; set; }

    public Conexao(int id)
    {
        Id = id;
        emUso = false;
        Console.WriteLine($"Conexao {id} criada.");
    }

    ~Conexao()
    {
        Console.WriteLine($"Conexao {id} coletada pelo GC.");
    }

    public void Usar()
    {
        Console.WriteLine($"Usando conexao {id}.");
    }
}

public class PoolDeConexoes
{
    private static readonly List<Conexao> Pool;
    private static readonly object LockObj = new object();
    private const int TamanhoPool = 5;

    static PoolDeConexoes()
    {
        Pool = new List<Conexao>();
        for (int i = 0; i < TamanhoPool; i++)
        {
            Pool.Add(new Conexao(i + 1));
        }
        Console.WriteLine("Pool de conexões inicializado.");
    }

    public static Conexao Emprestar()
    {
        lock (LockObj)
        {
            foreach (var conexao in Pool)
            {
                if (!conexao.emUso)
                {
                    conexao.emUso = true;
                    return conexao;
                }
            }

            Console.WriteLine("Nenhuma conexão disponível no momento.");
            return null;
        }
    }

    public static void Devolver(Conexao conexao)
    {
        lock (LockObj)
        {
            if (conexao != null)
            {
                conexao.emUso = false;
                Console.WriteLine($"Conexao {conexao.id} devolvida ao pool.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var c1 = PoolDeConexoes.Emprestar();
        var c2 = PoolDeConexoes.Emprestar();
        c1?.Usar();
        c2?.Usar();

        PoolDeConexoes.Devolver(c1);
        PoolDeConexoes.Devolver(c2);

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
