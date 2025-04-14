using System;
using System.Threading;

class Numeros
{
    private int numero;

    public void SetNumero(int numero) 
    {
        this.numero += numero;
    }

    public int GetNumero()
    {
        return numero;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Numeros numeros = new Numeros();

            Console.Clear();
            Console.WriteLine("\n\n+--------------------------------------+");
            Console.WriteLine("|         Calculadora de média         |");
            Console.WriteLine("+--------------------------------------+");

            for (int i = 0; i < 3; i++)  
            {
                Console.Write("| Digite o {0}º número: ", i + 1);
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out int num))
                {
                    numeros.SetNumero(num);
                }
                else
                {
                    Console.WriteLine("+----------------------------+");
                    Console.WriteLine("|   Erro: Insira um número   |");
                    Console.WriteLine("+----------------------------+");
                    Thread.Sleep(800);
                    i--;
                }
            }

            Console.Clear();

            Console.WriteLine("\n\n+--------------------------------------+");
            Console.WriteLine("| A média dos números é: " + numeros.GetNumero() / 3.0);
            Console.WriteLine("+--------------------------------------+");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
        finally
        {
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("\n\n+---------------------------------------+");
            Console.WriteLine("| Pressione qualquer tecla para sair... |");
            Console.WriteLine("+---------------------------------------+");
            Console.ReadKey();
            Console.WriteLine("\n\n+---------------------------------------+");
            Console.WriteLine("|               Saindo...               |");
            Console.WriteLine("+---------------------------------------+");
        }
    }
}
