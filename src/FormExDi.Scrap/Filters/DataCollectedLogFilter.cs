using BlScraper.DependencyInjection.ConfigureModel.Filter;
using FormExDi.Application.Services.Interface;

namespace FormExDi.Scrap.Filters;

public class DataCollectedLogFilter : IDataCollectedConfigureFilter
{
    private readonly ILogScrapService _log;

    public DataCollectedLogFilter(ILogScrapService log)
    {
        _log = log;
    }

    public async Task OnCollected(IEnumerable<object> dataCollected)
    {
        await _log.InformationAsync($"Search started with {dataCollected.Count()} data to search.");
    }
}

