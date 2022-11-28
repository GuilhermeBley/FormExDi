namespace FormExDi.Scrap.Events
{
    /// <summary>
    /// Class provides control event when args is collected
    /// </summary>
    public interface IGetArgsControl
    {
        /// <summary>
        /// OnGetArgsEventAsync
        /// </summary>
        Task OnGetArgsEventAsync(object[] dataCollected);
    }
}
