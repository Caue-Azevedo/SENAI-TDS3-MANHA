using System;
using System.Threading;
using System.Text;

class Produto
{
    private string nome;
    private double preco;

    public Produto(string nome, double preco)
    {
        this.nome = nome;
        this.preco = preco;
    }

    public string GetNome()
    {
        return nome;
    }

    public void SetNome(string valor)
    {
        nome = valor;
    }

    public double GetPreco()
    {
        return preco;
    }

    public void SetPreco(double valor)
    {
        preco = valor;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

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
            Console.WriteLine("|\n|        Produto mais caro: " + maisCaro.GetNome() + " - R$" + maisCaro.GetPreco().ToString("F2"));
            Console.WriteLine("|        Média de preços: R$" + media.ToString("F2"));
            Console.WriteLine("|\n|        Produtos acima da média de preço:");

            foreach (var produto in produtos)
            {
                if (produto.GetPreco() > media)
                {
                    Console.WriteLine("|         " + produto.GetNome() + " - R$" + produto.GetPreco().ToString("F2"));
                    Thread.Sleep(100);
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
            soma += produto.GetPreco();
        }
        return soma / produtos.Length;
    }

    private static Produto ObterProdutoMaisCaro(Produto[] produtos)
    {
        Produto maisCaro = produtos[0];
        foreach (var produto in produtos)
        {
            if (produto.GetPreco() > maisCaro.GetPreco())
            {
                maisCaro = produto;
            }
        }
        return maisCaro;
    }
}
