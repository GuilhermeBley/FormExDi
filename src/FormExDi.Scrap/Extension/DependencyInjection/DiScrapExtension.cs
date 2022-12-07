using Microsoft.Extensions.DependencyInjection;

namespace FormExDi.Scrap.Extension.DependencyInjection;

public static class DiScrapExtension
{
    public static IServiceCollection AddScrap(this IServiceCollection services)
    {
        AddScrapInternal(services);
        return services
            .AddScoped<HtmlAgilityPack.HtmlDocument>(
                (ServiceProvider) => new HtmlAgilityPack.HtmlDocument(){
                    OptionDefaultStreamEncoding = System.Text.Encoding.UTF8,
                    OptionEmptyCollection = true
                })
            .AddScoped<HttpClient>((ServiceProvider) => {
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
            });
    }

    private static IServiceCollection AddScrapInternal(IServiceCollection services)
    {
        return services
            .AddScoped(typeof(Quest.PiedadeMultas.IPiedadeMultaQuery), typeof(Quest.PiedadeMultas.PiedadeMultaQuery));
    }
}