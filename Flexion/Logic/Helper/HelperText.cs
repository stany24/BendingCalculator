namespace Flexion.Logic.Helper;

public class HelperText:IHelperModule
{
    public string Text { get; set; }
    public HelperText(string text)
    {
        Text = text;
    }
}