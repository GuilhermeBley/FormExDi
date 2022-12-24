using FormExDi.Application.Services.Interface;
using BlScraper.DependencyInjection.ConfigureModel.Filter;
using FormExDi.Application.Model;
using BlScraper.Results;

namespace FormExDi.Scrap.Quest.PiedadeMultasSelenium;

public class PiedadeDataFinishedConfigureFilterLog : IDataFinishedConfigureFilter<PiedadeMultaSeleniumQuest, VehicleModel>
{
    private readonly ILogScrapService<PiedadeMultaSeleniumQuest> _log;

    public PiedadeDataFinishedConfigureFilterLog(ILogScrapService<PiedadeMultaSeleniumQuest> log)
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
