using FormExDi.Application.Services.Interface;
using BlScraper.DependencyInjection.ConfigureModel.Filter;
using FormExDi.Application.Model;
using BlScraper.Results;

namespace FormExDi.Scrap.Quest.PiedadeMultas;

public class PiedadeDataFinishedConfigureFilterLog : IDataFinishedConfigureFilter<PiedadeMultaQuest, VehicleModel>
{
    private readonly ILogScrapService<PiedadeMultaQuest> _log;

    public PiedadeDataFinishedConfigureFilterLog(ILogScrapService<PiedadeMultaQuest> log)
    {
        _log = log;
    }

    public async Task OnDataFinished(ResultBase resultFinished)
    {
        var vehicle = resultFinished.ResultBaseObj ?? throw new ArgumentNullException("result");
        if (resultFinished.IsSuccess)
            await _log.InformationAsync("Search successfully {@vehicle}.", vehicle);
        else
            await _log.WarningAsync("Search failed {@vehicle}.", vehicle);
    }
}
