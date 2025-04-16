using System;
using System.Threading;

class Temperatura
{
    private double temperaturaCelsius;

    public double Celsius
    {
        get => temperaturaCelsius;
        set
        {
            if (value < -273.15)
                throw new ArgumentOutOfRangeException("A temperatura não pode ser menor que -273.15°C (zero absoluto).");
            temperaturaCelsius = value;
        }
    }

    public double Fahrenheit
    {
        get => temperaturaCelsius * 1.8 + 32;
    }
}

class Program
{
    static void Main()
    {
        Temperatura temperatura = new Temperatura();

        Console.Clear();
        Console.WriteLine("+-----------------------------------+");
        Console.WriteLine("|  Insira a temperatura em Celsius  |");
        Console.Write("+-----------------------------------+\n| ");
        string entrada = Console.ReadLine();

        if (double.TryParse(entrada, out double tempCelsius))
        {
            try
            {
                temperatura.Celsius = tempCelsius;

                Console.Clear();
                Console.WriteLine("+---------------------------------------------+");
                Console.WriteLine($"| Temperatura em Fahrenheit: {temperatura.Fahrenheit,6:F2}°F       ");
                Console.WriteLine("+---------------------------------------------+");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"| Erro: {ex.Message}");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("| Erro: Valor inválido! Use apenas números.");
        }

        Console.WriteLine();
        Console.WriteLine("\n+------------------------------------------------+");
        Console.WriteLine("|   Pressione qualquer tecla para continuar...   |");
        Console.WriteLine("+------------------------------------------------+");
        Console.ReadKey();
    }
}
