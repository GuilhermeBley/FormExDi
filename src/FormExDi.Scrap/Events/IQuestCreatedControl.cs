namespace FormExDi.Scrap.Events
{
    /// <summary>
    /// Class provides control event when quest is created
    /// </summary>
    public interface IQuestCreatedControl
    {
        /// <summary>
        /// OnCreatedEventAsync
        /// </summary>
        Task OnCreatedEventAsync(object questCreated);
    }
}
