using System;
using System.IO;

public interface ILogger
{
    void Log(string mensagem);
}

public class LoggerConsole : ILogger
{
    public void Log(string mensagem)
    {
        Console.WriteLine($"[Console] {DateTime.Now}: {mensagem}");
    }
}

public class LoggerArquivo : ILogger
{
    private StreamWriter arquivo;

    public LoggerArquivo(string caminho)
    {
        arquivo = new StreamWriter(caminho, append: true);
    }

    public void Log(string mensagem)
    {
        arquivo.WriteLine($"[Arquivo] {DateTime.Now}: {mensagem}");
        arquivo.Flush();
    }

    ~LoggerArquivo()
    {
        arquivo.Close();
    }
}

public class ServicoEmail
{
    private readonly ILogger logger;

    public ServicoEmail(ILogger logger)
    {
        this.logger = logger;
    }

    public void Enviar(string destinatario, string mensagem)
    {
        logger.Log($"Enviando email para {destinatario}: {mensagem}");
        Console.WriteLine($"Email enviado para {destinatario}");
    }
}

class Program
{
    static void Main()
    {
        var emailConsole = new ServicoEmail(new LoggerConsole());
        emailConsole.Enviar("ana@email.com", "Oi Ana!");

        var emailArquivo = new ServicoEmail(new LoggerArquivo("log.txt"));
        emailArquivo.Enviar("carlos@email.com", "Olá Carlos!");

        Console.WriteLine("Programa finalizado.");
    }
}
