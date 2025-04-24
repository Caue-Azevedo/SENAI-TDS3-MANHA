using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("+---------------------------------------+");
            double[] medias = LerMedias();
            double media = CalcularMedia(medias);
            Console.WriteLine("+---------------------------------------+\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }

    static double[] LerMedias()
    {
        int quantidadeAlunos;
        while (true)
        {
            Console.Write("| Quantos alunos você quer inserir?: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out quantidadeAlunos) && quantidadeAlunos > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("| Valor inválido. Digite um número inteiro positivo.");
            }
        }

        double[] notasG1 = new double[quantidadeAlunos];
        double[] notasG2 = new double[quantidadeAlunos];
        double[] medias = new double[quantidadeAlunos];

        for (int i = 0; i < quantidadeAlunos; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Digite a nota G1 do {i + 1}º aluno: ");
                    string entradaG1 = Console.ReadLine();
                    if (!double.TryParse(entradaG1, out double nota1))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                        continue;
                    }

                    Console.Write($"| Digite a nota G2 do {i + 1}º aluno: ");
                    string entradaG2 = Console.ReadLine();
                    if (!double.TryParse(entradaG2, out double nota2))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                        continue;
                    }

                    notasG1[i] = nota1;
                    notasG2[i] = nota2;
                    medias[i] = (nota1 + nota2) / 2;

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| Erro ao ler a nota: {ex.Message}");
                }
            }
        }

        Console.WriteLine("\n+---------------------------------------+");
        Console.WriteLine("| Notas e Médias:");
        for (int i = 0; i < quantidadeAlunos; i++)
        {
            Console.WriteLine($"| Aluno {i + 1}: G1 = {notasG1[i]}, G2 = {notasG2[i]}, Média = {medias[i]:F2}");
        }

        return medias;
    }

    static double CalcularMedia(double[] valores)
    {
        double soma = 0;
        foreach (var valor in valores)
        {
            soma += valor;
        }
        return soma / valores.Length;
    }
}
