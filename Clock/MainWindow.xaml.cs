using System.Windows;
using Clock.ViewModel;

namespace Clock;

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

    private void MainWindowLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = _mainViewModel;
    }
}