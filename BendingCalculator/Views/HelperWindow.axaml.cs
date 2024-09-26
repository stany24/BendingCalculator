using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
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