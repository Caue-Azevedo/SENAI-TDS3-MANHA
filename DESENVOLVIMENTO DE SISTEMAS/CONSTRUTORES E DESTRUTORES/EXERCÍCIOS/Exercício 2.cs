using System;

class Carro
{
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public int Ano { get; set; }

    public Carro()
    {
    }

    public Carro(string modelo, string marca, int ano)
    {
        Modelo = modelo;
        Marca = marca;
        Ano = ano;
    }

    public Carro(Carro outroCarro)
    {
        Modelo = outroCarro.Modelo;
        Marca = outroCarro.Marca;
        Ano = outroCarro.Ano;
    }

    ~Carro()
    {
        Console.WriteLine($"Destrutor chamado. O carro {Modelo} está sendo removido da memória.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Carro carro1 = new Carro("Uno", "Fiat", 1980);
        Carro carro2 = new Carro(carro1);

        Console.WriteLine($"Carro 1: {carro1.Modelo}, {carro1.Marca}, {carro1.Ano}");
        Console.WriteLine($"Carro 2 (cópia): {carro2.Modelo}, {carro2.Marca}, {carro2.Ano}");

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
