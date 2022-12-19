using BlScraper.Model;
using FormExDi.Application.Services.Interface;
using FormExDi.Core.Model.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormExDi.Infrastructure.Loger;

internal class LogScrapService<TQuest, TData> : ILogScrapService<TQuest>
    where TQuest : Quest<TData>
    where TData : class
{

    public LogMessage Debug(string message, params object[] args)
    {
        throw new NotImplementedException();
    }

    public Task<LogMessage> DebugAsync(string message, params object[] args)
    {
        throw new NotImplementedException();
    }

    public LogMessage Information(string message, params object[] args)
    {
        throw new NotImplementedException();
    }

    public Task<LogMessage> InformationAsync(string message, params object[] args)
    {
        throw new NotImplementedException();
    }

    public LogMessage Warning(string message, params object[] args)
    {
        throw new NotImplementedException();
    }

    public Task<LogMessage> WarningAsync(string message, params object[] args)
    {
        throw new NotImplementedException();
    }
}

