using BlScraper.Results;

namespace FormExDi.Scrap.Events
{
    /// <summary>
    /// Class provides control event when data finished
    /// </summary>
    public interface IDataFinishedControl
    {
        /// <summary>
        /// OnDataFinishedEventAsync
        /// </summary>
        Task OnDataFinishedEventAsync(ResultBase dataCollected);
    }
}
