using BlScraper.Model;
using FormExDi.Application.Model;
using FormExDi.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public class PiedadeMultaQuest : Quest<VehicleModel>
{
    private readonly IPiedadeMultaQuery _piedadeMultaQuery;
    private readonly IInfracaoService _infracaoService;

    public PiedadeMultaQuest(IPiedadeMultaQuery piedadeMultaQuery, IInfracaoService infracaoService)
    {
        _piedadeMultaQuery = piedadeMultaQuery;
        _infracaoService = infracaoService;
    }

    public override QuestResult Execute(VehicleModel data, CancellationToken cancellationToken = default)
    {
        cancellationToken.WaitHandle.WaitOne(1000 * 5);

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

