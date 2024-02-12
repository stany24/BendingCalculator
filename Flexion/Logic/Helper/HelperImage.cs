namespace Flexion.Logic.Helper;

public class HelperImage:IHelperModule
{
    public string Source { get; }
    public HelperImage(string uri)
    {
        Source = "avares://Flexion/Assets/Help/"+uri;
    }
}