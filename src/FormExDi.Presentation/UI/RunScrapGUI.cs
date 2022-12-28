using BlScraper.DependencyInjection.Builder;
using BlScraper.Model;
using BlScraper.Results;
using FormExDi.Application.Args;
using FormExDi.Application.Services.Interface;
using FormExDi.Presentation.ConsoleForm;
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
    private readonly IServiceProvider _serviceProvider;
    private IModelScraper? _model;
    private ILogScrap? _log;
    private SearchsQttStatus _searchsQttStatus = new(0,0);

    public RunScrapGUI(IServiceProvider serviceProvider, IScrapBuilder scrapBuilder, IInitArgs initArgs, IInfoService infoService)
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
        _serviceProvider = serviceProvider;

        ConsoleUtils.CreateConsole();
        ConsoleUtils.Hide();

        InitializeComponent();
        InitializeMyComponent();
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
        LogListBoxScrap.SetGetData(GetLog);

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

                    _log = (ILogScrap?)_serviceProvider.GetService(typeof(ILogScrapService<>).MakeGenericType(_model.TypeScrap));
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
        NotifyIconForm.Text = LabelTitle.Text;

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

    private IEnumerable<string> GetLog()
    {
        if (_log is null)
            yield break;

        if (!File.Exists(_log.Path))
            yield break;

        using (var stream = File.Open(_log.Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (var reader = new StreamReader(stream))
        {
            string? line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }

    private async void BtnPause_Click(object sender, EventArgs e)
    {
        var btn = sender as Button 
            ?? throw new ArgumentNullException("Button");
        
        try
        {
            btn.Enabled = false;

            if (_model is null)
                return;

            if (btn.Text.Equals("Pause"))
            {
                btn.Text = "Unpause";
                await _model.PauseAsync(true);
                return;
            }

            btn.Text = "Pause";
            await _model.PauseAsync(false);
        }
        finally
        {
            btn.Enabled = true;
        }
    }

    private void ToolStripOpen_Click(object sender, EventArgs e)
    {
        HideForm(false);
    }

    private void HideForm(bool hide = true)
    {
        if ((hide && !ShowInTaskbar) || (!hide && ShowInTaskbar))
            return;

        if (hide)
        {
            Opacity = 0;
            ShowInTaskbar = false;
            return;
        }

        Opacity = 100;
        ShowInTaskbar = true;
    }

    private bool IsHide()
    {
        return Opacity == 0;
    }

    private void RunScrapGUI_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (IsHide())
            return;

        if (_model is null)
            return;

        if (_model.State == ModelStateEnum.Disposed)
            return;

        e.Cancel = true;
        HideForm();
    }

    private void ToolStripExit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ContextMenuStripNotify_DoubleClick(object sender, EventArgs e)
    {
        HideForm(false);
    }
}