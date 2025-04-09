using System;
using System.Threading;


class Calculadora
{
    private double numero1;
    private double numero2;


    public double Numero1
    {
        get => numero1;
        set => numero1 = value;
    }


    public double Numero2
    {
        get => numero2;
        set => numero2 = value;
    }


    public Calculadora(double numero1, double numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }


    public void Calcular()
    {
        Console.Clear();
        Console.WriteLine("|==============================================================|");


        Console.WriteLine($"|  Soma:          {Numero1} + {Numero2} = {Numero1 + Numero2}");
        Console.WriteLine($"|  Subtração:     {Numero1} - {Numero2} = {Numero1 - Numero2}");
        Console.WriteLine($"|  Multiplicação: {Numero1} * {Numero2} = {Numero1 * Numero2}");


        if (Numero2 != 0)
            Console.WriteLine($"|  Divisão:       {Numero1} / {Numero2} = {Numero1 / Numero2}");
        else
            Console.WriteLine("|  Divisão:       Não é possível dividir por zero.");


        Console.WriteLine("|==============================================================|");
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
            Console.WriteLine("|          Calculadora Simples          |");
            Console.WriteLine("|---------------------------------------|");


            double numero1 = ObterNumero("primeiro");
            double numero2 = ObterNumero("segundo");


            Calculadora calc = new Calculadora(numero1, numero2);
            calc.Calcular();
        }
        catch (Exception ex)
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine($"| Erro: {ex.Message} |");
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


    private static double ObterNumero(string ordem)
    {
        double numero;
        bool valido;
        do
        {
            Console.Write($"| Digite o {ordem} número: ");
            string input = Console.ReadLine();
            valido = double.TryParse(input, out numero);


            if (!valido)
            {
                Console.WriteLine("\n|-------------------------------------------------|");
                Console.WriteLine("| Valor inválido. Por favor, digite um número.    |");
                Console.WriteLine("|-------------------------------------------------|\n");
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (!valido);


        return numero;
    }
}




