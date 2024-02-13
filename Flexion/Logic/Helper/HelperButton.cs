namespace Flexion.Logic.Helper;

public class HelperButton:IHelperModule
{
    public string DisplayText { get; }
    public string Link { get; }

    public HelperButton(string displayText, string link)
    {
        DisplayText = displayText;
        Link = link;
    }
}