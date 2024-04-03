using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Media;

namespace BendingCalculator.Logic.Helper;

public class HelperText:IHelperControl
{
    private readonly string _nameBinding;
    public HelperText(string nameBinding)
    {
        _nameBinding = nameBinding;
    }

    public Control GetControl()
    {
        return new TextBlock
        {
            [!TextBlock.TextProperty] = new DynamicResourceExtension(_nameBinding),
            TextWrapping = TextWrapping.Wrap
        };
    }
}