using FormExDi.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.File;

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
                var opt = new LogConfig(tuple.Quest.Name);
                
                var iLogType = typeof(ILogScrapService<>).MakeGenericType(tuple.Quest);
                var logType = typeof(LogScrapService<,>).MakeGenericType(tuple.Quest, tuple.Data);
                serviceCollection.AddSingleton(iLogType,
                    Activator.CreateInstance(logType, new object[]
                    {
                        $"{Environment.CurrentDirectory}{opt.FileName.Replace("./", "\\").Replace("/", "\\")}", 
                        () => new LoggerConfiguration().WriteTo.File(
                        opt.FileName, encoding: opt.Encoding,
                        outputTemplate: "[{Level:u3}] {Message:lj}{NewLine}{Exception}",
                        shared: true).MinimumLevel.Information().CreateLogger()
                    }) ?? throw new ArgumentNullException("Log")
                );                       
            }

            return serviceCollection;
        }
    }
}
