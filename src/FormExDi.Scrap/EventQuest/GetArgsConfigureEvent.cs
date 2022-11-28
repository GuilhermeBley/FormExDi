using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Model;
using BlScraper.Results;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.EventQuest
{
    /// <inheritdoc cref="IGetArgsConfigure{TQuest, TData}" path="*"/>
    public abstract class GetArgsConfigureEvent<TQuest, TData> : IGetArgsConfigure<TQuest, TData>
        where TQuest : Quest<TData>
        where TData : class
    {
        private readonly ISynchronizeInvoke? _syncInvoke;
        private readonly IGetArgsControl? _getArgsControl;

        /// <summary>
        /// Instance with sync invoke
        /// </summary>
        /// <param name="syncInvoke">Invokator</param>
        /// <param name="getArgsControl">control event</param>
        public GetArgsConfigureEvent(ISynchronizeInvoke? syncInvoke = null, IGetArgsControl? getArgsControl = null)
        {
            _syncInvoke = syncInvoke;
            _getArgsControl = getArgsControl;
        }

        public object[] GetArgs()
        {
            var args = GetArgsFinishedEvent();

            _syncInvoke?.BeginInvoke(
                async () =>
                {
                    await GetArgsInvokeAsync(args);

                    if (_getArgsControl is not null)
                        await _getArgsControl.OnGetArgsEventAsync(args);
                }, null);

            return args;
        }

        public abstract object[] GetArgsFinishedEvent();

        public virtual async Task GetArgsInvokeAsync(object[] args) { await Task.CompletedTask; }
    }
}
