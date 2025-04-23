using System;

public class Produto
{
    public string Nome { get; }
    public decimal Preco { get; }
    public int Estoque { get; }

    public Produto(string nome, decimal preco, int estoque)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do produto é obrigatório.");

        if (preco <= 0)
            throw new ArgumentException("Preço deve ser maior que zero.");

        if (estoque < 0)
            throw new ArgumentException("Estoque não pode ser negativo.");

        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public override string ToString()
    {
        return $"{Nome} - R${Preco:F2} - Estoque: {Estoque}";
    }
}

public class ProdutoBuilder
{
    private string? nome;
    private decimal preco;
    private int estoque;

    public ProdutoBuilder ComNome(string nome)
    {
        this.nome = nome;
        return this;
    }

    public ProdutoBuilder ComPreco(decimal preco)
    {
        this.preco = preco;
        return this;
    }

    public ProdutoBuilder ComEstoque(int estoque)
    {
        this.estoque = estoque;
        return this;
    }

    public Produto Build()
    {
        return new Produto(nome!, preco, estoque);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var produto = new ProdutoBuilder()
                .ComNome("Smartphone")
                .ComPreco(1999.90m)
                .ComEstoque(10)
                .Build();

            Console.WriteLine("Produto criado com sucesso:");
            Console.WriteLine(produto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar produto: {ex.Message}");
        }
    }
}
