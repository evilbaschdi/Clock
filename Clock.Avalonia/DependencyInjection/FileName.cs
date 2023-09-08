﻿using System;
using Clock.Avalonia.ViewModels;
using EvilBaschdi.Core.Avalonia;
using EvilBaschdi.DependencyInjection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Clock.Avalonia.DependencyInjection;

/// <inheritdoc />
public interface IConfigureAvaloniaServices : IConfigureServiceCollection
{
}

/// <inheritdoc />
public class ConfigureAvaloniaServices : IConfigureAvaloniaServices
{
    /// <inheritdoc />
    public void RunFor([NotNull] IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.TryAddSingleton<IHandleOsDependentTitleBar, HandleOsDependentTitleBar>();
        services.TryAddSingleton<IApplicationLayout, ApplicationLayout>();
    }
}

/// <inheritdoc />
public interface IConfigureWindowsAndViewModels : IConfigureServiceCollection
{
}

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