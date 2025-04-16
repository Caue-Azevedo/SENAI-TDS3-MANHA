using System;
using System.Threading;

class ContaBancaria
{
    private decimal saldo;
    private string numeroConta = "";
    private string titular = "";
    private decimal valor;

    public decimal Valor
    {
        get => valor;
        set => valor = value;
    }

    public decimal Saldo
    {
        get => saldo;
        set => saldo = value;
    }

    public string Titular
    {
        get => titular;
        set => titular = value;
    }

    public string NumeroConta
    {
        get => numeroConta;
        set => numeroConta = value;
    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            saldo += valor;
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|    Depósito realizado com sucesso!    |");
            Console.WriteLine("+---------------------------------------+");
        }
        else
        {
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|        Insira um valor válido!        |");
            Console.WriteLine("+---------------------------------------+");
        }
    }

    public void Sacar(decimal valor)
    {
        if (valor <= saldo && valor > 0)
        {
            saldo -= valor;
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("|     Saque realizado com sucesso!      |");
            Console.WriteLine("+---------------------------------------+");
        }
        else
        {
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("|    Valor inválido ou saldo insuficiente.    |");
            Console.WriteLine("+---------------------------------------------+");
        }
    }

    public void VerificarSaldo()
    {
        Console.WriteLine("+---------------------------------------------+");
        Console.WriteLine($"| Saldo atual: R${saldo:F2}");
        Console.WriteLine("+---------------------------------------------+");
    }
}


class Program
{
    static void Main()
    {
        ContaBancaria contaBancaria = new ContaBancaria();
        int opcao = 0;

        Console.Clear();
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine("|           Sistema bancário           |");
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine("| Criando conta...                     |");
        Console.Write("| Insira o número da conta: \n| ");
        contaBancaria.NumeroConta = Console.ReadLine();
        Console.WriteLine("\n+--------------------------------------+");
        Console.WriteLine("|       Conta criada com sucesso!      |");
        Console.WriteLine("+--------------------------------------+");

        do
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine($"|   Menu da Conta Nº {contaBancaria.NumeroConta}");
            Console.WriteLine("+--------------------------------+");
            Console.WriteLine("| 1 - Depositar                  |");
            Console.WriteLine("| 2 - Sacar                      |");
            Console.WriteLine("| 3 - Exibir Saldo               |");
            Console.WriteLine("| 0 - Sair                       |");
            Console.WriteLine("+--------------------------------+");
            string entrada = Console.ReadLine();
            bool valida = int.TryParse(entrada, out opcao);

            if (!valida)
            {
                Console.Clear();
                Console.WriteLine("| Opção inválida!");
                Thread.Sleep(1000);
                continue;
            }

            switch (opcao)
            {
                case 1:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("+---------------------------------------------+");
                        Console.WriteLine("|          Opção escolhida: depósito          |");
                        Console.WriteLine("+---------------------------------------------+");
                        Console.Write("| Valor para depósito: R$");
                        contaBancaria.Valor = Decimal.Parse(Console.ReadLine());
                        contaBancaria.Depositar(contaBancaria.Valor);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("| Erro: valor inválido! Use apenas números.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"| Erro inesperado: {ex.Message}");
                    }
                    Thread.Sleep(1500);
                    break;

                case 2:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("+---------------------------------------------+");
                        Console.WriteLine("|            Opção escolhida: Saque           |");
                        Console.WriteLine("+---------------------------------------------+");
                        Console.Write("| Valor para saque: R$");
                        contaBancaria.Valor = Decimal.Parse(Console.ReadLine());
                        contaBancaria.Sacar(contaBancaria.Valor);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("| Erro: valor inválido! Use apenas números.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"| Erro inesperado: {ex.Message}");
                    }
                    Thread.Sleep(1500);
                    break;

                case 3:
                    Console.Clear();
                    contaBancaria.VerificarSaldo();
                    break;

                case 0:
                    Console.Clear();
                    Console.WriteLine("+-------------------+");
                    Console.WriteLine("|     Saindo...     |");
                    Console.WriteLine("+-------------------+");
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("+-------------------+");
                    Console.WriteLine("|  Opção inválida.  |");
                    Console.WriteLine("+-------------------+");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("\n+------------------------------------------------+");
            Console.WriteLine("|   Pressione qualquer tecla para continuar...   |");
            Console.WriteLine("+------------------------------------------------+");
            Console.ReadKey();

        } while (true);
    }
}
