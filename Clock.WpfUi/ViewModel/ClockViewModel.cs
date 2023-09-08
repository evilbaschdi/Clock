using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using Clock.WpfUi.Internal.Core;
using EvilBaschdi.About.Core;
using EvilBaschdi.About.Core.Models;
using EvilBaschdi.About.Wpf;
using EvilBaschdi.Core;
using EvilBaschdi.Core.Wpf;

namespace Clock.WpfUi.ViewModel;

/// <inheritdoc />
/// <summary>
///     MainViewModel of Clock
/// </summary>
public sealed class ClockViewModel : INotifyPropertyChanged
{
    private string _currentTime;

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
    }

    private static void ShowAboutWindow()
    {
        ICurrentAssembly currentAssembly = new CurrentAssembly();
        IAboutContent aboutContent = new AboutContent(currentAssembly);
        IAboutViewModel aboutViewModel = new AboutViewModel(aboutContent);
        IApplyMicaBrush applyMicaBrush = new ApplyMicaBrush();
        IApplicationLayout applicationLayout = new ApplicationLayout();
        var aboutWindow = new AboutWindow(aboutViewModel, applicationLayout, applyMicaBrush);

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