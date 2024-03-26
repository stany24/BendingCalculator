using System.Collections.Generic;

namespace BendingCalculator.Logic.Helper;

public static class HelperInfo
{
    public static List<IHelperModule> MainWindowModules { get; } = new()
    {
        new HelperText("MainWindowHelper1"),
        new HelperText("MainWindowHelper2"),
        new HelperText("MainWindowHelper3"),
        new HelperText("MainWindowHelper4"),
        new HelperText("MainWindowHelper5"),
        new HelperText("MainWindowHelper6"),
        new HelperText("MainWindowHelper7"),
        new HelperText("MainWindowHelper8"),
        new HelperText("MainWindowHelper9"),
        new HelperButton("MainWindowHelper10","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code")
    };
    
    public static List<IHelperModule> ForceWindowModules { get; } = new()
    {
        new HelperText("MainWindowHelper1"),
        new HelperButton("MainWindowHelper2","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code"),
        new HelperImage("MainWindow/test.png")
    };
    
    public static List<IHelperModule> MaterialWindowModules { get; } = new()
    {
        new HelperText("MaterialEditorHelper1"),
        new HelperText("MaterialEditorHelper2"),
        new HelperText("MaterialEditorHelper3"),
        new HelperText("MaterialEditorHelper4"),
        new HelperButton("MaterialEditorHelper5","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code")
    };
    
    public static List<IHelperModule> LayerWindowModules { get; } = new()
    {
        new HelperText("LayerEditorHelper1"),
        new HelperText("LayerEditorHelper2"),
        new HelperText("LayerEditorHelper3"),
        new HelperText("LayerEditorHelper4"),
        new HelperText("LayerEditorHelper5"),
        new HelperText("LayerEditorHelper6"),
        new HelperText("LayerEditorHelper7"),
        new HelperButton("LayerEditorHelper8","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code")
    };
    
    public static List<IHelperModule> PieceWindowModules { get; } = new()
    {
        new HelperText("PieceEditorHelper1"),
        new HelperText("PieceEditorHelper2"),
        new HelperText("PieceEditorHelper3"),
        new HelperText("PieceEditorHelper4"),
        new HelperText("PieceEditorHelper5"),
        new HelperButton("PieceEditorHelper6","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code")
    };
    public static List<IHelperModule> PieceLayerWindowModules { get; } = new()
    {
        new HelperText("PieceEditorHelper7"),
        new HelperText("PieceEditorHelper8"),
        new HelperText("PieceEditorHelper9"),
        new HelperText("PieceEditorHelper10"),
        new HelperText("PieceEditorHelper11"),
        new HelperText("PieceEditorHelper12"),
        new HelperText("PieceEditorHelper13"),
        new HelperText("PieceEditorHelper14"),
        new HelperButton("PieceEditorHelper15","https://docs.avaloniaui.net/docs/guides/data-binding/binding-from-code")
    };
}