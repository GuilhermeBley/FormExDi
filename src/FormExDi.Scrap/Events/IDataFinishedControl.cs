using BlScraper.Results;

namespace FormExDi.Scrap.Events
{
    public interface IDataFinishedControl
    {
        Task OnDataFinishedEventAsync(ResultBase dataCollected);
    }
}
