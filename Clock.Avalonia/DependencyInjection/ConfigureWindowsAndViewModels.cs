using Clock.Avalonia.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Clock.Avalonia.DependencyInjection;

/// <summary />
public static class ConfigureWindowsAndViewModels
{
    /// <summary />
    public static void AddWindowsAndViewModels(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<MainViewModel>();
    }
}