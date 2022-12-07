using BlScraper.Model;
using FormExDi.Application.Args;
using FormExDi.Presentation.Model;
using FormExDi.Presentation.Services.Interfaces;

namespace FormExDi.Presentation.Services.Implementation
{
    internal class InfoService : IInfoService
    {
        private readonly IInitArgs _initArgs;

        public InfoService(IInitArgs initArgs)
            => _initArgs = initArgs;

        public async Task<ScrapData> GetDataByModel(IModelScraper? modelScraper)
        {
            await Task.CompletedTask;

            if (modelScraper is null)
                return ScrapData.None;
            
            return ScrapData.Create(
                modelScraper.IdScraper.ToString(),
                _initArgs.QuestName,
                string.Empty,
                modelScraper.DtRun,
                modelScraper.DtEnd,
                modelScraper.CountSearched,
                int.MaxValue,
                modelScraper.CountScraper, 
                modelScraper.CountProgress,
                modelScraper.State == ModelStateEnum.Disposed);
        }
    }
}
