using Microsoft.Extensions.DependencyInjection;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.Extension;

public static class DiControls
{
    public static IServiceCollection AddControls<TSyncInv>(
        this IServiceCollection services,
        Type? allWorksEndControl = null,
        Type? dataCollectedControl = null,
        Type? dataFinishedControl = null,
        Type? getArgsControl = null,
        Type? questCreatedControl = null,
        Type? questExceptionControl = null)
        where TSyncInv : class, ISynchronizeInvoke
    {
        return AddControls(
            services,
            typeof(TSyncInv), 
            allWorksEndControl, 
            dataCollectedControl, 
            dataFinishedControl, 
            getArgsControl, 
            questCreatedControl, 
            questExceptionControl);
    }

    public static IServiceCollection AddControls(
        this IServiceCollection services,
        Type synchronizeInvoke,
        Type? allWorksEndControl = null,
        Type? dataCollectedControl = null,
        Type? dataFinishedControl = null,
        Type? getArgsControl = null,
        Type? questCreatedControl = null,
        Type? questExceptionControl = null)
    {
        if (typeof(ISynchronizeInvoke).IsAssignableFrom(synchronizeInvoke))
            throw new ArgumentException($"{nameof(synchronizeInvoke)} must be assignable to {typeof(ISynchronizeInvoke).FullName}.");
        
        services.AddSingleton(typeof(ISynchronizeInvoke), synchronizeInvoke);

        if (allWorksEndControl is not null)
            services.AddSingleton(typeof(IAllWorksEndControl), allWorksEndControl);

        if (dataCollectedControl is not null)
            services.AddSingleton(typeof(IDataCollectedControl), dataCollectedControl);

        if (dataFinishedControl is not null)
            services.AddSingleton(typeof(IDataFinishedControl), dataFinishedControl);

        if (getArgsControl is not null)
            services.AddSingleton(typeof(IGetArgsControl), getArgsControl);

        if (questCreatedControl is not null)
            services.AddSingleton(typeof(IQuestCreatedControl), questCreatedControl);

        if (questExceptionControl is not null)
            services.AddSingleton(typeof(IQuestExceptionControl), questExceptionControl);

        return services;
    }
}