using BlScraper.Results;
using FormExDi.Application.Model;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.Quest.PiedadeMultas
{
    public class PiedadeMultaAllWorksEndConfigure : AllWorksEndConfigureEvent<PiedadeMultaQuest, VehicleModel>
    {
        public PiedadeMultaAllWorksEndConfigure(ISynchronizeInvoke syncInvoke, IAllWorksEndControl allWorksEndControl) : base(syncInvoke, allWorksEndControl)
        {
        }

        protected override async Task OnFinishedInvokeAsync(IEnumerable<ResultBase<Exception?>> results)
        {
            await Task.Delay(60*1000);
        }
    }
}
