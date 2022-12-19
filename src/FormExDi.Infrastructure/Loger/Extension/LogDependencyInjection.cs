using FormExDi.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FormExDi.Infrastructure.Loger.Extension
{
    public static class LogDependencyInjection
    {
        /// <summary>
        /// Add scrap log
        /// </summary>
        /// <param name="serviceCollection">service collection</param>
        /// <param name="assemblies">Quest assemblies</param>
        public static IServiceCollection AddScrapLog(this IServiceCollection serviceCollection, params System.Reflection.Assembly[] assemblies)
        {
            foreach (var tuple 
                in BlScraper.DependencyInjection.ConfigureBuilder.MapQuestFactory.Create(assemblies).GetAvailableQuestsAndData())
            {
                var iLogType = typeof(ILogScrapService<>).MakeGenericType(tuple.Quest);
                var logType = typeof(LogScrapService<,>).MakeGenericType(tuple.Quest, tuple.Data);
                serviceCollection.AddSingleton(iLogType, logType);                       
            }

            return serviceCollection;
        }
    }
}
