using Microsoft.Extensions.DependencyInjection;
using FormExDi.Scrap.Events;
using System.ComponentModel;

namespace FormExDi.Scrap.Extension.DependencyInjection;

public static class DiControlsExtension
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
        if (!typeof(ISynchronizeInvoke).IsAssignableFrom(synchronizeInvoke))
            throw new ArgumentException($"{nameof(synchronizeInvoke)} must be assignable to {typeof(ISynchronizeInvoke).FullName}.");
        
        services.AddSingleton(typeof(ISynchronizeInvoke), synchronizeInvoke);

        AddControls(services, allWorksEndControl, dataCollectedControl, dataFinishedControl,
            getArgsControl, questCreatedControl, questExceptionControl);

        return services;
    }

    public static IServiceCollection AddControls(
        this IServiceCollection services,
        Func<IServiceProvider, ISynchronizeInvoke> synchronizeInvoke,
        Type? allWorksEndControl = null,
        Type? dataCollectedControl = null,
        Type? dataFinishedControl = null,
        Type? getArgsControl = null,
        Type? questCreatedControl = null,
        Type? questExceptionControl = null)
    {
        services.AddSingleton(typeof(ISynchronizeInvoke), (serviceProvider) => synchronizeInvoke.Invoke(serviceProvider));

        AddControls(services, allWorksEndControl, dataCollectedControl, dataFinishedControl,
            getArgsControl, questCreatedControl, questExceptionControl);

        return services;
    }

    public static IServiceCollection AddControls(
        this IServiceCollection services,
        Type? allWorksEndControl = null,
        Type? dataCollectedControl = null,
        Type? dataFinishedControl = null,
        Type? getArgsControl = null,
        Type? questCreatedControl = null,
        Type? questExceptionControl = null)
    {
        if (allWorksEndControl is not null && !typeof(IAllWorksEndControl).IsAssignableFrom(allWorksEndControl))
            throw new ArgumentException($"{nameof(IAllWorksEndControl)} isn't assignable from {nameof(allWorksEndControl)}.");

        if (allWorksEndControl is not null)
            services.AddSingleton(typeof(IAllWorksEndControl), allWorksEndControl);

        if (dataCollectedControl is not null && !typeof(IDataCollectedControl).IsAssignableFrom(dataCollectedControl))
            throw new ArgumentException($"{nameof(IDataCollectedControl)} isn't assignable from {nameof(dataCollectedControl)}.");

        if (dataCollectedControl is not null)
            services.AddSingleton(typeof(IDataCollectedControl), dataCollectedControl);

        if (dataFinishedControl is not null && !typeof(IDataFinishedControl).IsAssignableFrom(dataFinishedControl))
            throw new ArgumentException($"{nameof(IDataFinishedControl)} isn't assignable from {nameof(dataFinishedControl)}.");

        if (dataFinishedControl is not null)
            services.AddSingleton(typeof(IDataFinishedControl), dataFinishedControl);

        if (getArgsControl is not null && !typeof(IGetArgsControl).IsAssignableFrom(getArgsControl))
            throw new ArgumentException($"{nameof(IGetArgsControl)} isn't assignable from {nameof(getArgsControl)}.");

        if (getArgsControl is not null)
            services.AddSingleton(typeof(IGetArgsControl), getArgsControl);

        if (questCreatedControl is not null && !typeof(IQuestCreatedControl).IsAssignableFrom(questCreatedControl))
            throw new ArgumentException($"{nameof(IQuestCreatedControl)} isn't assignable from {nameof(questCreatedControl)}.");

        if (questCreatedControl is not null)
            services.AddSingleton(typeof(IQuestCreatedControl), questCreatedControl);

        if (questExceptionControl is not null && !typeof(IQuestExceptionControl).IsAssignableFrom(questExceptionControl))
            throw new ArgumentException($"{nameof(IQuestExceptionControl)} isn't assignable from {nameof(questExceptionControl)}.");

        if (questExceptionControl is not null)
            services.AddSingleton(typeof(IQuestExceptionControl), questExceptionControl);

        return services;
    }
}