using Avalonia.Controls;
using EvilBaschdi.Core.Avalonia;
using Microsoft.Extensions.DependencyInjection;

namespace Clock.Avalonia.Views;

public partial class MainWindow : Window
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        ApplyLayout();
    }

    private void ApplyLayout()
    {
        var handleOsDependentTitleBar = App.ServiceProvider?.GetRequiredService<IHandleOsDependentTitleBar>();
        handleOsDependentTitleBar?.RunFor(this);

        var applicationLayout = App.ServiceProvider?.GetRequiredService<IApplicationLayout>();
        applicationLayout?.RunFor((this, true, true));
    }
}