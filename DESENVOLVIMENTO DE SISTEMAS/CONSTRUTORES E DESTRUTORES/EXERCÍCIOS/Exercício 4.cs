using System;

public class Contador
{
    public static int TotalInstancias = 0;

    public Contador()
    {
        TotalInstancias++;
        Console.WriteLine($"Instância criada. Total: {TotalInstancias}");
    }

    ~Contador()
    {
        TotalInstancias--;
        Console.WriteLine($"Instância destruída. Total: {TotalInstancias}");
    }

    public static void MostrarTotal()
    {
        Console.WriteLine($"Total de instâncias ativas: {TotalInstancias}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Criando instâncias:");
        Contador a = new Contador();
        Contador b = new Contador();
        Contador.MostrarTotal();

        Console.WriteLine("\nForçando coleta de lixo:");
        a = null;
        b = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Contador.MostrarTotal();
    }
}
