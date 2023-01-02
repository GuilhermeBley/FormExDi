namespace FormExDi.Core.Model.Logger;

public class LogMessage
{
    public static readonly LogMessage None = new LogMessage(0, string.Empty, string.Empty, DateTime.MinValue);

    public int IdScrap { get; private set; }
    public string ScrapName { get; private set; } = string.Empty;
    public string Message { get; private set; } = string.Empty;
    public DateTime DtLog { get; private set; }
    public object[] Args { get; private set; }

    private LogMessage(int idScrap, string scrapName, string message, DateTime dtLog, params object[] args)
    {
        IdScrap = idScrap;
        Message = message;
        DtLog = dtLog;
        Args = args;
        ScrapName = scrapName;
    }

    public override string ToString()
    {
        return $"{ScrapName}|{IdScrap} - [{DtLog.ToString("{yyyy-MM-dd HH:mm:ss}")}]: {Message}";
    }

    public static LogMessage Create<TScrap>(string message, params object[] args)
    {
        if (message is null)
            message = string.Empty;

        return new LogMessage(Thread.CurrentThread.ManagedThreadId, typeof(TScrap).Name, message, DateTime.Now, args);
    }
}
