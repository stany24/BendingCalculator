using System.Collections.Generic;
using Avalonia.Controls;
using FlexionV2.Logic;

namespace FlexionV2.Views.Editors;

public partial class PieceEditor : Editor
{
    public PieceEditor(List<Piece> pieces,List<Logic.Layer> layers)
    {
        InitializeComponent();
        InitializeUi();
        NudLength.ValueChanged += (_,e) => NumericChanged<Piece>(e,"Length");
        TbxName.TextChanged += (_, _) => TextChanged<Piece>(TbxName, "Name");
        LbxItems.SelectionChanged += (_,_) => UpdateListLayer();
        foreach (Piece piece in pieces) { LbxItems.Items.Add(piece); }
        foreach (Logic.Layer layer in layers) { LbxLayers.Items.Add(layer); }
    }

    private void UpdateListLayer()
    {
        LbxLayers.Items.Clear();
        if (LbxItems.SelectedItems == null)
        {
            BtnChangeLayers.IsEnabled = false;
            return;
        }
        switch (LbxItems.SelectedItems.Count)
        {
            case 0:
                BtnChangeLayers.IsEnabled = false;
                return;
            case > 1:
                LbxLayers.Items.Add("Plus que 1 pièce selectionnée");
                BtnChangeLayers.IsEnabled = false;
                break;
            default:
            {
                List<Logic.Layer>? layers = (LbxItems.SelectedItems[0] as Piece)?.Layers;
                if (layers == null) return;
                foreach (Logic.Layer layer in layers)
                {
                    LbxLayers.Items.Add(layer);
                }

                BtnChangeLayers.IsEnabled = true;
                break;
            }
        }
    }
    private void InitializeUi()
    {
        Grid.SetColumn(LbxItems,0);
        Grid.SetRow(LbxItems,0);
        Grid.SetRowSpan(LbxItems,8);
        LbxItems.MinWidth = 200;
        Grid.Children.Add(LbxItems);
        Grid.SetColumn(BtnAdd,2);
        Grid.SetRow(BtnAdd,6);
        Grid.Children.Add(BtnAdd);
        Grid.SetColumn(BtnRemove,4);
        Grid.SetRow(BtnRemove,6);
        Grid.Children.Add(BtnRemove);
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(new Piece(1,"nouveau"));
    }
}