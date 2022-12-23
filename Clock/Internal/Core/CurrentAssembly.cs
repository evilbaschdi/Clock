using System.Reflection;
using System.Windows;
using EvilBaschdi.Core;

namespace Clock.Internal.Core;

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