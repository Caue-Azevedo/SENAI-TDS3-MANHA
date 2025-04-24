using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            double[] salarios = LerSalarios(10);
            double maiorSalario = CalcularMaiorSalario(salarios);
            Console.WriteLine("\n\n+----------------------------+");
            Console.WriteLine($"| O maior salário é: {maiorSalario}");
            Console.WriteLine("+----------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    static double[] LerSalarios(int quantidade)
    {
        double[] salarios = new double[quantidade];

        Console.WriteLine("+----------------------------+");
        
        for (int i = 0; i < quantidade; i++)
        {
            Console.Write($"| Digite o {i + 1}º salário: ");
            while (!double.TryParse(Console.ReadLine(), out salarios[i]))
            {
                Console.Write("Entrada inválida. Digite um valor numérico: ");
            }
        }
        Console.WriteLine("+----------------------------+");

        return salarios;
    }

    static double CalcularMaiorSalario(double[] salarios)
    {
        double maior = salarios[0];

        foreach (double salario in salarios)
        {
            if (salario > maior)
            {
                maior = salario;
            }
        }

        return maior;
    }
}
