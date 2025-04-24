using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+------------------------------+");

            GerenciadorSalario gerente = new GerenciadorSalario(5);
            gerente.LerSalarios();
            gerente.AplicarAumento();
            gerente.MostrarSalarios();

            Console.WriteLine("+------------------------------+");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class GerenciadorSalario
{
    private double[] salarios;

    public GerenciadorSalario(int quantidade)
    {
        salarios = new double[quantidade];
    }

    public void LerSalarios()
    {
        for (int i = 0; i < salarios.Length; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Digite o {i + 1}º salário: ");
                    string entrada = Console.ReadLine();

                    if (double.TryParse(entrada, out double salario))
                    {
                        salarios[i] = salario;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler o salário: {ex.Message}");
                }
            }
        }
    }

    public void AplicarAumento()
    {
        for (int i = 0; i < salarios.Length; i++)
        {
            if (salarios[i] < 1000)
            {
                salarios[i] *= 1.1;
            }
        }
    }

    public void MostrarSalarios()
    {
        Console.WriteLine("\n+------------------------------+");
        Console.WriteLine("| Lista atualizada de salários:");
        for (int i = 0; i < salarios.Length; i++)
        {
            Console.WriteLine($"| {i + 1}º salário: {salarios[i]:F2}");
        }
    }
}
