using FormExDi.Application.Model;

namespace FormExDi.Scrap.Quest.PiedadeMultasSelenium;

public interface IPiedadeMultaSeleniumQuery : IDisposable
{
    Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam, CancellationToken cancellationToken = default);
}