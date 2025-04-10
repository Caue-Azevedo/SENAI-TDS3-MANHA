using System;
using System.Threading;

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }

    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Produto[] produtos = new Produto[5];

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("+------------------------------------------------+");
                Console.WriteLine("|             Cadastro do Produto " + (i + 1) + "              |");
                Console.WriteLine("+------------------------------------------------+");

                Console.Write("| Nome do produto: ");
                string nome = Console.ReadLine();

                double preco = ObterPrecoValido();

                produtos[i] = new Produto(nome, preco);

                Console.WriteLine("| Produto cadastrado com sucesso!");
                Thread.Sleep(1000);
            }

            double media = CalcularMediaPreco(produtos);
            Produto maisCaro = ObterProdutoMaisCaro(produtos);

            Console.Clear();
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|                  Resumo dos Produtos           |");
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|\n|        Produto mais caro: " + maisCaro.Nome + " - R$" + maisCaro.Preco.ToString("F2"));
            Console.WriteLine("|        Média de preços: R$" + media.ToString("F2"));
            Console.WriteLine("|\n|        Produtos acima da média de preço:");
            
        foreach (var produto in produtos)
            {
                if (produto.Preco > media)
                {
                    Console.WriteLine("|         " + produto.Nome + " - R$" + produto.Preco.ToString("F2"));
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine("+------------------------------------------------+");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    private static double ObterPrecoValido()
    {
        double preco;
        bool precoValido;

        do
        {
            Console.Write("| Preço do produto: R$");
            string input = Console.ReadLine();

            precoValido = double.TryParse(input, out preco) && preco >= 0;

            if (!precoValido)
            {
                Console.WriteLine("| Preço inválido. Digite um valor válido.");
                Thread.Sleep(1000);
            }

        } while (!precoValido);

        return preco;
    }

    private static double CalcularMediaPreco(Produto[] produtos)
    {
        double soma = 0;
        foreach (var produto in produtos)
        {
            soma += produto.Preco;
        }
        return soma / produtos.Length;
    }

    private static Produto ObterProdutoMaisCaro(Produto[] produtos)
    {
        Produto maisCaro = produtos[0];
        foreach (var produto in produtos)
        {
            if (produto.Preco > maisCaro.Preco)
            {
                maisCaro = produto;
            }
        }
        return maisCaro;
    }
}
