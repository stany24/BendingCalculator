using System.Collections.Generic;

namespace Flexion.Logic.Helper;

public static class HelperInfo
{
    public static List<IHelperModule> MainWindowModules { get; } = new()
    {
        new HelperText("test"),
        new HelperButton("test2","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code"),
        new HelperImage("MainWindow/test.png")
    };
}