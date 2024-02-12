namespace Flexion.Logic.Helper;

public class HelperText:IHelperModule
{
    public string Text { get; }
    public HelperText(string text)
    {
        Text = text;
    }
}