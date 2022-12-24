using FormExDi.Application.Model;
using System.Web;
using HtmlAgilityPack;

namespace FormExDi.Scrap.Quest.PiedadeMultasSelenium;

public interface IPiedadeMultaSeleniumQuery : IDisposable
{
    Task<IEnumerable<InfracaoModel>> GetInfracoesAsync(string placa, string renavam, CancellationToken cancellationToken = default);
}