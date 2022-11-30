namespace FormExDi.Scrap.Events
{
    /// <summary>
    /// Class provides control event when data collected
    /// </summary>
    public interface IDataCollectedControl
    {
        /// <summary>
        /// OnCollectedAsync
        /// </summary>
        Task OnDataCollectedAsync(IEnumerable<object> resultCollected);
    }
}
