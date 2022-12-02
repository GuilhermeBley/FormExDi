using BlScraper.Model;
using FormExDi.Presentation.Model;
using FormExDi.Presentation.Services.Interfaces;

namespace FormExDi.Presentation.Services.Implementation
{
    internal class InfoService : IInfoService
    {
        public async Task<ScrapData> GetDataByModel(IModelScraper modelScraper)
        {
            await Task.CompletedTask;
            return ScrapData.Create(
                modelScraper.IdScraper.ToString(),
                string.Empty,
                string.Empty,
                modelScraper.DtRun,
                null,
                0,
                0,
                modelScraper.CountScraper,
                0);
        }
    }
}
