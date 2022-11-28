using Microsoft.Extensions.DependencyInjection;

namespace FormExDi.Scrap.Extension;

public static class DiScrap
{
    public static IServiceCollection AddScrap(IServiceCollection services)
    {
        return services
            .AddScoped(typeof(Quest.PiedadeMultas.IPiedadeMultaQuery), typeof(Quest.PiedadeMultas.PiedadeMultaQuery));
    }
}