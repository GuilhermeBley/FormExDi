namespace FormExDi.Infrastructure.Options;

public sealed class ConnectionOptions
{
    public const string Section = "MySql";

    public string ConnectionString { get; set; } = string.Empty;
}