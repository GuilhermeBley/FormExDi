using FormExDi.Application.Model;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.Quest.PiedadeMultas
{
    internal class PiedadeMultaOnCollectedDataConfigure : DataCollectedConfigureEvent<PiedadeMultaQuest, VehicleModel>
    {
        public PiedadeMultaOnCollectedDataConfigure(ISynchronizeInvoke syncInvoke, IDataCollectedControl dataCollectedControl) : base(syncInvoke, dataCollectedControl)
        {
        }

        protected override async Task OnCollectedInvokeAsync(IEnumerable<VehicleModel> dataCollected)
        {
            await Task.CompletedTask;
        }
    }
}
