using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;

namespace Clock.Avalonia.Android;

[Activity(
    Label = "Clock.Avalonia.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    Exported = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
[IntentFilter(
    actions: new[] { "android.intent.action.MAIN" },
    Categories = new[]
                 {
                     "android.intent.category.LAUNCHER",
                     "android.intent.category.LEANBACK_LAUNCHER"
                 })]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
                   .WithInterFont()
                   .UseReactiveUI();
    }
}