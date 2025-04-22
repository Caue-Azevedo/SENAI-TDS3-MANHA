using System;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa() : this("Sem nome", 0)
    {
        Console.WriteLine("Construtor padrão chamado. Objeto criado.");
    }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
        Console.WriteLine($"Construtor com parâmetros chamado. {Nome} criado(a).");
    }

    public Pessoa(Pessoa outraPessoa) : this(outraPessoa.Nome, outraPessoa.Idade)
    {
        Console.WriteLine($"Construtor de cópia chamado. Cópia de {Nome} criada.");
    }

    ~Pessoa()
    {
        Console.WriteLine($"Destrutor chamado. {Nome} está sendo removido da memória.");
    }

    public void ExibirInfo()
    {
        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
    }
}

class Program
{
    static void Main()
    {
        Pessoa p1 = new Pessoa();
        Pessoa p2 = new Pessoa("Alice", 30);
        Pessoa p3 = new Pessoa(p2);

        p1.ExibirInfo();
        p2.ExibirInfo();
        p3.ExibirInfo();

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
