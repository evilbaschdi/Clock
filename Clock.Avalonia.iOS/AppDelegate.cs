using Avalonia;
using Avalonia.iOS;
using Avalonia.ReactiveUI;

namespace Clock.Avalonia.iOS;

// The UIApplicationDelegate for the application. This class is responsible for launching the 
// User Interface of the application, as well as listening (and optionally responding) to 
// application events from iOS.
/// <inheritdoc />
[Register("AppDelegate")]
public class AppDelegate : AvaloniaAppDelegate<App>
{
    /// <inheritdoc />
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
                   .WithInterFont()
                   .UseReactiveUI();
    }
}