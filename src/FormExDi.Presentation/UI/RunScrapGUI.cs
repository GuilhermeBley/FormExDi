using BlScraper.DependencyInjection.Builder;
using BlScraper.Model;
using BlScraper.Results;
using FormExDi.Application.Args;
using FormExDi.Presentation.Model;
using FormExDi.Presentation.Services.Interfaces;

namespace FormExDi.Presentation.Ui;

internal partial class RunScrapGUI : Form
{
    private readonly CancellationTokenSource _cts = new();
    private readonly object _lock = new();
    private readonly IScrapBuilder _builder;
    private readonly string _questName;
    private readonly IInfoService _infoService;
    private IModelScraper? _model;
    private SearchsQttStatus _searchsQttStatus = new(0,0);

    public RunScrapGUI(IScrapBuilder scrapBuilder, IInitArgs initArgs, IInfoService infoService)
    {
        if (scrapBuilder is null)
            throw new ArgumentNullException(nameof(scrapBuilder));

        if (initArgs is null)
            throw new ArgumentNullException(nameof(initArgs));

        if (string.IsNullOrEmpty(initArgs.QuestName))
            throw new ArgumentNullException(nameof(initArgs.QuestName));

        _builder = scrapBuilder;
        _questName = initArgs.QuestName;
        _infoService = infoService;

        InitializeComponent();
    }

    protected async override void OnClosed(EventArgs e)
    {
        _cts.Cancel();
        _cts.Dispose();

        if (_model is not null)
            await TryDisposeModel();
    }

    private async void RunScrapGUI_Load(object sender, EventArgs e)
    {
        LabelTitle.Text = $"Search {_questName}";

        await WaitHandleCreate(_cts.Token);
        Update();
        await TryCreateAndRunModel(_cts.Token);
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

        LabelTitle.Text = $"Search {_questName}.";

        var result = await _model.Run();

        SetSearched(0, result.Result.Searches.Count());

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

    private void SetSearched(int current)
    {
        _searchsQttStatus.SetCurrent(current);
        ProgressBarSearchs.Value = _searchsQttStatus.CurrentQtd;
        LabelQtt.Text = _searchsQttStatus.ToString();
    }

    private void SetSearched(int init, int max)
    {
        _searchsQttStatus = new(init, max);

        ProgressBarSearchs.Minimum = 0;
        ProgressBarSearchs.Maximum = _searchsQttStatus.TotalQtd;
        ProgressBarSearchs.Value =0;

        LabelQtt.Text = _searchsQttStatus.ToString();
    }

    private async Task WaitHandleCreate(CancellationToken cancellationToken = default)
    {
        while (!IsHandleCreated)
            await Task.Delay(200, cancellationToken);
    }

    private void TimerInfo_Tick(object sender, EventArgs e)
    {
        var modelScrapInfo = _infoService.GetDataByModel(_model).GetAwaiter().GetResult();
        SetSearched(modelScrapInfo.CurrentSearch);

        if (modelScrapInfo.IsFinished)
        {
            TimerInfo.Enabled = false;
            Dispose();
        }
    }
}