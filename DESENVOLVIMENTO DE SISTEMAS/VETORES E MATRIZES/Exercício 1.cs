using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            GerenciadorSalarios gerente = new GerenciadorSalarios(10);
            gerente.LerSalarios();
            double maiorSalario = gerente.CalcularMaiorSalario();
            Console.WriteLine("\n\n+----------------------------+");
            Console.WriteLine($"| O maior salário é: {maiorSalario:F2}");
            Console.WriteLine("+----------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class GerenciadorSalarios
{
    private double[] salarios;
    
    public GerenciadorSalarios(int quantidade)
    {
        salarios = new double[quantidade];
    }

    public void LerSalarios()
    {
        Console.WriteLine("+----------------------------+");

        for (int i = 0; i < salarios.Length; i++)
        {
            Console.Write($"| Digite o {i + 1}º salário: ");
            while (!double.TryParse(Console.ReadLine(), out salarios[i]))
            {
                Console.Write("Entrada inválida. Digite um valor numérico: ");
            }
        }

        Console.WriteLine("+----------------------------+");
    }

    public double CalcularMaiorSalario()
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
