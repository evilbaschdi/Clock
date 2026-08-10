using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Clock.Avalonia.DependencyInjection;
using Clock.Avalonia.ViewModels;
using Clock.Avalonia.Views;
using EvilBaschdi.Core.Avalonia.Themes;
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

        serviceCollection.AddWindowsAndViewModels();

        ServiceProvider = serviceCollection.BuildServiceProvider();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:

                ThemeEngine.Initialize(this);

                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                var mainWindow = new MainWindow
                                 {
                                     DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
                                 };

                ThemeEngine.ApplyThemeToWindow(mainWindow, true);

                desktop.MainWindow = mainWindow;

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