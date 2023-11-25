using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using Clock.Avalonia;

[assembly: SupportedOSPlatform("browser")]

// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once CheckNamespace
internal class Program
{
    // ReSharper disable once UnusedParameter.Local
#pragma warning disable IDE0060
    private static async Task Main(string[] args)
#pragma warning restore IDE0060
        => await BuildAvaloniaApp()
                 .WithInterFont()
                 .UseReactiveUI()
                 .StartBrowserAppAsync("out");

    // ReSharper disable once MemberCanBePrivate.Global
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}