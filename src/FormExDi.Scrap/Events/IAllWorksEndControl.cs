using BlScraper.Results;

namespace FormExDi.Scrap.Events
{
    public interface IAllWorksEndControl
    {
        Task OnAllWorksEventAsync(IEnumerable<ResultBase<Exception?>> resultFinished);
    }
}
