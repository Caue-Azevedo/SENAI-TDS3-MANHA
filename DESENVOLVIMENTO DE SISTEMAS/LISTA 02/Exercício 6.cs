using System;
using System.Text;
using System.Threading;

class ContaBancaria
{
    private string numeroConta;
    private string titular;
    private double saldo;

    public ContaBancaria(string numeroConta, string titular)
    {
        this.numeroConta = numeroConta;
        this.titular = titular;
        this.saldo = 0;
    }

    public string GetNumeroConta()
    {
        return numeroConta;
    }

    public void SetNumeroConta(string valor)
    {
        numeroConta = valor;
    }

    public string GetTitular()
    {
        return titular;
    }

    public void SetTitular(string valor)
    {
        titular = valor;
    }

    public double GetSaldo()
    {
        return saldo;
    }

    public void Depositar(double valor)
    {
        if (valor > 0)
        {
            saldo += valor;
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|       Depósito realizado com sucesso!       |");
            Console.WriteLine("+---------------------------------------------+");
        }
        else
        {
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|        Valor inválido para depósito.        |");
            Console.WriteLine("+---------------------------------------------+");
        }
    }

    public void Sacar(double valor)
    {
        if (valor > 0 && valor <= saldo)
        {
            saldo -= valor;
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|         Saque realizado com sucesso!        |");
            Console.WriteLine("+---------------------------------------------+");
        }
        else
        {
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|    Valor inválido ou saldo insuficiente.    |");
            Console.WriteLine("+---------------------------------------------+");
        }
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"| Saldo atual: R${saldo:F2}");
        Console.WriteLine("+---------------------------------------------+");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.Clear();
        Console.WriteLine("+---------------------------------------------+");
        Console.WriteLine("|           Cadastro de Conta Bancária        |");
        Console.WriteLine("+---------------------------------------------+");

        Console.Write("| Número da conta: ");
        string numero = Console.ReadLine();

        Console.Write("| Nome do titular: ");
        string nome = Console.ReadLine();

        ContaBancaria conta = new ContaBancaria(numero, nome);

        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|               Menu da Conta                 |");
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("| 1 - Depositar");
            Console.WriteLine("| 2 - Sacar");
            Console.WriteLine("| 3 - Exibir Saldo");
            Console.WriteLine("| 0 - Sair");
            Console.WriteLine("+---------------------------------------------+");
            Console.Write("| Escolha uma opção: ");

            string entrada = Console.ReadLine();
            bool valida = int.TryParse(entrada, out opcao);

            if (!valida)
            {
                Console.Clear();
                Console.WriteLine("| Opção inválida!");
                Thread.Sleep(1000);
                continue;
            }

            Console.Clear();
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("+---------------------------------------------+");
                    Console.WriteLine("|          Opção escolhida: depósito          |");
                    Console.WriteLine("+---------------------------------------------+");
                    Console.Write("| Valor para depósito: R$");
                    double valorDeposito = double.Parse(Console.ReadLine());
                    conta.Depositar(valorDeposito);
                    Thread.Sleep(1000);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("+---------------------------------------------+");
                    Console.WriteLine("|            Opção escolhida: saque           |");
                    Console.WriteLine("+---------------------------------------------+");
                    Console.Write("| Valor para saque: R$");
                    double valorSaque = double.Parse(Console.ReadLine());
                    conta.Sacar(valorSaque);
                    Thread.Sleep(1000);
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("+---------------------------------------------+");
                    Console.WriteLine("|       Opção escolhida: Verificar Saldo      |");
                    Console.WriteLine("+---------------------------------------------+");
                    Console.WriteLine($"| Titular: {conta.GetTitular()}");
                    Console.WriteLine($"| Número da conta: {conta.GetNumeroConta()}");
                    Console.WriteLine("+---------------------------------------------+");
                    conta.ExibirSaldo();
                    break;

                case 0:
                    Console.Clear();
                    Console.WriteLine("+------------------------------------------------+");
                    Console.WriteLine("|             Encerrando o programa...           |");
                    Console.WriteLine("+------------------------------------------------+");
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("| Opção inválida.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("\n\n+------------------------------------------------+");
            Console.WriteLine("|   Pressione qualquer tecla para continuar...   |");
            Console.WriteLine("+------------------------------------------------+");
            Console.ReadKey();

        } while (true);
    }
}
