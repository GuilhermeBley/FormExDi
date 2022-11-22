using BlScraper.DependencyInjection.Builder;

namespace FormExDi.Presentation;

public partial class RunScrapGUI : Form
{
    private readonly IScrapBuilder _builder;

    public RunScrapGUI(IScrapBuilder scrapBuilder)
    {
        if (scrapBuilder is null)
            throw new ArgumentNullException(nameof(scrapBuilder));

        _builder = scrapBuilder;

        InitializeComponent();
    }
}
