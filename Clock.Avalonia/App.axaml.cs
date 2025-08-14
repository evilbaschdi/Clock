using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Clock.Avalonia.DependencyInjection;
using Clock.Avalonia.ViewModels;
using Clock.Avalonia.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Clock.Avalonia;

/// <inheritdoc />
public class App : Application
{
    /// <inheritdoc />
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    ///     ServiceProvider for DependencyInjection
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    public static IServiceProvider ServiceProvider { get; set; }

    /// <inheritdoc />
    public override void OnFrameworkInitializationCompleted()
    {
        IServiceCollection serviceCollection = new ServiceCollection();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
        {
            serviceCollection.AddAvaloniaServices();
        }

        serviceCollection.AddWindowsAndViewModels();

        ServiceProvider = serviceCollection.BuildServiceProvider();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:

                desktop.MainWindow = new MainWindow
                                     {
                                         DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
                                     };
                break;
            case ISingleViewApplicationLifetime singleViewPlatform:

                singleViewPlatform.MainView = new MainView
                                              {
                                                  DataContext = ServiceProvider.GetRequiredService<MainViewModel>(),
                                                  //DisplayFontSize = 50d
                                              };
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}