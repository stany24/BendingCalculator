namespace BendingCalculator.Logic.Helper;

public class HelperImage:IHelperModule
{
    public string Source { get; }
    public HelperImage(string uri)
    {
        Source = "avares://BendingCalculator/Assets/Help/"+uri;
    }
}