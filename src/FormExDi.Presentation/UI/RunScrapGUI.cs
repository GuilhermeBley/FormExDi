using BlScraper.DependencyInjection.Builder;
using BlScraper.Model;
using BlScraper.Results;
using FormExDi.Application.Args;
using FormExDi.Scrap.Events;

namespace FormExDi.Presentation.Ui;

public partial class RunScrapGUI : Form, IAllWorksEndControl, IDataCollectedControl, IDataFinishedControl, IGetArgsControl, IQuestCreatedControl, IQuestExceptionControl
{
    private readonly object _lock = new object();
    private readonly IScrapBuilder _builder;
    private readonly string _questName;
    private IModelScraper? _model;


    public RunScrapGUI(IScrapBuilder scrapBuilder, IInitArgs initArgs)
    {
        if (scrapBuilder is null)
            throw new ArgumentNullException(nameof(scrapBuilder));

        if (initArgs is null)
            throw new ArgumentNullException(nameof(initArgs));

        if (string.IsNullOrEmpty(_questName))
            throw new ArgumentNullException(nameof(initArgs.QuestName));

        _builder = scrapBuilder;
        _questName = initArgs.QuestName;

        InitializeComponent();
    }

    public async Task OnAllWorksEndEventAsync(IEnumerable<ResultBase<Exception?>> resultFinished)
    {
        await TryDisposeModel();
    }

    public async Task OnDataCollectedAsync(IEnumerable<object> resultCollected)
    {
        ProgressBarSearchs.Value = 0;
        ProgressBarSearchs.Minimum = 0;
        ProgressBarSearchs.Maximum = resultCollected.Count();

        await Task.CompletedTask;
    }

    public async Task OnQuestCreatedEventAsync(object questCreated)
    {
        await Task.CompletedTask;
    }

    public async Task OnDataFinishedEventAsync(ResultBase dataCollected)
    {
        if (dataCollected.IsSuccess)
            AddSearched();

        await Task.CompletedTask;
    }

    public async Task OnGetArgsEventAsync(object[] dataCollected)
    {
        await Task.CompletedTask;
    }

    public async Task OnOccursExceptionEventAsync(Exception exception, object data, QuestResult result)
    {
        await Task.CompletedTask;
    }

    private async void RunScrapGUI_Load(object sender, EventArgs e)
    {
        await TryCreateAndRunModel();
    }

    private async Task<bool> TryCreateAndRunModel(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return false;

        lock (_lock)
        {
            if (_model is null)
            {
                try
                {
                    _model = _builder.CreateModelByQuestName(_questName)
                        ?? throw new ArgumentNullException(nameof(_model));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"An erro in creation quest '{_questName}'.\nDetails.\n{e.Message}",
                        "Erro in quest execution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        if (cancellationToken.IsCancellationRequested)
            return false;

        var result = await _model.Run();

        if (result.IsSuccess)
            return true;

        return false;
    }

    private async Task<bool> TryDisposeModel(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return false;

        lock (_lock)
        {
            if (_model is null ||
                _model.State == ModelStateEnum.Disposed)
                return false;
        }

        ResultBase<BlScraper.Results.Models.StopModel> result;
        try
        {
            result = await _model.StopAsync(cancellationToken);
        }
        catch (OperationCanceledException) { return false; }

        if (result.IsSuccess)
            return true;

        return false;
    }

    private void AddSearched()
    {
        ProgressBarSearchs.Value++;
    }
}