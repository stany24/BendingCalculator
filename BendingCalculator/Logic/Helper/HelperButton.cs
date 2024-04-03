using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.MarkupExtensions;

namespace BendingCalculator.Logic.Helper;

public class HelperButton : IHelperControl
{
    private readonly string _displayTextBinding;
    private readonly string _link;

    public HelperButton(string displayTextBinding, string link)
    {
        _displayTextBinding = displayTextBinding;
        _link = link;
    }

    public Control GetControl()
    {
        return new Button
        {
            [!ContentControl.ContentProperty] = new DynamicResourceExtension(_displayTextBinding),
            Command = new OpenLinkCommand(),
            CommandParameter = _link,
            HorizontalAlignment = HorizontalAlignment.Center
        };
    }
}