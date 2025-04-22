using System;

class ArquivoLogger
{
    public ArquivoLogger()
    {
        Console.WriteLine("Arquivo aberto.");
    }

    public void Log(string mensagem)
    {
        Console.WriteLine($"Log: {mensagem}");
    }

    ~ArquivoLogger()
    {
        Console.WriteLine("Arquivo fechado (Finalizador).");
    }
}

class Program
{
    static void Main()
    {
        var logger1 = new ArquivoLogger();
        logger1.Log("Mensagem 1");
        logger1.Log("Mensagem 2");

        Console.WriteLine("\nCriando outro logger:");
        var logger2 = new ArquivoLogger();
        logger2.Log("Mensagem 3");

        Console.WriteLine("\nForçando coleta de lixo...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("\nFim do programa.");
    }
}
