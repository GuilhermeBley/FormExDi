using FormExDi.Application.Model;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.Quest.PiedadeMultas
{
    internal class PiedadeMultaDataFinishedConfigure : DataFinishedConfigureEvent<PiedadeMultaQuest, VehicleModel>
    {
        public PiedadeMultaDataFinishedConfigure(ISynchronizeInvoke syncInvoke, IDataFinishedControl dataFinishedControl) 
            : base(syncInvoke, dataFinishedControl)
        {
        }
    }
}
