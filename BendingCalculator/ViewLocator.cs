using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using BendingCalculator.ViewModels;

namespace BendingCalculator;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        string name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        Type? type = Type.GetType(name);

        if (type == null) return new TextBlock { Text = "Not Found: " + name };
        Control control = (Control)Activator.CreateInstance(type)!;
        control.DataContext = data;
        return control;

    }

    public bool Match(object? data)
    {
        return data is MainViewModel;
    }
}