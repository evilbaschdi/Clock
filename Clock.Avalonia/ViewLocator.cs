using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Clock.Avalonia.ViewModels;

namespace Clock.Avalonia;

/// <inheritdoc />
public class ViewLocator : IDataTemplate
{
    /// <inheritdoc />
    public Control Build(object data)
    {
        if (data is null)
        {
            return null;
        }

        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = name };
    }

    /// <inheritdoc />
    public bool Match(object data) => data is ViewModelBase;
}