using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------+");

            GerenciadorNotas gerenciador = new GerenciadorNotas();
            gerenciador.LerNotas();
            double mediaGeral = gerenciador.CalcularMediaGeral();

            Console.WriteLine("+---------------------------------------+\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}

class GerenciadorNotas
{
    private double[] notasG1;
    private double[] notasG2;
    private double[] medias;

    public void LerNotas()
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

        notasG1 = new double[quantidadeAlunos];
        notasG2 = new double[quantidadeAlunos];
        medias = new double[quantidadeAlunos];

        for (int i = 0; i < quantidadeAlunos; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"| Digite a nota G1 do {i + 1}º aluno: ");
                    if (!double.TryParse(Console.ReadLine(), out double nota1))
                    {
                        Console.WriteLine("| Valor inválido. Digite um número válido.");
                        continue;
                    }

                    Console.Write($"| Digite a nota G2 do {i + 1}º aluno: ");
                    if (!double.TryParse(Console.ReadLine(), out double nota2))
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
    }

    public double CalcularMediaGeral()
    {
        double soma = 0;
        foreach (var media in medias)
        {
            soma += media;
        }
        return medias.Length > 0 ? soma / medias.Length : 0;
    }
}
