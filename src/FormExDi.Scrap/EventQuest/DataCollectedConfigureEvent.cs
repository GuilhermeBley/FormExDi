using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Model;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.EventQuest
{
    /// <inheritdoc cref="IDataCollectedConfigure{TQuest, TData}" path="*"/>
    public abstract class DataCollectedConfigureEvent<TQuest, TData> : IDataCollectedConfigure<TQuest, TData>
        where TQuest : Quest<TData>
        where TData : class
    {
        private readonly ISynchronizeInvoke? _syncInvoke;
        private readonly IDataCollectedControl? _dataCollectedControl;
        
        /// <summary>
        /// Instance with sync invoke
        /// </summary>
        /// <param name="syncInvoke">Invokator</param>
        /// <param name="dataCollectedControl">control event</param>
        public DataCollectedConfigureEvent(ISynchronizeInvoke? syncInvoke = null, IDataCollectedControl? dataCollectedControl = null)
        {
            _syncInvoke = syncInvoke;
            _dataCollectedControl = dataCollectedControl;
        }

        public void OnCollected(IEnumerable<TData> dataCollected)
        {
            OnCollectedEvent(dataCollected);

            _syncInvoke?.BeginInvoke(
                async () =>
                {
                    await OnCollectedInvokeAsync(dataCollected);

                    if (_dataCollectedControl is not null)
                        await _dataCollectedControl.OnCollectedAsync(dataCollected);
                }, null);
        }

        /// <summary>
        /// Current thread of Quest invoke this method
        /// </summary>
        protected virtual void OnCollectedEvent(IEnumerable<TData> dataCollected) { }


        /// <summary>
        /// Main thread invoke this method
        /// </summary>
        protected virtual async Task OnCollectedInvokeAsync(IEnumerable<TData> dataCollected) { await Task.CompletedTask; }
    }
}
