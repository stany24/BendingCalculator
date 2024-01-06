using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;

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
        LoadPiecesFromDatabase();
    }

    public void LoadLayersFromDatabase()
    {
        using SQLiteCommand cmd = new(
            @"SELECT Layer.*, Material.*
          FROM Layer
          LEFT JOIN Material ON Layer.MaterialId = Material.MaterialId
          WHERE Layer.IsRemoved = 0;", _connection);
        
        using SQLiteDataReader reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Logic.Layer layer = new()
            {
                LayerId = Convert.ToInt32(reader["LayerId"]),
                WidthAtCenter = Convert.ToDouble(reader["WidthAtCenter"]),
                WidthOnSides = Convert.ToDouble(reader["WidthOnSides"]),
                HeightAtCenter = Convert.ToDouble(reader["HeightAtCenter"]),
                HeightOnSides = Convert.ToDouble(reader["HeightOnSides"])
            };
            
            if (reader["MaterialId"] != DBNull.Value)
            {
                layer.Material = new Logic.Material
                {
                    MaterialId = Convert.ToInt32(reader["MaterialId"]),
                    E=Convert.ToInt64(reader["E"]),
                    Name = Convert.ToString(reader["Name"]) ?? string.Empty
                };
            }

            LbxLayers.Items.Add(layer);
        }
    }

    private void LoadPiecesFromDatabase()
    {
        LbxLayers.Items.Clear();
        using SQLiteCommand cmd = new(
            @"SELECT *
            FROM Piece p
            LEFT JOIN PieceToLayer pl ON p.PieceId = pl.PieceId
            LEFT JOIN Layer l ON pl.LayerId = l.LayerId
            LEFT JOIN Material m on l.MaterialId = m.MaterialId
            WHERE p.IsRemoved = 0
            ORDER BY p.PieceId, pl.LayerOrder;", _connection);
        
        using SQLiteDataReader reader = cmd.ExecuteReader();
        List<Logic.Piece> pieces = new List<Logic.Piece>();
        Logic.Piece currentPiece = null;
        
        while (reader.Read())
        {
            int pieceId = Convert.ToInt32(reader["PieceId"]);
            
            if (currentPiece == null || currentPiece.PieceId != pieceId)
            {
                currentPiece = new Logic.Piece
                {
                    PieceId = pieceId,
                    Name = Convert.ToString(reader["Name"]),
                    Length = Convert.ToDouble(reader["Length"]),
                    Eref = Convert.ToInt64(reader["Eref"]),
                    Layers = new List<Logic.Layer>()
                };
                pieces.Add(currentPiece);
            }
            
            if (reader["LayerId"] == DBNull.Value) continue;
            Logic.Layer layer = new()
            {
                LayerId = Convert.ToInt32(reader["LayerId"]),
                WidthAtCenter = Convert.ToDouble(reader["WidthAtCenter"]),
                WidthOnSides = Convert.ToDouble(reader["WidthOnSides"]),
                HeightAtCenter = Convert.ToDouble(reader["HeightAtCenter"]),
                HeightOnSides = Convert.ToDouble(reader["HeightOnSides"])
            };
            
            if (reader["MaterialId"] != DBNull.Value)
            {
                layer.Material = new Logic.Material
                {
                    MaterialId = Convert.ToInt32(reader["MaterialId"]),
                    E=Convert.ToInt64(reader["E"]),
                    Name = Convert.ToString(reader["Name"]) ?? string.Empty
                };
            }

            currentPiece.Layers.Add(layer);
        }
                
        foreach (Logic.Piece piece in pieces) { LbxItems.Items.Add(piece); }
    }
    
    private void OpenLayerEditor()
    {
        if(_listLayersEditor != null){return;}
        _listLayersEditor = new ListLayersEditor(LbxLayers.Items.Cast<Logic.Layer>().ToList(),_availableLayers);
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
        BtnAdd.Click += (_, _) => LbxItems.Items.Add(new Logic.Piece(1,"nouveau"));
        BtnChangeLayers.IsEnabled = false;
    }
}