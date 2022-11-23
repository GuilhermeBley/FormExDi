using BlScraper.DependencyInjection.ConfigureModel;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.EventQuest
{
    public abstract class QuestExceptionConfigureEvent<TQuest, TData> : IQuestExceptionConfigure<TQuest, TData>
        where TQuest : Quest<TData>
        where TData : class
    {
        private readonly ISynchronizeInvoke? _syncInvoke;
        private readonly IQuestExceptionControl? _questExceptionControl;

        public QuestExceptionConfigureEvent(ISynchronizeInvoke? syncInvoke = null, IQuestExceptionControl? questExceptionControl = null)
        {
            _syncInvoke = syncInvoke;
            _questExceptionControl = questExceptionControl;
        }

        public QuestResult OnOccursException(Exception ex, TData data)
        {

            var result = OnOccursExceptionEvent(ex, data);

            _syncInvoke?.BeginInvoke(
                async () =>
                {
                    await OnOccursExceptionInvokeAsync(ex, data, result);

                    if (_questExceptionControl is not null)
                        await _questExceptionControl.OnOccursExceptionEventAsync(ex, data, result);
                }, null);

            return result;
        }

        /// <summary>
        /// Current thread of Quest invoke this method
        /// </summary>
        protected virtual QuestResult OnOccursExceptionEvent(Exception ex, TData data) { return QuestResult.RetrySame(); }

        /// <summary>
        /// Main thread invoke this method
        /// </summary>
        protected virtual async Task OnOccursExceptionInvokeAsync(Exception ex, TData data, QuestResult result) { await Task.CompletedTask; }
    }
}
