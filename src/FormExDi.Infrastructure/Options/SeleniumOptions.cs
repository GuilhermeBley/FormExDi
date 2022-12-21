namespace FormExDi.Infrastructure.Options;

public class SeleniumOptions
{
    public const string Section = "Selenium";

    public string PathDownload { get; set; } = string.Empty;
    public string PathSelenium { get; set; } = string.Empty;
}
