using BlScraper.DependencyInjection.ConfigureModel.Filter;
using BlScraper.Results.Models;
using FormExDi.Application.Model;
using FormExDi.Application.Services.Interface;

namespace FormExDi.Scrap.Quest.PiedadeMultas;
public class PiedadeMultaAllWorksEndFilter : IAllWorksEndConfigureFilter<PiedadeMultaQuest, VehicleModel>
{

    private readonly ILogScrapService<PiedadeMultaQuest> _log;

    public PiedadeMultaAllWorksEndFilter(ILogScrapService<PiedadeMultaQuest> log)
    {
        _log = log;
    }

    public async Task OnFinished(EndEnumerableModel results)
    {
        if (results.AllSearched)
            await _log.InformationAsync("Search ended with success.");
        else
            await _log.WarningAsync("Search ended incomplete.");
    }
}
