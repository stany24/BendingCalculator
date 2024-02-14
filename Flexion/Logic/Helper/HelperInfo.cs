using System.Collections.Generic;

namespace Flexion.Logic.Helper;

public static class HelperInfo
{
    public static List<IHelperModule> MainWindowModules { get; } = new()
    {
        new HelperText("MainWindowHelper1Binding"),
        new HelperButton("MainWindowHelper2Binding","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code"),
        new HelperImage("MainWindow/test.png")
    };
    
    public static List<IHelperModule> ForceWindowModules { get; } = new()
    {
        new HelperText("MainWindowHelper1Binding"),
        new HelperButton("MainWindowHelper2Binding","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code"),
        new HelperImage("MainWindow/test.png")
    };
    
    public static List<IHelperModule> MaterialWindowModules { get; } = new()
    {
        new HelperText("MainWindowHelper1Binding"),
        new HelperButton("MainWindowHelper2Binding","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code"),
        new HelperImage("MainWindow/test.png")
    };
    
    public static List<IHelperModule> LayerWindowModules { get; } = new()
    {
        new HelperText("MainWindowHelper1Binding"),
        new HelperButton("MainWindowHelper2Binding","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code"),
        new HelperImage("MainWindow/test.png")
    };
    
    public static List<IHelperModule> PieceWindowModules { get; } = new()
    {
        new HelperText("MainWindowHelper1Binding"),
        new HelperButton("MainWindowHelper2Binding","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code"),
        new HelperImage("MainWindow/test.png")
    };
}