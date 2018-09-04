using System.Windows;
using Clock.ViewModel;
using SourceChord.FluentWPF;

namespace Clock
{
    /// <inheritdoc cref="AcrylicWindow" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AcrylicWindow
    {
        private readonly MainViewModel _mainViewModel;

        /// <summary>
        ///     Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new ClockViewModel();
            Loaded += MainWindowLoaded;
        }


        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = _mainViewModel;
        }
    }
}