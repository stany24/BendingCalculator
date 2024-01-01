using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;

namespace FlexionV2.Views.Editors.Piece;

public partial class ListLayersEditor : Window
{
    public ListLayersEditor(List<Logic.Layer> layersInPiece,List<Logic.Layer> layersAvailable)
    {
        InitializeComponent();
        foreach (Logic.Layer layer in layersInPiece) { LbxInPiece.Items.Add(layer); }
        foreach (Logic.Layer layer in layersAvailable) {LbxAvailable.Items.Add(layer); }
    }

    public void UpdateAvailableLayers(List<Logic.Layer> layers)
    {
        LbxAvailable.Items.Clear();
        foreach (Logic.Layer layer in layers) {LbxAvailable.Items.Add(layer); }
    }
}