using BlScraper.DependencyInjection.ConfigureModel.Filter;
using BlScraper.Results.Models;
using FormExDi.Application.Model;
using FormExDi.Application.Services.Interface;

namespace FormExDi.Scrap.Quest.PiedadeMultasSelenium;
public class PiedadeMultaAllWorksEndFilter : IAllWorksEndConfigureFilter<PiedadeMultaSeleniumQuest, VehicleModel>
{

    private readonly ILogScrapService<PiedadeMultaSeleniumQuest> _log;

    public PiedadeMultaAllWorksEndFilter(ILogScrapService<PiedadeMultaSeleniumQuest> log)
    {
        _log = log;
    }

    public async Task OnFinished(EndEnumerableModel results)
    {
        if (results.AllSearched)
            await _log.InformationAsync("Search ended with success.");
        else
            await _log.WarningAsync("Search ended incomplete. Ex: {e}", string.Join('\n', results.Select(v => ((Exception?)v.ResultBaseObj)?.Message)));
    }
}
