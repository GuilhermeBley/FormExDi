using FormExDi.Application.Model;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public interface IPiedadeMultaQuery : IDisposable
{
    Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam, CancellationToken cancellationToken = default);
}