using BlScraper.DependencyInjection.ConfigureModel;
using FormExDi.Application.Model;

namespace FormExDi.Scrap.Quest.PiedadeMultas
{
    internal class PiedadeMultaOnCollectedDataConfigure : IDataCollectedConfigure<PiedadeMultaQuest, VehicleModel>
    {
        public void OnCollected(IEnumerable<VehicleModel> dataCollected)
        {
            
        }
    }
}
