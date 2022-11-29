using Microsoft.Extensions.DependencyInjection;

namespace FormExDi.Scrap.Extension.DependencyInjection;

public static class DiScrapExtension
{
    public static IServiceCollection AddScrap(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(Quest.PiedadeMultas.IPiedadeMultaQuery), typeof(Quest.PiedadeMultas.PiedadeMultaQuery));
    }
}