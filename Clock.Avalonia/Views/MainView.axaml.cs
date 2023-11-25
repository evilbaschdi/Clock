using Avalonia.Controls;

namespace Clock.Avalonia.Views;

/// <inheritdoc />
public partial class MainView : UserControl
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public MainView()
    {
        InitializeComponent();
        Display.FontSize = DisplayFontSize;
    }

    /// <summary>
    /// </summary>
    public double DisplayFontSize { get; set; } = 200d;
}