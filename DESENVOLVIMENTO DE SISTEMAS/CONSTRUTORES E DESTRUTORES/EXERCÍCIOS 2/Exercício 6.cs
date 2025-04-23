using System;

class Veiculo
{
    private string marca;
    private string modelo;

    public string Marca => marca;
    public string Modelo => modelo;

    public Veiculo(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        Console.WriteLine("Construtor Veiculo chamado.");
    }
}

class Carro : Veiculo
{
    private int numeroDePortas;

    public int NumeroDePortas => numeroDePortas;

    public Carro(string marca, string modelo, int numeroDePortas)
        : base(marca, modelo)
    {
        this.numeroDePortas = numeroDePortas;
        Console.WriteLine("Construtor Carro chamado.");
    }
}

class CarroEsportivo : Carro
{
    private int velocidadeMaxima;

    public int VelocidadeMaxima => velocidadeMaxima;

    public CarroEsportivo(string marca, string modelo, int numeroDePortas, int velocidadeMaxima)
        : base(marca, modelo, numeroDePortas)
    {
        this.velocidadeMaxima = velocidadeMaxima;
        Console.WriteLine("Construtor CarroEsportivo chamado.");
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Portas: {NumeroDePortas}, Velocidade Máxima: {VelocidadeMaxima} km/h");
    }
}

class Program
{
    static void Main()
    {
        CarroEsportivo meuEsportivo = new CarroEsportivo("Ferrari", "F8 Tributo", 2, 340);
        meuEsportivo.MostrarInfo();
    }
}
