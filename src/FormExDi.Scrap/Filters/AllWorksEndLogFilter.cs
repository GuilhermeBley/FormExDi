using BlScraper.DependencyInjection.ConfigureModel.Filter;
using BlScraper.Results.Models;
using FormExDi.Application.Services.Interface;

namespace FormExDi.Scrap.Filters;

public class AllWorksEndLogFilter : IAllWorksEndConfigureFilter
{

    private readonly ILogScrapService _log;

    public AllWorksEndLogFilter(ILogScrapService log)
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
