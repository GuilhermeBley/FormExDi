using BlScraper.DependencyInjection.ConfigureModel;
using BlScraper.Results;
using BlScraper.Results.Models;
using FormExDi.Application.Model;

namespace FormExDi.Scrap.Quest.PiedadeMultas
{
    public class PiedadeMultaAllWorksEndConfigure : IAllWorksEndConfigure<PiedadeMultaQuest, VehicleModel>
    {
        public void OnFinished(EndEnumerableModel results)
        {
            throw new NotImplementedException();
        }
    }
}
