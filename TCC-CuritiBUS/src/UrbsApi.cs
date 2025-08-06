using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TCC_SENAI_CAUE_GUEDES
{
    public static class UrbsApi
    {
        #region campos privados

        private static readonly HttpClient client = new HttpClient(); // cliente http usado para fazer as requisições //
        private const string BaseUrl = "https://transporteservico.urbs.curitiba.pr.gov.br/"; // url base da api //
        private const string CodigoAcesso = "e494d"; // código de autenticação da api //

        #endregion

        #region construtor estático

        static UrbsApi()
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)"); // define o user-agent como navegador comum //
            client.Timeout = TimeSpan.FromSeconds(60); // tempo máximo de espera da requisição //
        }

        #endregion

        #region método de requisição segura

        private static async Task<JArray> ObterArraySeguro(string url, int maxRetries = 2)
        {
            int retryCount = 0;
            while (true)
            {
                CancellationTokenSource cts = null;
                try
                {
                    cts = new CancellationTokenSource();
                    cts.CancelAfter(client.Timeout); // define tempo limite da requisição //

                    var resposta = await client.GetStringAsync(url);
                    resposta = resposta.TrimStart(); // remove espaços em branco à esquerda //

                    string logPath = "log_resposta_api.txt"; // caminho do log da resposta //
                    File.AppendAllText(logPath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] URL: {url}\n{resposta}\n\n");

                    if (resposta.StartsWith("["))
                    {
                        return JArray.Parse(resposta); // resposta já é um array //
                    }
                    else if (resposta.StartsWith("{"))
                    {
                        JObject obj = JObject.Parse(resposta); // converte objeto em array //
                        var lista = new JArray();
                        foreach (var item in obj.Properties())
                            lista.Add(item.Value);
                        return lista;
                    }
                    else
                    {
                        MessageBox.Show("A resposta da API não é um JSON válido", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new JArray();
                    }
                }
                catch (TaskCanceledException) when (retryCount < maxRetries)
                {
                    retryCount++;
                    await Task.Delay(1000 * retryCount); // aguarda antes de tentar novamente //
                    continue;
                }
                catch (HttpRequestException httpEx)
                {
                    string mensagem = $"Erro de comunicação com a API URBS: {httpEx.Message}";
                    if (httpEx.InnerException != null)
                        mensagem += $"\nDetalhes: {httpEx.InnerException.Message}";

                    File.AppendAllText("log_erros_api.txt", $"[{DateTime.Now}] {mensagem}\n");
                    MessageBox.Show(mensagem, "Erro de rede", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new JArray();
                }
                catch (Newtonsoft.Json.JsonException jsonEx)
                {
                    string mensagem = $"Erro ao processar dados da API: {jsonEx.Message}";
                    File.AppendAllText("log_erros_api.txt", $"[{DateTime.Now}] {mensagem}\n");
                    MessageBox.Show(mensagem, "Erro de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new JArray();
                }
                catch (Exception ex)
                {
                    string mensagem = $"Ocorreu um erro inesperado: {ex.Message}\n\nStack: {ex.StackTrace}";
                    File.AppendAllText("log_erros_api.txt", $"[{DateTime.Now}] {mensagem}\n");
                    MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new JArray();
                }
                finally
                {
                    cts?.Dispose(); // libera recursos do token //
                }
            }
        }

        #endregion

        #region métodos públicos

        public static Task<JArray> ObterTodasLinhas() =>
            ObterArraySeguro($"{BaseUrl}getLinhas.php?c={CodigoAcesso}"); // busca todas as linhas de ônibus //

        public static Task<JArray> ObterMensagensPainel() =>
            ObterArraySeguro($"{BaseUrl}getMensagemPainel.php?c={CodigoAcesso}"); // busca mensagens de painéis //

        public static Task<JArray> ObterMensagensPainelComLinhas() =>
            ObterArraySeguro($"{BaseUrl}getMensagemPainelLinhas.php?c={CodigoAcesso}"); // busca mensagens com vínculos a linhas //

        public static Task<JArray> ObterOcorrenciasPorLinha(string codigoLinha = "")
        {
            string url = string.IsNullOrEmpty(codigoLinha)
                ? $"{BaseUrl}getOcorrenciaCCOporLinha.php?c={CodigoAcesso}"
                : $"{BaseUrl}getOcorrenciaCCOporLinha.php?cod={codigoLinha}&c={CodigoAcesso}";

            return ObterArraySeguro(url); // busca ocorrências por linha ou todas se vazia //
        }

        public static Task<JArray> ObterPontosDaLinha(string codigoLinha) =>
            ObterArraySeguro($"{BaseUrl}getPontosLinha.php?linha={codigoLinha}&c={CodigoAcesso}"); // busca os pontos de parada da linha //

        public static Task<JArray> ObterShapeDaLinha(string codigoLinha) =>
            ObterArraySeguro($"{BaseUrl}getShapeLinha.php?linha={codigoLinha}&c={CodigoAcesso}"); // busca o formato do itinerário da linha //

        public static async Task<string> ObterNomeDoShape(string shapeId)
        {
            int retryCount = 0;
            const int maxRetries = 2;

            while (true)
            {
                CancellationTokenSource cts = null;
                try
                {
                    cts = new CancellationTokenSource();
                    cts.CancelAfter(client.Timeout);

                    string url = $"{BaseUrl}getShapeName.php?shp={shapeId}&c={CodigoAcesso}";
                    return await client.GetStringAsync(url); // retorna o nome do shape diretamente //
                }
                catch (TaskCanceledException) when (retryCount < maxRetries)
                {
                    retryCount++;
                    await Task.Delay(1000 * retryCount);
                    continue;
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show($"Erro de comunicação ao obter nome do shape: {httpEx.Message}",
                        "Erro de rede", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro inesperado ao obter nome do shape: {ex.Message}",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                finally
                {
                    cts?.Dispose();
                }
            }
        }

        public static Task<JArray> ObterTrechosDaLinha(string codigoLinha) =>
            ObterArraySeguro($"{BaseUrl}getTrechosItinerarios.php?linha={codigoLinha}&c={CodigoAcesso}"); // busca os trechos que compõem o itinerário //

        public static Task<JArray> ObterTabelaHoraria(string codigoLinha) =>
            ObterArraySeguro($"{BaseUrl}getTabelaLinha.php?linha={codigoLinha}&c={CodigoAcesso}"); // busca a tabela de horários da linha //

        public static Task<JArray> ObterTabelaDoVeiculo(string prefixoCarro) =>
            ObterArraySeguro($"{BaseUrl}getTabelaVeiculo.php?carro={prefixoCarro}&c={CodigoAcesso}"); // busca a tabela do veículo específico //

        public static Task<JArray> ObterVeiculos(string codigoLinha) =>
            ObterArraySeguro($"{BaseUrl}getVeiculos.php?linha={codigoLinha}&c={CodigoAcesso}"); // busca os veículos ativos na linha //

        public static async Task<JObject> BuscarLinhaPorCodigoOuNome(string termoBusca)
        {
            var todasLinhas = await ObterTodasLinhas(); // obtém todas as linhas //

            foreach (var linha in todasLinhas)
            {
                string codigo = linha["codigo"]?.ToString() ?? "";
                string nome = linha["nome"]?.ToString() ?? "";

                if (codigo.Equals(termoBusca, StringComparison.OrdinalIgnoreCase) ||
                    nome.IndexOf(termoBusca, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return (JObject)linha; // retorna a linha que corresponde ao termo //
                }
            }

            return null; // nenhuma linha encontrada //
        }

        #endregion
    }
}
