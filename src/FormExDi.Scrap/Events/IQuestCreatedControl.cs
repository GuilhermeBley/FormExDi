namespace FormExDi.Scrap.Events
{
    public interface IQuestCreatedControl
    {
        Task OnCreatedEventAsync(object questCreated);
    }
}
