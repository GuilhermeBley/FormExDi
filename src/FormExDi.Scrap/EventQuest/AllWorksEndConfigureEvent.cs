using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Model;
using BlScraper.Results;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.EventQuest
{
    /// <inheritdoc cref="IAllWorksEndConfigure{TQuest, TData}" path="*"/>
    public abstract class AllWorksEndConfigureEvent<TQuest, TData> : IAllWorksEndConfigure<TQuest, TData>
        where TQuest : Quest<TData>
        where TData : class
    {
        private readonly ISynchronizeInvoke? _syncInvoke;
        private readonly IAllWorksEndControl? _allWorksEndControl;

        /// <summary>
        /// Instance with sync invoke
        /// </summary>
        /// <param name="syncInvoke">Invokator</param>
        /// <param name="allWorksEndControl">control event</param>
        public AllWorksEndConfigureEvent(ISynchronizeInvoke? syncInvoke = null, IAllWorksEndControl? allWorksEndControl = null)
        {
            _syncInvoke = syncInvoke;
            _allWorksEndControl = allWorksEndControl;
        }

        public void OnFinished(IEnumerable<ResultBase<Exception?>> results)
        {
            OnFinishedEvent(results);

            _syncInvoke?.BeginInvoke(
                async () =>
                {
                    await OnFinishedInvokeAsync(results);

                    if (_allWorksEndControl is not null)
                        await _allWorksEndControl.OnAllWorksEndEventAsync(results);
                }, null);
        }

        /// <summary>
        /// Current thread of Quest invoke this method
        /// </summary>
        protected virtual void OnFinishedEvent(IEnumerable<ResultBase<Exception?>> results) { }


        /// <summary>
        /// Main thread invoke this method
        /// </summary>
        protected virtual async Task OnFinishedInvokeAsync(IEnumerable<ResultBase<Exception?>> results) { await Task.CompletedTask; }
    }
}
