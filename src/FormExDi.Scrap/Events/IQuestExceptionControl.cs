using BlScraper.Model;

namespace FormExDi.Scrap.Events
{
    /// <summary>
    /// Class provides control event when quest thrown an exception
    /// </summary>
    public interface IQuestExceptionControl
    {
        /// <summary>
        /// OnOccursExceptionEventAsync
        /// </summary>
        Task OnOccursExceptionEventAsync(Exception exception, object data, QuestResult result);
    }
}
