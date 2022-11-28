using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Model;
using BlScraper.Results;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.EventQuest
{
    /// <inheritdoc cref="IDataFinishedConfigure{TQuest, TData}" path="*"/>
    public abstract class DataFinishedConfigureEvent<TQuest, TData> : IDataFinishedConfigure<TQuest, TData>
        where TQuest : Quest<TData>
        where TData : class
    {
        private readonly IDataFinishedControl? _dataFinishedControl;
        private readonly ISynchronizeInvoke? _syncInvoke;

        /// <summary>
        /// Instance with sync invoke
        /// </summary>
        /// <param name="syncInvoke">Invokator</param>
        /// <param name="dataFinishedControl">control event</param>
        public DataFinishedConfigureEvent(IDataFinishedControl? dataFinishedControl = null)
        {
            _dataFinishedControl = dataFinishedControl;
        }

        public void OnDataFinished(ResultBase<TData> resultFinished)
        {
            OnDataFinishedEvent(resultFinished);

            _syncInvoke?.BeginInvoke(
                async () =>
                {
                    await OnDataFinishedInvokeAsync(resultFinished);

                    if (_dataFinishedControl is not null)
                        await _dataFinishedControl.OnDataFinishedEventAsync(resultFinished);
                }, null);
        }

        public void OnDataFinishedEvent(ResultBase<TData> resultFinished) { }
        public async Task OnDataFinishedInvokeAsync(ResultBase<TData> resultFinished) { await Task.CompletedTask; }
    }
}
