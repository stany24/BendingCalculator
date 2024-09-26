using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Markdown.Avalonia.Full;

namespace BendingCalculator.Views;

public partial class HelperWindow : Window
{
    public HelperWindow(string ressource)
    {
        MarkdownScrollViewer md = new()
        {
            [!Markdown.Avalonia.MarkdownScrollViewer.MarkdownProperty] = new DynamicResourceExtension(ressource)
        };
        Content = md;
    }
}