namespace FormExDi.Core.Model.Loger;

public class LogMessage
{
    public int IdScrap { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public DateTime DtLog { get; private set; }
    public object[] Args { get; private set; }

    private LogMessage(int idScrap, string message, DateTime dtLog, object[] args)
    {
        IdScrap = idScrap;
        Message = message;
        DtLog = dtLog;
        Args = args;
    }

    public static LogMessage Create(string message, int idScrap = 0, params object[] args)
    {
        if (message is null)
            message = string.Empty;

        if (idScrap < 0)
            idScrap = 0;

        return new LogMessage(idScrap, message, DateTime.Now, args);
    }
}
