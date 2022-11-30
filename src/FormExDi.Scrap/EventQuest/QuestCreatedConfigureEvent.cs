using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Model;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.EventQuest
{
    /// <inheritdoc cref="IQuestCreatedConfigure{TQuest, TData}" path="*"/>
    public abstract class QuestCreatedConfigureEvent<TQuest, TData> : IQuestCreatedConfigure<TQuest, TData>
        where TQuest : Quest<TData>
        where TData : class
    {
        private readonly ISynchronizeInvoke? _syncInvoke;
        private readonly IQuestCreatedControl? _questCreatedControl;

        /// <summary>
        /// Instance with sync invoke
        /// </summary>
        /// <param name="syncInvoke">Invokator</param>
        /// <param name="questCreatedControl">control event</param>
        public QuestCreatedConfigureEvent(ISynchronizeInvoke? syncInvoke = null, IQuestCreatedControl? questCreatedControl = null)
        {
            _syncInvoke = syncInvoke;
            _questCreatedControl = questCreatedControl;
        }

        public void OnCreated(TQuest questCreated)
        {
            OnCreatedEvent(questCreated);

            _syncInvoke?.BeginInvoke(
                async () =>
                {
                    await OnCreatedInvokeAsync(questCreated);

                    if (_questCreatedControl is not null)
                        await _questCreatedControl.OnQuestCreatedEventAsync(questCreated);
                }, null);
        }

        /// <summary>
        /// Current thread of Quest invoke this method
        /// </summary>
        protected virtual void OnCreatedEvent(TQuest results) { }


        /// <summary>
        /// Main thread invoke this method
        /// </summary>
        protected virtual async Task OnCreatedInvokeAsync(TQuest questCreated) { await Task.CompletedTask; }
    }
}
