namespace FormExDi.Scrap.Events
{
    public interface IDataCollectedControl
    {
        Task OnCollectedAsync(IEnumerable<object> resultFinished);
    }
}
