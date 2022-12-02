using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Model;

namespace FormExDi.Scrap.EventQuest
{
    /// <summary>
    /// Configure necessary events, as <see cref="DataCollectedConfigureEvent{TQuest, TData}"/> and <see cref="AllWorksEndConfigureEvent{TQuest, TData}"/>.
    /// </summary>
    public abstract class RequiredConfigureEvent<TQuest, TData> : RequiredConfigure<TQuest, TData>
        where TQuest : Quest<TData>
        where TData : class
    {
        public sealed override bool IsRequiredDataCollected => true;
        public sealed override bool IsRequiredAllWorksEnd => true;
        public sealed override bool IsRequiredDataFinished => true;
    }
}
