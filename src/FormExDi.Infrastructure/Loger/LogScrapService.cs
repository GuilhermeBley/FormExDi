using BlScraper.DependencyInjection.ConfigureBuilder;
using BlScraper.DependencyInjection.Model.Context;
using BlScraper.Model;
using FormExDi.Application.Services.Interface;
using FormExDi.Core.Model.Logger;
using Serilog.Core;

namespace FormExDi.Infrastructure.Loger;

internal class LogCurrentScrapService : ILogScrapService
{
    private readonly ILogScrapService? _holderLog;
    public string Path => _holderLog?.Path ?? string.Empty;

    public LogCurrentScrapService(IServiceProvider serviceProvider, IScrapContextAccessor scrapContextAcessor, IMapQuest mapQuest)
    {
        var context = scrapContextAcessor.ScrapContext;

        if (context is null)
            return;

        var tuple = mapQuest.GetAvailableQuestsAndData().FirstOrDefault(tuple => tuple.Quest == context.TypeScrap);

        if (tuple.Quest is null)
            return;

        _holderLog = (ILogScrapService?)serviceProvider.GetService(typeof(LogScrapService<,>).MakeGenericType(tuple.Quest, tuple.Data));
    }

    public LogMessage Debug(string message, params object[] args)
    {
        if (_holderLog is null)
            return LogMessage.None;

        return _holderLog.Debug(message, args);
    }

    public async Task<LogMessage> DebugAsync(string message, params object[] args)
    {
        if (_holderLog is null)
        {
            await Task.CompletedTask;
            return LogMessage.None;
        }

        return await _holderLog.DebugAsync(message, args);
    }

    public LogMessage Information(string message, params object[] args)
    {
        if (_holderLog is null)
            return LogMessage.None;

        return _holderLog.Information(message, args);
    }

    public async Task<LogMessage> InformationAsync(string message, params object[] args)
    {
        if (_holderLog is null)
        {
            await Task.CompletedTask;
            return LogMessage.None;
        }

        return await _holderLog.InformationAsync(message, args);
    }

    public LogMessage Warning(string message, params object[] args)
    {
        if (_holderLog is null)
            return LogMessage.None;

        return _holderLog.Warning(message, args);
    }

    public async Task<LogMessage> WarningAsync(string message, params object[] args)
    {
        if (_holderLog is null)
        {
            await Task.CompletedTask;
            return LogMessage.None;
        }

        return await _holderLog.WarningAsync(message, args);
    }
}

internal class LogScrapService<TQuest, TData> : ILogScrapService<TQuest>
    where TQuest : Quest<TData>
    where TData : class
{
    private readonly object _lock = new object();
    private readonly Func<Logger> _logFactory;
    private Logger? __log = null;
    private Logger _log { get 
        { 
            if (__log is null) 
                lock (_lock)
                {
                    if (__log is null)
                        __log = _logFactory.Invoke();
                }
            return __log ?? throw new ArgumentNullException("log");
        }}
    private readonly string _path;

    public string Path => _path;

    public LogScrapService(string path, Func<Logger> logFactory)
    {
        _path = path;
        _logFactory = logFactory;
    }

    public LogMessage Debug(string message, params object[] args)
    {
        var logMessage = LogMessage.Create<TQuest>(message, args);
        _log.Debug(logMessage.ToString(), args);
        return logMessage;
    }

    public async Task<LogMessage> DebugAsync(string message, params object[] args)
    {
        await Task.CompletedTask;
        return Debug(message, args);
    }

    public LogMessage Information(string message, params object[] args)
    {
        var logMessage = LogMessage.Create<TQuest>(message, args);
        _log.Information(logMessage.ToString(), args);
        return logMessage;
    }

    public async Task<LogMessage> InformationAsync(string message, params object[] args)
    {
        await Task.CompletedTask;
        return Information(message, args);
    }

    public LogMessage Warning(string message, params object[] args)
    {
        var logMessage = LogMessage.Create<TQuest>(message, args);
        _log.Warning(logMessage.ToString(), args);
        return logMessage;
    }

    public async Task<LogMessage> WarningAsync(string message, params object[] args)
    {
        await Task.CompletedTask;
        return Warning(message, args);
    }
}

