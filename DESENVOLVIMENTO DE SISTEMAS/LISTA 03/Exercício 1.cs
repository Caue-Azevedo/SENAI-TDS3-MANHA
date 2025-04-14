using System;

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
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|         Calculadora de média         |");
            Console.WriteLine("+--------------------------------------+");

            for (int i = 0; i < 3; i++)  
            {
                Console.Write($"| Digite o {i + 1}º número: ");
                int num = int.Parse(Console.ReadLine());
                numeros.SetNumero(num);
            }

            Console.Clear();

            Console.WriteLine("+--------------------------------------+");
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
            Console.WriteLine("\n\n|---------------------------------------|");
            Console.WriteLine("| Pressione qualquer tecla para sair... |");
            Console.WriteLine("|---------------------------------------|");
            Console.ReadKey();
            Console.WriteLine("|               Saindo...               |");
            Console.WriteLine("|=======================================|");
            
        }
    }
}
