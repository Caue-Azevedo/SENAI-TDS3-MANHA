using System;

public sealed class Singleton : IDisposable
{
    private static readonly object lockObj = new object();
    private static Singleton instancia;
    private bool foiDescartado = false;

    private Singleton()
    {
        Console.WriteLine("Singleton criado.");
    }

    public static Singleton Instancia
    {
        get
        {
            lock (lockObj)
            {
                if (instancia == null)
                    instancia = new Singleton();

                return instancia;
            }
        }
    }

    public static void Destruir()
    {
        lock (lockObj)
        {
            instancia?.Dispose();
            instancia = null;
        }
    }

    public void Dispose()
    {
        if (!foiDescartado)
        {
            Console.WriteLine("Recursos liberados.");
            foiDescartado = true;
        }
    }

    public void Executar()
    {
        if (foiDescartado)
            throw new ObjectDisposedException(nameof(Singleton));

        Console.WriteLine("Executando lógica.");
    }
}

class Program
{
    static void Main()
    {
        Singleton.Instancia.Executar();
        Singleton.Destruir();
    }
}
