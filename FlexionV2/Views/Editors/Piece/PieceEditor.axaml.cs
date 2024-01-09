using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.Database.Actions;

namespace FlexionV2.Views.Editors.Piece;

public partial class PieceEditor : Editor
{
    private ListLayersEditor? _listLayersEditor;
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
        DataBaseEvents.LayerOfPieceChanged += UpdatePieces;
        foreach (Logic.Piece piece in DataBaseLoader.LoadPieces(_connection))
        {
            LbxItems.Items.Add(piece);
        }
        Closing += (_, _) => _listLayersEditor?.Close();
    }
    
    ~PieceEditor()
    {
        DataBaseEvents.LayerOfPieceChanged -= UpdatePieces;
    }

    private void NumericChanged<TItem>(NumericUpDownValueChangedEventArgs e, string propertyName)
    {
        if (LbxItems.SelectedItems == null) return;
        if (e.NewValue == null) return;
        foreach (TItem item in LbxItems.SelectedItems)
            item.GetType().GetProperty(propertyName)?.SetValue(item, (double)e.NewValue/1000);
        UpdateListBox<TItem>();
    }
    
    protected override void UpdateListBox<TItem>()
    {
        List<Logic.Piece> selected = new();
        List<Logic.Piece> items = LbxItems.Items.Cast<Logic.Piece>().ToList();
        if (LbxItems.SelectedItems != null) { selected = LbxItems.SelectedItems.Cast<Logic.Piece>().ToList(); }
        DataBaseUpdater.UpdatePiece(_connection,items);
        LbxItems.Items.Clear();
        foreach (Logic.Piece item in items) LbxItems.Items.Add(item);
        if (LbxItems.SelectedItems == null) return;
        foreach (Logic.Piece item in selected) LbxItems.SelectedItems.Add(item);
    }
    
    protected override void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        while (LbxItems.SelectedItems.Count > 0)
        {
            if(LbxItems.SelectedItems[0] is not Logic.Piece piece){continue;}
            DataBaseRemover.RemovePiece(_connection,piece.PieceId);
            LbxItems.Items.Remove(LbxItems.SelectedItems[0]);
        }

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    private void UpdatePieces(object? sender, EventArgs eventArgs)
    {
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => { LbxItems.Items.Clear(); 
        foreach (Logic.Piece piece in DataBaseLoader.LoadPieces(_connection))
        {
            LbxItems.Items.Add(piece);
        }});
    }
    
    private void OpenLayerEditor()
    {
        if(_listLayersEditor != null){return;}
        if(LbxItems.SelectedItems?[0] is not Logic.Piece piece){return;}
        _listLayersEditor = new ListLayersEditor(_connection,piece.PieceId);
        _listLayersEditor.Closing += (_, _) => IsEnabled = true;
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        IsEnabled = false;
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
                foreach (Logic.Layer layer in DataBaseLoader.LoadLayersOfPiece(_connection,(LbxItems.SelectedItems[0] as Logic.Piece)!.PieceId))
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
        BtnAdd.Click += (_, _) => CreateNewPiece();
        BtnChangeLayers.IsEnabled = false;
    }

    private void CreateNewPiece()
    {
        Logic.Piece piece = new(Convert.ToDouble(NudLength.Value/1000 ?? 1), TbxName.Text ?? "nouveau", 69e9);
        LbxItems.Items.Add(DataBaseCreator.NewPiece(_connection, piece));
    }
}