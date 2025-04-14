using System;
using System.Threading;

class Numero
{
    private int valor;

    public Numero() { }

    public Numero(int valor)
    {
        this.valor = valor;
    }

    public int Valor
    {
        get { return valor; }
        set { valor = value; }
    }

    public string Paridade() => valor % 2 == 0 ? "par  " : "ímpar";
}

class Program
{
    static void Main()
    {
        Numero numero = new Numero();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n+----------------------------+");
            Console.Write("| Digite um número: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int valor))
            {
                numero.Valor = valor;
                string resultado = numero.Paridade();

                Console.Clear();
                Console.WriteLine("\n+---------------------------+");
                Console.WriteLine($"|     Seu número é: {resultado}   |");
                Console.WriteLine("+---------------------------+");

                break;
            }
            else
            {
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("|   Erro: Insira um número   |");
                Console.WriteLine("+----------------------------+");
                Thread.Sleep(800);
            }

            Thread.Sleep(1000);
            Console.WriteLine("\n\n+---------------------------------------------------+");
            Console.WriteLine("| Pressione qualquer tecla para tentar novamente... |");
            Console.WriteLine("+---------------------------------------------------+");
            Console.ReadKey();
        }

        Console.WriteLine("\n\n+---------------------------------------+");
        Console.WriteLine("|               Saindo...               |");
        Console.WriteLine("+---------------------------------------+");
    }
}
