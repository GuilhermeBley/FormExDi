using FormExDi.Infrastructure.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlScraper.DependencyInjection.Extension.Builder;
using FormExDi.Presentation.Ui;
using FormExDi.Presentation.Services.Implementation;
using FormExDi.Presentation.Services.Interfaces;
using FormExDi.Infrastructure.Loger.Extension;

namespace FormExDi.Presentation;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, builder) =>
            {
                // Add other configuration files...
                builder.AddJsonFile("appsettings.json", optional:false);
                builder.AddUserSecrets(typeof(RunScrapGUI).Assembly, true);
            })
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(services);
                services.Configure<Infrastructure.Options.ConnectionOptions>(
                    context.Configuration.GetSection(Infrastructure.Options.ConnectionOptions.Section));
                services.Configure<Infrastructure.Options.SeleniumOptions>(
                    context.Configuration.GetSection(Infrastructure.Options.SeleniumOptions.Section));
            })
            .ConfigureLogging(logging =>
            {
                // Add other loggers...
            })
            .Build();

        var services = host.Services;
        var mainForm = services.GetRequiredService<RunScrapGUI>();
        System.Windows.Forms.Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var scrapAssemblies = new System.Reflection.Assembly[] { typeof(Scrap.Quest.PiedadeMultas.PiedadeMultaQuest).Assembly };
        services
            .AddSingleton<RunScrapGUI>()
            .AddSingleton<Application.Args.IInitArgs>(new Args.InitArgs(Environment.GetCommandLineArgs()))
            .AddScraperBuilder(
                (builder) => 
                builder.AddAssembly(scrapAssemblies)
                .AddAllWorksEndConfigureFilter<Scrap.Filters.AllWorksEndLogFilter>()
                .AddDataCollectedConfigureFilter<Scrap.Filters.DataCollectedLogFilter>()
                .AddDataFinishedConfigureFilter<Scrap.Filters.DataFinishedLogFilter>())
            .AddRepositories()
            .AddServices()
            .AddQueries()
            .AddScrapLog(scrapAssemblies)
            .AddScoped<IInfoService, InfoService>();
    }
}