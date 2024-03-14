namespace BendingCalculator.Logic.Helper;

public class HelperButton:IHelperModule
{
    public string DisplayTextBinding { get; }
    public string Link { get; }

    public HelperButton(string displayTextBinding, string link)
    {
        DisplayTextBinding = displayTextBinding;
        Link = link;
    }
}