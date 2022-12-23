using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using Clock.Internal.Core;
using EvilBaschdi.About.Core;
using EvilBaschdi.About.Core.Models;
using EvilBaschdi.Core;

namespace Clock.ViewModel;

/// <inheritdoc />
/// <summary>
///     MainViewModel of Clock
/// </summary>
public sealed class ClockViewModel : INotifyPropertyChanged
{
    private string _currentTime;
    private int _hour;
    private int _minute;
    private int _second;

    /// <summary>
    ///     Constructor
    /// </summary>
    public ClockViewModel()
    {
        InitTimer();
        AboutWindowClick = new RelayCommand(_ => ShowAboutWindow());
    }

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
#pragma warning disable 1591
    public ICommand AboutWindowClick { get; set; }
#pragma warning restore 1591

    /// <summary>
    ///     Current time as a string
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public string CurrentTime
    {
        // ReSharper disable once UnusedMember.Global
        get => _currentTime;
        private set
        {
            if (_currentTime == value)
            {
                return;
            }

            _currentTime = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Hour of current time
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public int Hour
    {
        // ReSharper disable once UnusedMember.Global
        get => _hour;
        set
        {
            if (_hour == value)
            {
                return;
            }

            _hour = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Minute of current time
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public int Minute
    {
        // ReSharper disable once UnusedMember.Global
        get => _minute;
        set
        {
            if (_minute == value)
            {
                return;
            }

            _minute = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Second of current time
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public int Second
    {
        // ReSharper disable once UnusedMember.Global
        get => _second;
        set
        {
            if (_second == value)
            {
                return;
            }

            _second = value;
            OnPropertyChanged();
        }
    }

    /// <inheritdoc />
    public event PropertyChangedEventHandler PropertyChanged;

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
        CurrentTime = now.ToLongTimeString();
        Hour = now.Hour;
        Minute = now.Minute;
        Second = now.Second;
    }

    private static void ShowAboutWindow()
    {
        ICurrentAssembly currentAssembly = new CurrentAssembly();
        IAboutContent aboutContent = new AboutContent(currentAssembly);
        IAboutModel aboutModel = new AboutViewModel(aboutContent);
        var aboutWindow = new AboutWindow(aboutModel);

        aboutWindow.ShowDialog();
    }

    /// <summary>
    ///     INotifyPropertyChanged - method to synchronize UI and Property.
    /// </summary>
    /// <param name="propertyName"></param>
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = PropertyChanged;
        handler?.Invoke(this, new(propertyName));
    }
}