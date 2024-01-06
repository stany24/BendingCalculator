using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.Logic.Database;

namespace FlexionV2.Views.Editors.Piece;

public partial class PieceEditor : Editor
{
    private ListLayersEditor? _listLayersEditor;
    private readonly List<Logic.Layer> _availableLayers;
    private readonly SQLiteConnection _connection;
    public PieceEditor(SQLiteConnection connection)
    {
        InitializeComponent();
        InitializeUi();
        _connection = connection;
        NudLength.ValueChanged += (_,e) => NumericChanged<Logic.Piece>(e,"Length");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Piece>(TbxName, "Name");
        LbxItems.SelectionChanged += (_,_) => UpdateListLayer();
        BtnChangeLayers.Click += (_, _) => OpenLayerEditor();
        foreach (Logic.Piece piece in DataBaseLoader.LoadPieces(_connection))
        {
            LbxItems.Items.Add(piece);
        }
    }

    public void UpdateLayers()
    {
        _availableLayers.Clear();
        foreach (Logic.Layer layer in DataBaseLoader.LoadLayers(_connection))
        {
            _availableLayers.Add(layer);
        }
        _listLayersEditor?.UpdateLayers();
    }

    
    
    private void OpenLayerEditor()
    {
        if(_listLayersEditor != null){return;}
        if(LbxItems.SelectedItems?[0] == null){return;}
        _listLayersEditor = new ListLayersEditor(_connection,(LbxItems.SelectedItems[0] as Logic.Piece).PieceId);
        _listLayersEditor.Closing += (_, _) => PieceEditorClosing();
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        IsEnabled = false;
    }
    
    private void PieceEditorClosing()
    {
        IsEnabled = true;
        if(LbxItems.SelectedItems?[0] is not Logic.Piece piece){return;}
        piece.Layers =_listLayersEditor?.LbxInPiece.Items.Cast<Logic.Layer>().ToList() ?? new List<Logic.Layer>();
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
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(DataBaseCreator.NewPiece(_connection));
        BtnChangeLayers.IsEnabled = false;
    }
}