using BlScraper.Results;
using BlScraper.Results.Models;

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
        Task OnAllWorksEndEventAsync(IEnumerable<EndEnumerableModel> resultFinished);
    }
}
