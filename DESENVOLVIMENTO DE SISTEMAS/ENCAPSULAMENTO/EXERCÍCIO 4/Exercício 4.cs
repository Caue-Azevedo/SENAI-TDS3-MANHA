using System;
using System.Collections.Generic;
using System.Threading;

class Livro
{
    private string titulo;
    private string isbn;
    private static List<string> IsbnsCadastrados = new List<string>();

    public string Titulo
    {
        get => titulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("|    Título não pode ser vazio!        |");
                Console.WriteLine("+--------------------------------------+");
            }
            else
            {
                titulo = value;
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("|      Título definido com sucesso     |");
                Console.WriteLine("+--------------------------------------+");
            }
        }
    }

    public string ISBN => isbn;

    public Livro(string titulo, string isbn)
    {
        if (!ValidarISBN(isbn))
        {
            Console.WriteLine("+------------------------------------------+");
            Console.WriteLine("| ISBN inválido! Deve conter 13 números.   |");
            Console.WriteLine("+------------------------------------------+");
            return;
        }

        if (IsbnsCadastrados.Contains(isbn))
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|   ISBN já cadastrado em outro livro!       |");
            Console.WriteLine("+--------------------------------------------+");
            return;
        }

        this.titulo = titulo;
        this.isbn = isbn;
        IsbnsCadastrados.Add(isbn);
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine("|    Livro criado com sucesso!         |");
        Console.WriteLine("+--------------------------------------+");
    }

    private bool ValidarISBN(string isbn)
    {
        return isbn.Length == 13 && long.TryParse(isbn, out _);
    }
}

class Program
{
    static List<Livro> livros = new List<Livro>();

    static void Main()
    {
        int opcao = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|         Sistema de Livros            |");
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("| 1 - Adicionar livro                  |");
            Console.WriteLine("| 2 - Listar livros                    |");
            Console.WriteLine("| 0 - Sair                             |");
            Console.WriteLine("+--------------------------------------+");
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

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("|         Cadastro de Livro            |");
                    Console.WriteLine("+--------------------------------------+");

                    Console.Write("| Título: ");
                    string titulo = Console.ReadLine();

                    Console.Write("| ISBN (13 dígitos): ");
                    string isbn = Console.ReadLine();

                    Livro novoLivro = new Livro(titulo, isbn);
                    if (!string.IsNullOrWhiteSpace(novoLivro.Titulo) && novoLivro.ISBN != null)
                    {
                        livros.Add(novoLivro);
                    }

                    Thread.Sleep(1500);
                    break;

                case 2:
                    Console.Clear();
                    if (livros.Count == 0)
                    {
                        Console.WriteLine("+--------------------------------------+");
                        Console.WriteLine("|      Nenhum livro cadastrado.        |");
                        Console.WriteLine("+--------------------------------------+");
                    }
                    else
                    {
                        Console.WriteLine("+------------------- Livros -------------------+");
                        for (int i = 0; i < livros.Count; i++)
                        {
                            Console.WriteLine($"| {i + 1}. Título: {livros[i].Titulo}");
                            Console.WriteLine($"|    ISBN: {livros[i].ISBN}");
                            Console.WriteLine("+----------------------------------------------+");
                        }
                    }

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
            Console.WriteLine("+------------------------------------------------+");
            Console.WriteLine("|   Pressione qualquer tecla para continuar...   |");
            Console.WriteLine("+------------------------------------------------+");
            Console.ReadKey();

        } while (true);
    }
}
