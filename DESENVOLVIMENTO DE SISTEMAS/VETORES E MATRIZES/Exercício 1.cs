using System;

class Program
{
    static void Main()
    {
        double[] salarios = new double[10];
        Console.Clear();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Digite o {i + 1}º salário: "); 
            while (!double.TryParse(Console.ReadLine(), out salarios[i]))
            {
                Console.Write("Entrada inválida. Digite um valor numérico: ");
            }
        }

        double maiorSalario = salarios[0];

        for (int i = 0; i < salarios.Length; i++)
        {
            if (salarios[i] > maiorSalario)
            {
                maiorSalario = salarios[i];
            }
        }

        Console.WriteLine($"O maior salário é: {maiorSalario}");  
    }
}
