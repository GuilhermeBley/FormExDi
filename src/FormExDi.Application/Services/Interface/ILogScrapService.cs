﻿using FormExDi.Core.Model.Logger;

namespace FormExDi.Application.Services.Interface;

public interface ILogScrap
{
    string Path { get; }
}

public interface ILogScrapService<TQuest> : ILogScrap
    where TQuest : class
{
    LogMessage Information(string message, params object[] args);
    LogMessage Warning(string message, params object[] args);
    LogMessage Debug(string message, params object[] args);

    Task<LogMessage> InformationAsync(string message, params object[] args);
    Task<LogMessage> WarningAsync(string message, params object[] args);
    Task<LogMessage> DebugAsync(string message, params object[] args);
}