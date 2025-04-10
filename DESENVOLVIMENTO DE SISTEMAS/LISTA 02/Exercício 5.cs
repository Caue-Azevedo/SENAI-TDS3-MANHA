using System;
using System.Numerics;
using System.Threading;

class CalculadoraCientifica
{
    private double baseNum;
    private double expoente;
    private double numero;
    private int numeroInteiro;

    public double GetBaseNum()
    {
        return baseNum;
    }

    public void SetBaseNum(double valor)
    {
        baseNum = valor;
    }

    public double GetExpoente()
    {
        return expoente;
    }

    public void SetExpoente(double valor)
    {
        expoente = valor;
    }

    public double GetNumero()
    {
        return numero;
    }

    public void SetNumero(double valor)
    {
        numero = valor;
    }

    public int GetNumeroInteiro()
    {
        return numeroInteiro;
    }

    public void SetNumeroInteiro(int valor)
    {
        numeroInteiro = valor;
    }

    public double Potencia()
    {
        return Math.Pow(baseNum, expoente);
    }

    public double RaizQuadrada()
    {
        if (numero < 0)
            throw new ArgumentException("Não é possível calcular a raiz quadrada de número negativo.");

        return Math.Sqrt(numero);
    }

    public BigInteger Fatorial()
    {
        if (numeroInteiro < 0)
            throw new ArgumentException("Não é possível calcular o fatorial de número negativo.");

        BigInteger resultado = 1;
        for (int n = 1; n <= numeroInteiro; n++)
        {
            resultado *= n;
        }
        return resultado;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            CalculadoraCientifica calc = new CalculadoraCientifica();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("+------------------------------------------------+");
                Console.WriteLine("|          CALCULADORA CIENTÍFICA BÁSICA         |");
                Console.WriteLine("+------------------------------------------------+");
                Console.WriteLine("| 1 - Calcular Potência                          |");
                Console.WriteLine("| 2 - Calcular Raiz Quadrada                     |");
                Console.WriteLine("| 3 - Calcular Fatorial                          |");
                Console.WriteLine("| 0 - Sair                                       |");
                Console.WriteLine("+------------------------------------------------+");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("+------------------------------------------------+");
                        Console.WriteLine("|           Cálculo escolhido: Potência          |");
                        Console.WriteLine("+------------------------------------------------+");
                        Console.Write("| Digite a base: ");
                        calc.SetBaseNum(double.Parse(Console.ReadLine()));

                        Console.Write("| Digite o expoente: ");
                        calc.SetExpoente(double.Parse(Console.ReadLine()));

                        Console.WriteLine($"| Resultado: {calc.GetBaseNum()}^{calc.GetExpoente()} = {calc.Potencia()}");
                        Console.WriteLine("+------------------------------------------------+");
                        break;

                    case "2":
                        Console.WriteLine("+------------------------------------------------+");
                        Console.WriteLine("|        Cálculo escolhido: Raiz Quadrada        |");
                        Console.WriteLine("+------------------------------------------------+");
                        Console.Write("| Digite o número: ");
                        calc.SetNumero(double.Parse(Console.ReadLine()));

                        Console.WriteLine($"| Resultado: √{calc.GetNumero()} = {calc.RaizQuadrada()}");
                        Console.WriteLine("+------------------------------------------------+");
                        break;

                    case "3":
                        Console.WriteLine("+------------------------------------------------+");
                        Console.WriteLine("|           Cálculo escolhido: Fatorial          |");
                        Console.WriteLine("+------------------------------------------------+");
                        Console.Write("| Digite um número inteiro: ");
                        calc.SetNumeroInteiro(int.Parse(Console.ReadLine()));

                        Console.WriteLine($"| Resultado: {calc.GetNumeroInteiro()}! = {calc.Fatorial()}");
                        Console.WriteLine("+------------------------------------------------+");
                        break;

                    case "0":
                        Console.WriteLine("+------------------------------------------------+");
                        Console.WriteLine("|             Encerrando o programa...           |");
                        Console.WriteLine("+------------------------------------------------+");
                        Thread.Sleep(1000);
                        return;

                    default:
                        Console.WriteLine("| Opção inválida.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("\n\n+------------------------------------------------+");
                Console.WriteLine("|   Pressione qualquer tecla para continuar...   |");
                Console.WriteLine("+------------------------------------------------+");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("| Erro: " + ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("| Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
