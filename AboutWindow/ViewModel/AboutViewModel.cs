using System.Reflection;
using System.Windows;
using EvilBaschdi.Core;
using JetBrains.Annotations;

namespace EvilBaschdi.WpfControls.ViewModel;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
public class AboutViewModel : IAboutModel
{
    private readonly IAboutContent _aboutContent;

    /// <summary>
    /// </summary>
    /// <param name="aboutContent"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AboutViewModel(IAboutContent aboutContent)
    {
        _aboutContent = aboutContent ?? throw new ArgumentNullException(nameof(aboutContent));
    }

    /// <summary>
    /// </summary>
    // ReSharper disable UnusedMember.Global
    public string ApplicationTitle => _aboutContent.Value.ApplicationTitle;

    /// <summary>
    /// </summary>
    public string Company => $"Company / Authors: {_aboutContent.Value.Company}";

    /// <summary>
    /// </summary>
    public string Copyright => $"{_aboutContent.Value.Copyright}";

    /// <summary>
    /// </summary>
    public string Description => _aboutContent.Value.Description;

    /// <summary>
    /// </summary>
    public string LogoSourcePath => _aboutContent.Value.LogoSourcePath;

    /// <summary>
    /// </summary>
    public string Runtime => $"CLR: {_aboutContent.Value.Runtime}";

    /// <summary>
    /// </summary>
    public string Version => $"Version: {_aboutContent.Value.Version}";
    // ReSharper restore UnusedMember.Global
}

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public class AboutContent : IAboutContent
{
    private readonly Assembly _assembly;
    private readonly string _logoSourcePath;

    /// <summary>
    ///     Constructor of the class
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="logoSourcePath">AppDomain.CurrentDomain.BaseDirectory</param>
    /// <exception cref="ArgumentNullException"></exception>
    public AboutContent(Assembly assembly, string logoSourcePath)
    {
        _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        _logoSourcePath = logoSourcePath ?? throw new ArgumentNullException(nameof(logoSourcePath));
    }

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="currentAssembly"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AboutContent([NotNull] ICurrentAssembly currentAssembly)
    {
        // ReSharper disable once ConstantConditionalAccessQualifier
        _assembly = currentAssembly?.Value ?? throw new ArgumentNullException(nameof(currentAssembly));
        _logoSourcePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\about.png";
    }

    /// <inheritdoc />
    public AboutModel Value
    {
        get
        {
            var title = _assembly.GetCustomAttributes<AssemblyProductAttribute>().FirstOrDefault() != null
                ? _assembly.GetCustomAttributes<AssemblyProductAttribute>().FirstOrDefault()?.Product
                : _assembly.GetCustomAttributes<AssemblyTitleAttribute>().FirstOrDefault()?.Title;

            var config = new AboutModel
                         {
                             ApplicationTitle = title,
                             Copyright = _assembly.GetCustomAttributes<AssemblyCopyrightAttribute>().FirstOrDefault()?.Copyright,
                             Company = _assembly.GetCustomAttributes<AssemblyCompanyAttribute>().FirstOrDefault()?.Company,
                             Description = _assembly.GetCustomAttributes<AssemblyDescriptionAttribute>().FirstOrDefault()
                                                    ?.Description,
                             Version = _assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                                ?.InformationalVersion.Split('+').FirstOrDefault(),
                             Runtime = Environment.Version.ToString(),
                             LogoSourcePath = !string.IsNullOrWhiteSpace(_logoSourcePath) ? _logoSourcePath : string.Empty,
                         };

            return config;
        }
    }
}

/// <inheritdoc />
public class CurrentAssembly : ICurrentAssembly
{
    /// <inheritdoc />
    public Assembly Value
    {
        get
        {
            if (Application.Current?.MainWindow == null)
            {
                return null;
            }

            var mainWindow = Application.Current?.MainWindow;
            return mainWindow?.GetType().Assembly;
        }
    }
}

/// <inheritdoc />
public interface ICurrentAssembly : IValue<Assembly>
{
}

/// <inheritdoc />
public interface IAboutContent : IValue<AboutModel>
{
}

/// <summary>
/// </summary>
public interface IAboutModel
{
    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string ApplicationTitle { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Company { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Copyright { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Description { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string LogoSourcePath { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Runtime { get; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once UnusedMemberInSuper.Global
    public string Version { get; }
}

/// <summary>
/// </summary>
public class AboutModel : IAboutModel
{
    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string ApplicationTitle { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Company { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Copyright { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Description { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string LogoSourcePath { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Runtime { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Version { get; set; }
}