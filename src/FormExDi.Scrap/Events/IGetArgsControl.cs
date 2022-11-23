namespace FormExDi.Scrap.Events
{
    public interface IGetArgsControl
    {
        Task OnGetArgsEventAsync(object[] dataCollected);
    }
}
