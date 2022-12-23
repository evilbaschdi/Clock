using System.Windows;
using EvilBaschdi.About.Core.Models;
using JetBrains.Annotations;

namespace Clock;

/// <summary>
///     Interaction logic for AboutWindow.xaml
/// </summary>
// ReSharper disable once RedundantExtendsListEntry
public partial class AboutWindow
{
    [NotNull] private readonly IAboutModel _aboutModel;

    /// <inheritdoc />
    public AboutWindow([NotNull] IAboutModel aboutModel)
    {
        _aboutModel = aboutModel ?? throw new ArgumentNullException(nameof(aboutModel));
        InitializeComponent();

        Loaded += AboutWindowLoaded;
    }

    private void AboutWindowLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = _aboutModel;
    }
}