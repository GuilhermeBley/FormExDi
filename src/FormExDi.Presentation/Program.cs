using FormExDi.Infrastructure.Extension;
using FormExDi.Scrap.Extension.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlScraper.DependencyInjection.Extension.Builder;
using FormExDi.Presentation.Ui;

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
        services
            .AddSingleton<RunScrapGUI>()
            .AddControls<RunScrapGUI>(
                typeof(RunScrapGUI), 
                typeof(RunScrapGUI), 
                typeof(RunScrapGUI), 
                typeof(RunScrapGUI), 
                typeof(RunScrapGUI), 
                typeof(RunScrapGUI))
            .AddSingleton<Application.Args.IInitArgs>(new Args.InitArgs(Environment.GetCommandLineArgs()))
            .AddScraperBuilder(
                (builder) => builder.AddAssembly(typeof(Scrap.Quest.PiedadeMultas.PiedadeMultaQuest).Assembly))
            .AddRepositories()
            .AddServices()
            .AddScrap();
    }
}