using BlScraper.Model;
using FormExDi.Presentation.Model;

namespace FormExDi.Presentation.Services.Interfaces
{
    internal interface IInfoService
    {
        Task<ScrapData> GetDataByModel(IModelScraper? modelScraper);
    }
}
