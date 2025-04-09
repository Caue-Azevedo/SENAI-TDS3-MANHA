using System;
 
class Usuario
{
    private string nome;
    private int idade;
    private int altura;
 
    public string Nome
    {
        get => nome;
        set => nome = ValidarNome(value) ? value
            : throw new ArgumentException("Nome não pode ser vazio ou conter apenas espaços.");
    }
 
    public int Idade
    {
        get => idade;
        set => idade = ValidarIdade(value) ? value
            : throw new ArgumentOutOfRangeException("A idade deve estar em 0 e 130 anos.");
    }
 
    public int Altura
    {
        get => altura;
        set => altura = value;
    }
 
    public Usuario(string nome, int idade, int altura)
    {
        Nome = nome;
        Idade = idade;
        Altura = altura;
    }
 
    private static bool ValidarNome(string nome)
    {
        return !string.IsNullOrWhiteSpace(nome);
    }
 
    private static bool ValidarIdade(int idade)
    {
        return idade >= 0 && idade <= 130;
    }
 
    public void Apresentar()
    {
        Console.Clear();  
        Console.WriteLine("|=============================================================================|");
        Console.WriteLine($"|    Olá, meu nome é {Nome}, tenho {Idade} anos e minha altura é {Altura} cm.");
        Console.WriteLine("|=============================================================================|");
    }
}
 
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Clear();        
            Console.WriteLine("|===========================|");
            Console.WriteLine("|    Cadastro de Usuário    |");
            Console.WriteLine("|---------------------------|");
 
            string nome = ObterNomeValido();
            int idade = ObterIdadeValida();
            int altura = ObterAlturaValida();
 
            Usuario usuario = new Usuario(nome, idade, altura);
            usuario.Apresentar();
        }
        catch (Exception ex)
        {
            Console.WriteLine("|-------------------------------|");
            Console.WriteLine($"| Erro: {ex.Message} |");
            Console.WriteLine("|-------------------------------|");
        }
        finally
        {
            Console.WriteLine("\n\n|---------------------------------------|");
            Console.WriteLine("| Pressione qualquer tecla para sair... |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("|               Saindo...               |");
            Console.WriteLine("|=======================================|");
           
            Console.ReadKey();
        }
    }
 
    private static string ObterNomeValido()
    {
        string nome;
        do
        {
            Console.Write("| Digite o nome: ");
            nome = Console.ReadLine()?.Trim() ?? string.Empty;
 
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("\n|---------------------------------------------|");
                Console.WriteLine("| Nome inválido. Por favor, digite novamente. |");
                Console.WriteLine("|---------------------------------------------|\n");
            }
        } while (string.IsNullOrWhiteSpace(nome));
 
        return nome;
    }
 
    private static int ObterIdadeValida()
    {
        int idade;
        bool idadeValida;
        do
        {
            Console.Write("| Digite a idade: ");
            string input = Console.ReadLine();
            idadeValida = int.TryParse(input, out idade) && idade >= 0 && idade <= 130;
 
            if (!idadeValida)
            {
                Console.WriteLine("\n|-----------------------------------------------------------|");
                Console.WriteLine("| Idade inválida. Por favor, digite um valor entre 0 e 130. |");
                Console.WriteLine("|-----------------------------------------------------------|\n");
            }
        } while (!idadeValida);
 
        return idade;
    }
 
    private static int ObterAlturaValida()
    {
        int altura;
        bool alturaValida;
        do
        {
            Console.Write("| Digite a altura (em cm): ");
            string input = Console.ReadLine();
            alturaValida = int.TryParse(input, out altura) && altura > 0;
 
            if (!alturaValida)
            {
                Console.WriteLine("\n|-----------------------------------------------------|");
                Console.WriteLine("| Altura inválida. Por favor, digite um valor válido. |");
                Console.WriteLine("|-----------------------------------------------------|\n");
            }
        } while (!alturaValida);
 
        return altura;
    }
}
