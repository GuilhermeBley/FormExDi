namespace FormExDi.Presentation.Delegates;

/// <summary>
/// Delegate called when model pause
/// </summary>
/// <param name="sender">current form</param>
/// <param name="onPauseEventArgs">Event Args</param>
public delegate void OnPauseEventHandler(object sender, OnPauseEventArgs onPauseEventArgs);

/// <summary>
/// Event args on pause
/// </summary>
public class OnPauseEventArgs : EventArgs
{
    private readonly bool _isPaused;

    /// <summary>
    /// True : paused, false : unpaused
    /// </summary>
    public bool IsPaused => _isPaused;

    /// <summary>
    /// Instance with bool argument
    /// </summary>
    /// <param name="isPaused">true : paused, false: unpaused</param>
    public OnPauseEventArgs(bool isPaused)
    {
        _isPaused = isPaused;
    }
}

