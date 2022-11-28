using FormExDi.Application.Model;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public interface IPiedadeMultaQuery
{
    Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam);
}

internal class PiedadeMultaQuery : IPiedadeMultaQuery
{
    private const string url = "";
    private readonly HttpClient _client;

    public PiedadeMultaQuery(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam)
    {
        using (var response = await _client.GetAsync(url))
        {
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException();
            
            
        }
    }
}