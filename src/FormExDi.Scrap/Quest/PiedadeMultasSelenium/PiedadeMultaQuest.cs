using BlScraper.Model;
using FormExDi.Application.Model;
using FormExDi.Application.Services.Interface;

namespace FormExDi.Scrap.Quest.PiedadeMultasSelenium;

public class PiedadeMultaSeleniumQuest : Quest<VehicleModel>
{
    private readonly IPiedadeMultaSeleniumQuery _piedadeMultaQuery;
    private readonly IInfracaoService _infracaoService;

    public PiedadeMultaSeleniumQuest(IPiedadeMultaSeleniumQuery piedadeMultaQuery, IInfracaoService infracaoService)
    {
        _piedadeMultaQuery = piedadeMultaQuery;
        _infracaoService = infracaoService;
    }

    public override QuestResult Execute(VehicleModel data, CancellationToken cancellationToken = default)
    {
        foreach (var multa in _piedadeMultaQuery.GetInfracoesAsync(
            data.Plate, data.Renavam, cancellationToken).GetAwaiter().GetResult())
        {
            if (multa.DtInfracao.Year < 2016) // Business rule
                continue;

            _infracaoService.AddAsync(multa).GetAwaiter().GetResult();
        }

        return QuestResult.Ok();
    }

    public override void Dispose()
    {
        _piedadeMultaQuery?.Dispose();
    }
}

