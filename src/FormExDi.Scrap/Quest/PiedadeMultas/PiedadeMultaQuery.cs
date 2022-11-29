using FormExDi.Application.Model;
using FormExDi.Scrap.Extension.Html;
using HtmlAgilityPack;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public interface IPiedadeMultaQuery
{
    Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam);
}

internal class PiedadeMultaQuery : IPiedadeMultaQuery
{
    private const string url = "http://187.111.170.202:8081/";
    private const string urlMultas = "http://187.111.170.202:8081/Home/_Resultado?Placa={placaL}-{placaR}&Renavam={renavam}";
    private readonly HttpClient _client;
    private readonly HtmlDocument _document;

    public PiedadeMultaQuery(HttpClient client, HtmlDocument document)
    {
        _client = client;
        _document = document;
    }

    public async Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam)
    {
        if (placa is null || placa.Length != 7)
            throw new ArgumentException("Placa in invalid format.");

        using (var response = await _client.GetAsync(url))
        {
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException();

            _document.LoadHtml(await response.Content.ReadAsStringAsync());
        }

        var formParams = _document.DocumentNode.GetFormsParams();

        string placaL = string.Concat(placa.Take(4));
        string placaR = string.Concat(placa.Skip(3));
        using (var response = 
            await _client.GetAsync(urlMultas.Replace("placaL", placaL).Replace("placaR", placaR).Replace("{renavam}", renavam)))
        {
            var txt = await response.Content.ReadAsStringAsync();

            if (txt.ToUpper().Contains("NÃO FORAM ENCONTRADAS INFRAÇÕES"))
                return Enumerable.Empty<InfracaoModel>();

            throw new NotImplementedException();
        }
    }
}