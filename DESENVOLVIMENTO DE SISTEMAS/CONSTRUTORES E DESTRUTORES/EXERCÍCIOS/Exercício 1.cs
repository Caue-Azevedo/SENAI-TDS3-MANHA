using System;

class Livro
{
    private string titulo;
    private string autor;
    private int anoPublicacao;

    public Livro()
    {
        titulo = "Desconhecido";
        autor = "Anônimo";
        anoPublicacao = 0;
    }

    public Livro(string titulo, string autor, int anoPublicacao)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.anoPublicacao = anoPublicacao;
    }

    public void ExibirDetalhes()
    {
    
        Console.WriteLine($"Detalhes: título: {titulo}, autor: {autor}, ano de publicação: {anoPublicacao}");
    }
}

class Program
{
    static void Main()
    {
        Console.Clear();
        Livro livro1 = new Livro();
        livro1.ExibirDetalhes();

        Livro livro2 = new Livro("1984", "George Orwell", 1949);
        livro2.ExibirDetalhes();
    }
}
