using Avalonia.Controls;

namespace Clock.Avalonia.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        Display.FontSize = DisplayFontSize;
    }

    public double DisplayFontSize { get; set; } = 200d;
}