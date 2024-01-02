using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;

namespace FlexionV2.Views.Editors.Piece;

public partial class PieceEditor : Editor
{
    public EventHandler<LayersChangedEventArgs> LayersChanged;
    private ListLayersEditor? _listLayersEditor;
    private List<Logic.Layer> _availableLayers;
    public PieceEditor(List<Logic.Piece> pieces,List<Logic.Layer> layers)
    {
        InitializeComponent();
        InitializeUi();
        LayersChanged += (_, e) => _availableLayers = e.Layers;
        NudLength.ValueChanged += (_,e) => NumericChanged<Logic.Piece>(e,"Length");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Piece>(TbxName, "Name");
        LbxItems.SelectionChanged += (_,_) => UpdateListLayer();
        BtnChangeLayers.Click += (_, _) => OpenPieceEditor();
        foreach (Logic.Piece piece in pieces) { LbxItems.Items.Add(piece); }
        _availableLayers = layers;
    }
    
    private void OpenPieceEditor()
    {
        if(_listLayersEditor != null){return;}
        _listLayersEditor = new ListLayersEditor(LbxLayers.Items.Cast<Logic.Layer>().ToList(),_availableLayers);
        _listLayersEditor.Closing += (_, _) => PieceEditorClosing();
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        IsEnabled = false;
        LayersChanged += (_, e) => _listLayersEditor.UpdateAvailableLayers(e.Layers);
    }
    
    private void PieceEditorClosing()
    {
        IsEnabled = true;
        (LbxItems.SelectedItems?[0] as Logic.Piece).Layers =
            _listLayersEditor?.LbxInPiece.Items.Cast<Logic.Layer>().ToList();
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
                List<Logic.Layer>? layers = (LbxItems.SelectedItems[0] as Logic.Piece)?.Layers;
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
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(new Logic.Piece(1,"nouveau"));
        BtnChangeLayers.IsEnabled = false;
    }
}