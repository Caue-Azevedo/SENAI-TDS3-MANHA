using System;

public class ContaBancaria {
    private decimal _saldo;
    public string? numeroConta { get; set; }
    public ContaBancaria(decimal saldoInicial) {
        _saldo = saldoInicial;
    }
    public void SacarDinheiro(decimal valor) {
        if (valor <= 0) {
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|           O valor do saque deve ser positivo.      |");
            Console.WriteLine("|====================================================|");
            return;
        }

        if (valor <= _saldo) {
            _saldo -= valor;
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine($"|         Saque de R${valor} realizado com sucesso. ");
            Console.WriteLine("|====================================================|");
        } else {
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                  Saldo insuficiente.               |");
            Console.WriteLine("|====================================================|");
        }
    }
    public void DepositarDinheiro(decimal valor) {
        if (valor <= 0) {
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|        O valor do depósito deve ser positivo.      |");
            Console.WriteLine("|====================================================|");
            return;
        }

        _saldo += valor;
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine($"|  Depósito de R${valor} realizado com sucesso. ");
        Console.WriteLine("|====================================================|");
    }
    public decimal VerificarSaldo() {
        return _saldo;
    }
    public void Selecao() {
        int escolha;
        decimal valor;

        do {
            Console.WriteLine("|============================================|");
            Console.WriteLine($"|           Número da Conta: {numeroConta}     ");
            Console.WriteLine("|--------------------------------------------|");
            Console.WriteLine("|         Qual ação deseja realizar?         |");
            Console.WriteLine("| 1) Saque                                   |");
            Console.WriteLine("| 2) Depósito                                |");
            Console.WriteLine("| 3) Verificar saldo                         |");
            Console.WriteLine("| 4) Sair                                    |");
            Console.WriteLine("|--------------------------------------------|");
            Console.Write("| Sua escolha: ");
            escolha = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (escolha) {
                case 1:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|                Escolha realizada: SAQUE            |");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.Write("| Insira o valor desejado: ");
                    valor = Convert.ToDecimal(Console.ReadLine());
                    SacarDinheiro(valor);
                    System.Threading.Thread.Sleep(2700);
                    Console.Clear();
                    break;

                case 2:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|             Escolha realizada: DEPÓSITO            |");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.Write("| Insira o valor desejado: ");
                    valor = Convert.ToDecimal(Console.ReadLine());
                    DepositarDinheiro(valor);
                    System.Threading.Thread.Sleep(2700);
                    Console.Clear();
                    break;

                case 3:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|      Escolha realizada: VERIFICAR SALDO            |");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.Write("| Saldo disponível: ");
                    Console.WriteLine(VerificarSaldo());
                    System.Threading.Thread.Sleep(2700);
                    Console.Clear();
                    break;

                case 4:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|             Saindo... Até logo!                    |");
                    Console.WriteLine("|====================================================|");
                    break;

                default:
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.WriteLine("|              Opção inválida. Tente novamente.      |");
                    Console.WriteLine("|====================================================|");
                    break;
            }
        } while (escolha != 4);
    }
    public void saudacaoInicial() {
        Console.WriteLine("|====================================================|");
        Console.WriteLine("|         Seja bem-vindo(a) ao sistema bancário      |");
        Console.WriteLine("|----------------------------------------------------|");
        Console.Write("| Insira o numero da sua conta: ");
        numeroConta = Console.ReadLine();
        Console.WriteLine("|----------------------------------------------------|");
        Console.WriteLine("|              Acesso feito com sucesso!             |");
        Console.WriteLine("|====================================================|");
        System.Threading.Thread.Sleep(2700);
        Console.Clear();
    }
    static void Main() {
        Console.Clear();
        ContaBancaria conta = new ContaBancaria(1000); 
        conta.saudacaoInicial();
        conta.Selecao();

        Console.WriteLine("\nSaldo final: " + conta.VerificarSaldo());
    }
}
