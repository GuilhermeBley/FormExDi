using BlScraper.Results;

namespace FormExDi.Scrap.Events
{
    /// <summary>
    /// Class provides control event when all works end
    /// </summary>
    public interface IAllWorksEndControl
    {
        /// <summary>
        /// OnAllWorksEventAsync
        /// </summary>
        Task OnAllWorksEventAsync(IEnumerable<ResultBase<Exception?>> resultFinished);
    }
}
