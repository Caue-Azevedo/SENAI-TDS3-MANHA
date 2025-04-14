using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        while (true)
        {
            try
            {
                Console.WriteLine("+-------------------------------+");
                Console.Write("| Digite um número inteiro: ");
                int numero = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("+-------------------------------+");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("+-------------------------------+");
                Console.WriteLine("| Você digitou: " + numero);
                Console.WriteLine("+-------------------------------+");

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("|      Entrada inválida      |");
                Console.WriteLine("+----------------------------+");
                Thread.Sleep(900);
                Console.Clear();
            }
        }
    }
}   
