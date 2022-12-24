using FormExDi.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FormExDi.Infrastructure.Extension;

public static class DiQueries
{
    public static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddClients()
            .AddScoped(typeof(FormExDi.Scrap.Quest.PiedadeMultas.IPiedadeMultaQuery), typeof(Queries.PiedadeMultas.PiedadeMultaQuery))
            .AddScoped(typeof(FormExDi.Scrap.Quest.PiedadeMultasSelenium.IPiedadeMultaSeleniumQuery), typeof(Queries.PiedadeMultas.PiedadeMultaSeleniumQuery));
    }

    private static IServiceCollection AddClients(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped(
                (ServiceProvider) => new HtmlAgilityPack.HtmlDocument()
                {
                    OptionDefaultStreamEncoding = System.Text.Encoding.UTF8,
                    OptionEmptyCollection = true
                })
            .AddScoped((ServiceProvider) => {
                HttpClientHandler handler = new()
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                };
                var client = new HttpClient(handler);

                client.DefaultRequestHeaders
                    .Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36");
                client.DefaultRequestHeaders
                    .Connection
                    .Add("keep-alive");
                client.DefaultRequestHeaders
                    .Accept
                    .TryParseAdd("*/*");
                return client;
            })
            .AddScoped<OpenQA.Selenium.IWebDriver>((serviceProvider) =>
            {   
                var initArg = serviceProvider.GetRequiredService<Application.Args.IInitArgs>();
                var chromeDriverService = serviceProvider.GetRequiredService<OpenQA.Selenium.Chrome.ChromeDriverService>();
                var options = serviceProvider.GetRequiredService<IOptions<SeleniumOptions>>();
                var config = new OpenQA.Selenium.Chrome.ChromeOptions();
                config.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                config.AddArgument("--start-maximized");
                config.AddArgument("--ignore-certificate-errors");
                config.AddArgument("--silent");
                config.AddArgument("--disable-gpu");
                config.AddArgument("--log-level=3");
                config.AddArgument("--no-sandbox");
                config.AddArgument("--disable-application-cache");
                config.AddArgument("--disable-dev-shm-usage");
                config.AddArgument("disable-infobars");
                config.AddArgument("--disable-extensions");
                config.AddArgument("--window-size=1280,720");
                if (initArg.ContainsArgs("headless"))
                    config.AddArgument("--headless");
                return new OpenQA.Selenium.Chrome.ChromeDriver(chromeDriverService, config);
            })
            .AddSingleton((serviceProvider) =>
            {
                var chromeDriverService = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = false;
                return chromeDriverService;
            });
    }
}