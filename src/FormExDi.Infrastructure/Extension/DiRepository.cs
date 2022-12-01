using FormExDi.Application.Services.Implementation;
using FormExDi.Application.Services.Interface;
using FormExDi.Application.UoW;
using FormExDi.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FormExDi.Infrastructure.Extension;

public static class DiRepository
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<MySqlDbSession>()
            .AddScoped<IDbSession>(x => x.GetRequiredService<MySqlDbSession>())
            .AddScoped<IUnitOfWork>(x => x.GetRequiredService<MySqlDbSession>())
            .AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository))
            .AddScoped(typeof(IInfracaoRepository), typeof(InfracaoRepository))
            .AddAutoMapper(typeof(Mappings.InfrastructureProfile));
    }

    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IVehicleService, VehicleService>()
            .AddScoped<IInfracaoService, InfracaoService>();
    }
}