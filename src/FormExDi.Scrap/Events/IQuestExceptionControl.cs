namespace FormExDi.Scrap.Events
{
    public interface IQuestExceptionControl
    {
        Task OnOccursExceptionEventAsync(Exception exception, object data, QuestResult result);
    }
}
