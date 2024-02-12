using System.Collections.Generic;

namespace Flexion.Logic.Helper;

public static class HelperInfo
{
    public static List<IHelperModule> MainWindowModules { get; } = new()
    {
        new HelperText("test"),
        new HelperImage("avares://Flexion/Assets/Help/MainWindow/test.png")
    };
}