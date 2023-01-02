using BlScraper.DependencyInjection.ConfigureModel.Filter;
using BlScraper.Results;
using FormExDi.Application.Services.Interface;

namespace FormExDi.Scrap.Filters;

public class DataFinishedLogFilter : IDataFinishedConfigureFilter
{
    private readonly ILogScrapService _log;

    public DataFinishedLogFilter(ILogScrapService log)
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
