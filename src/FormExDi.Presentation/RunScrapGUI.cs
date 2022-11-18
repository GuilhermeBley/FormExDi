using BlScraper.Model;

namespace FormExDi.Presentation;

public partial class RunScrapGUI : Form
{
    public RunScrapGUI(IModelScraper model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        InitializeComponent();
    }
}
