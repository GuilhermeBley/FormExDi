using Microsoft.Extensions.DependencyInjection;

namespace FormExDi.Infrastructure.Extension;

public static class DiQueries
{
    public static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped(typeof(FormExDi.Scrap.Quest.PiedadeMultas.IPiedadeMultaQuery), typeof(Queries.PiedadeMultas.PiedadeMultaQuery));
    }
}