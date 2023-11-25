using Clock.Avalonia.ViewModels;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Clock.Avalonia.DependencyInjection;

/// <inheritdoc />
public class ConfigureWindowsAndViewModels : IConfigureWindowsAndViewModels
{
    /// <inheritdoc />
    public void RunFor([NotNull] IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<MainViewModel>();
    }
}