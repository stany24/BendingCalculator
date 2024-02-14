namespace Flexion.Logic.Helper;

public class HelperText:IHelperModule
{
    public string NameBinding { get; }
    public HelperText(string nameBinding)
    {
        NameBinding = nameBinding;
    }
}