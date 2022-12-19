using BlScraper.Model;
using FormExDi.Application.Services.Interface;
using FormExDi.Core.Model.Logger;
using Serilog.Core;

namespace FormExDi.Infrastructure.Loger;

internal class LogScrapService<TQuest, TData> : ILogScrapService<TQuest>
    where TQuest : Quest<TData>
    where TData : class
{
    private readonly Logger _log;
    private readonly string _path;

    public string Path => _path;

    public LogScrapService(string path, Logger log)
    {
        _path = path;
        _log = log;
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

