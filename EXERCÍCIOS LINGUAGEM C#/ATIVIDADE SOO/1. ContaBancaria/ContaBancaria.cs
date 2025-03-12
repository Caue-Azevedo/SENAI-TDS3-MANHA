using System;

public class ContaBancaria {
    private decimal _saldo;

    public decimal valor { get; set; }
    public string? numeroConta { get; set; }

    public ContaBancaria(decimal saldoInicial) {
        _saldo = saldoInicial;
    }

    public void sacarDinheiro() {
        if (valor <= _saldo) {
            _saldo -= valor;
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine($"|         Saque de R${valor} realizado com sucesso. |");
            Console.WriteLine("|====================================================|");

        } else {
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|                 Saldo insuficiente.                |");
            Console.WriteLine("|====================================================|");
        }
    }

    public void depositarDinheiro() {
        if (valor > 0) {
            _saldo += valor;
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine($"|  Depósito de R${valor} realizado com sucesso. |");
            Console.WriteLine("|====================================================|");
        } else {
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine("|               Insira um valor positivo.            |");
            Console.WriteLine("|====================================================|");
            
        }
    }

    public decimal verificarSaldo() {
        return _saldo;
    }

    public void selecao () {
        int escolha;
        decimal valor;

        do {
            Console.WriteLine("\n\n|============================================|");
            Console.WriteLine("|         Qual ação deseja realizar?:        |");
            Console.WriteLine("| 1) Saque                                   |");
            Console.WriteLine("| 2) Depósito                                |");
            Console.WriteLine("| 3) Verificar saldo                         |");
            Console.WriteLine("| 4) Sair                                    |");
            Console.WriteLine("|============================================|");
            Console.Write("| Sua escolha: ");
            escolha = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (escolha) {
                case 1:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|                Escolha realizada: SAQUE            |");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.Write("| Insira o valor desejado: ");
                    valor = Convert.ToInt32(Console.ReadLine());
                    sacarDinheiro();
                    System.Threading.Thread.Sleep(2700);
                    Console.Clear();
                    break;

                case 2:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|             Escolha realizada: DEPÓSITO            |");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.Write("| Insira o valor desejado: ");
                    valor = Convert.ToInt32(Console.ReadLine());
                    depositarDinheiro();
                    System.Threading.Thread.Sleep(2700);
                    Console.Clear();
                    break;

                case 3:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|      Escolha realizada: VERIFICAR SALDO            |");
                    Console.WriteLine("|----------------------------------------------------|");
                    Console.Write("| Saldo disponível: ");
                    verificarSaldo();
                    System.Threading.Thread.Sleep(2700);
                    Console.Clear();
                    break;

                default:
                    break;
            }
        } while (escolha < 4);
    }

    static void Main() {
        Console.Clear();
        ContaBancaria conta = new ContaBancaria(1000);
        conta.selecao();
        
        Console.WriteLine("Saldo final: " + conta.verificarSaldo());
    }
}
