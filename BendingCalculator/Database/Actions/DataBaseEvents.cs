using System;

namespace BendingCalculator.Database.Actions;

public static class DataBaseEvents
{
    public static event EventHandler<EventArgs>? MaterialsChanged;
    public static event EventHandler<EventArgs>? LayersChanged;
    public static event EventHandler<EventArgs>? PiecesChanged;

    public static void RaiseMaterialsChangedEvent()
    {
        MaterialsChanged?.Invoke(null,EventArgs.Empty);
        LayersChanged?.Invoke(null,EventArgs.Empty);
        PiecesChanged?.Invoke(null,EventArgs.Empty);
    }
    
    public static void RaiseLayersChangedEvent()
    {
        LayersChanged?.Invoke(null,EventArgs.Empty);
        PiecesChanged?.Invoke(null,EventArgs.Empty);
    }
    
    public static void RaisePiecesChangedEvent()
    {
        PiecesChanged?.Invoke(null,EventArgs.Empty);
    }
}