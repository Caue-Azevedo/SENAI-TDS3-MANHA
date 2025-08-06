using System;
using System.IO;

public static class Logger
{
    #region campos privados

    // caminho da pasta onde os logs serão armazenados //
    private static readonly string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

    #endregion

    #region métodos públicos

    // salva a resposta de uma api em um arquivo de log com data e hora //
    public static void SaveApiResponse(string apiName, string response)
    {
        try
        {
            // verifica se a pasta de logs existe e cria caso não exista //
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }

            // gera timestamp para nomear o arquivo //
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // define o nome e o caminho completo do arquivo //
            string fileName = $"{apiName}_Response_{timestamp}.txt";
            string fullPath = Path.Combine(logFolder, fileName);

            // grava a resposta no arquivo //
            File.WriteAllText(fullPath, response);
        }
        catch (Exception ex)
        {
            // exibe erro no console caso ocorra falha ao salvar o log //
            Console.WriteLine("Erro ao salvar log de resposta da API: " + ex.Message);
        }
    }

    #endregion
}