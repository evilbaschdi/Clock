using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Clock.WpfUi.ViewModel;
using EvilBaschdi.Core.Wpf;

namespace Clock.WpfUi;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
// ReSharper disable once RedundantExtendsListEntry
public partial class MainWindow
{
    private readonly ClockViewModel _mainViewModel;

    /// <summary>
    ///     Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        _mainViewModel = new();
        Loaded += MainWindowLoaded;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private void WindowContentRendered(object sender, EventArgs e)
    {
        var applyMicaBrush = new ApplyMicaBrush();
        applyMicaBrush.RunFor((HwndSource)sender, this);
    }

    private void MainWindowLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = _mainViewModel;

        // Get PresentationSource
        var presentationSource = PresentationSource.FromVisual((Visual)sender);

        // Subscribe to PresentationSource's ContentRendered event
        if (presentationSource != null)
        {
            presentationSource.ContentRendered += WindowContentRendered;
        }
    }
}