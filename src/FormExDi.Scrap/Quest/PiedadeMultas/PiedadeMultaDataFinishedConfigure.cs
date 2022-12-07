using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Results;
using FormExDi.Application.Model;

namespace FormExDi.Scrap.Quest.PiedadeMultas
{
    internal class PiedadeMultaDataFinishedConfigure : IDataFinishedConfigure<PiedadeMultaQuest, VehicleModel>
    {
        public void OnDataFinished(ResultBase<VehicleModel> resultFinished)
        {
            throw new NotImplementedException();
        }
    }
}
