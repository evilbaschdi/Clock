using Avalonia.Threading;
using ReactiveUI;

namespace Clock.Avalonia.ViewModels;

/// <inheritdoc />
public class MainViewModel : ViewModelBase
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public MainViewModel()
    {
        InitTimer();
    }

    /// <summary>
    /// </summary>
    public string CurrentTime
    {
        get;
        set => this.RaiseAndSetIfChanged(ref field, value);
    }

    /// <summary>
    ///     Initializes a new DispatcherTimer to update current time
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public void InitTimer()
    {
        var timer = new DispatcherTimer(DispatcherPriority.Background)
                    {
                        Interval = TimeSpan.FromMilliseconds(1),
                        IsEnabled = true
                    };
        timer.Tick += (_, _) => { UpdateTime(); };
    }

    private void UpdateTime()
    {
        var now = DateTime.Now;
        CurrentTime = now.ToString("HH:mm:ss");
    }
}