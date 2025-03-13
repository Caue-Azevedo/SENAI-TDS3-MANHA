using System;

public class Carro {
    private int velocidadeAtual;
    private int marchaAtual;

    public Carro() {
        velocidadeAtual = 0;
        marchaAtual = 1;
    }

    public void acelerar(int incremento) {
        if (incremento > 0) {
            velocidadeAtual += incremento;
            Console.WriteLine("|====================================================|");
            Console.WriteLine($"|            O carro acelerou para {velocidadeAtual} km/h.          |");
            Console.WriteLine("|====================================================|");
        } else {
            Console.WriteLine("|====================================================|");
            Console.WriteLine("|       O valor de incremento deve ser positivo.       |");
            Console.WriteLine("|====================================================|");
        }
        System.Threading.Thread.Sleep(900);
        Console.Clear();
    }

    public void frear(int decremento) {
        if (decremento > 0) {
            velocidadeAtual -= decremento;
            if (velocidadeAtual < 0) velocidadeAtual = 0;
            Console.WriteLine("|====================================================|");
            Console.WriteLine($"|            O carro reduziu para {velocidadeAtual} km/h.           |");
            Console.WriteLine("|====================================================|");
        } else {
            Console.WriteLine("|====================================================|");
            Console.WriteLine("|      O valor de decremento deve ser positivo.      |");
            Console.WriteLine("|====================================================|");
        }
        System.Threading.Thread.Sleep(900);
        Console.Clear();
    }

    public void trocarMarcha(int novaMarcha) {
        if (novaMarcha > 0) {
            marchaAtual = novaMarcha;
            Console.WriteLine("|====================================================|");
            Console.WriteLine($"|              Marcha alterada para {marchaAtual}.               |");
            Console.WriteLine("|====================================================|");
        } else {
            Console.WriteLine("|====================================================|");
            Console.WriteLine("|        A marcha deve ser um valor positivo.        |");
            Console.WriteLine("|====================================================|");
        }
        System.Threading.Thread.Sleep(900);
        Console.Clear();
    }

    public void verificarVelocidadeAtual() {
        Console.WriteLine("|====================================================|");
        Console.WriteLine($"|             Velocidade atual: {velocidadeAtual} km/h             |");
        Console.WriteLine("|====================================================|");
        System.Threading.Thread.Sleep(900);
        Console.Clear();
    }

    public void menu() {
        int opcao;

        do {
            Console.WriteLine("|===================================================|");
            Console.WriteLine("|           Qual ação deseja realizar?              |");
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("| 1) Acelerar                                       |");
            Console.WriteLine("| 2) Frear                                          |");
            Console.WriteLine("| 3) Trocar marcha                                  |");
            Console.WriteLine("| 4) Verificar velocidade                           |");
            Console.WriteLine("| 5) Sair                                           |");
            Console.WriteLine("|===================================================|");
            Console.Write("| Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    Console.Write("| Digite o valor para acelerar: ");
                    acelerar(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.Write("| Digite o valor para frear: ");
                    frear(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("| Digite a nova marcha: ");
                    trocarMarcha(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    verificarVelocidadeAtual();
                    break;
                case 5:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|                      Saindo...                     |");
                    Console.WriteLine("|====================================================|");
                    break;
                default:
                    Console.WriteLine("|====================================================|");
                    Console.WriteLine("|          Opção inválida. Tente novamente.          |");
                    Console.WriteLine("|====================================================|");
                    break;
            }

            System.Threading.Thread.Sleep(900);
            Console.Clear();

        } while (opcao != 5);
    }

    static void Main() {
        Console.Clear();
        Carro carro = new Carro();
        carro.menu();
    }
}
