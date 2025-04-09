using System;
using System.Threading;


class AvaliadorNota
{
    private double nota;


    public double Nota
    {
        get => nota;
        set => nota = ValidarNota(value) ? value
            : throw new ArgumentOutOfRangeException("A nota deve estar entre 0 e 10.");
    }


    public AvaliadorNota(double nota)
    {
        Nota = nota;
    }


    public void Classificar()
    {
        Console.Clear();
        Console.WriteLine($"|============================|");


        if (nota >= 9 && nota <= 10)
            Console.WriteLine($"|     Nota: {nota} - Excelente    |");
        else if (nota >= 7)
            Console.WriteLine($"|        Nota: {nota} - Bom       |");  
        else if (nota >= 5)
            Console.WriteLine($"|     Nota: {nota} - Regular      |");
        else
            Console.WriteLine($"|   Nota: {nota} - Insuficiente   |");
            Console.WriteLine($"|============================|");
    }


    private static bool ValidarNota(double valor)
    {
        return valor >= 0 && valor <= 10;
    }
}


class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("|=======================================|");
            Console.WriteLine("|           Avaliação de Nota           |");
            Console.WriteLine("|---------------------------------------|");


            double nota = ObterNotaValida();


            AvaliadorNota avaliador = new AvaliadorNota(nota);
            avaliador.Classificar();
        }
        catch (Exception ex)
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine($"| Erro: {ex.Message}             |");
            Console.WriteLine("|-------------------------------|");
        }
        finally
        {
            Console.WriteLine("\n\n|---------------------------------------|");
            Console.WriteLine("| Pressione qualquer tecla para sair... |");
            Console.WriteLine("|---------------------------------------|");
            Console.ReadKey();
            Console.WriteLine("\n|---------------------------------------|");
            Console.WriteLine("|               Saindo...               |");
            Console.WriteLine("|=======================================|");
        }
    }




    private static double ObterNotaValida()
    {
        double nota;
        bool valido;
        do
        {
            Console.Write("| Digite uma nota entre 0 e 10: ");
            string input = Console.ReadLine();
            valido = double.TryParse(input, out nota) && nota >= 0 && nota <= 10;


            if (!valido)
            {
                Console.WriteLine("\n|----------------------------------------------------------|");
                Console.WriteLine("|      Nota inválida. Por favor, digite entre 0 e 10.      |");
                Console.WriteLine("|----------------------------------------------------------|\n");
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (!valido);


        return nota;
    }
}
