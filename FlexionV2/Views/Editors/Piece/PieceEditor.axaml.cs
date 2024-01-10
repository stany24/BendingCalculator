using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Piece;

public partial class PieceEditor : Editor
{
    private ListLayersEditor? _listLayersEditor;
    private readonly MainViewModel _model;
    public PieceEditor(MainViewModel model)
    {
        _model = model;
        InitializeComponent();
        InitializeUi();
        NudLength.ValueChanged += (_,e) => NumericChanged<Logic.Piece>(e,"Length");
        TbxName.TextChanged += (_, _) => TextChanged<Logic.Piece>(TbxName, "Name");
        LbxItems.SelectionChanged += (_,_) => UpdateListLayer();
        BtnChangeLayers.Click += (_, _) => OpenLayerEditor();
        Binding binding1 = new()
        { 
            Source = _model, 
            Path = nameof(_model.Pieces)
        }; 
        LbxItems.Bind(ItemsControl.ItemsSourceProperty,binding1 );
        Binding binding2 = new()
        { 
            Source = _model, 
            Path = nameof(_model.LayersOfSelectedPiece)
        }; 
        LbxLayers.Bind(ItemsControl.ItemsSourceProperty,binding2 );
        Closing += (_, _) => _listLayersEditor?.Close();
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
        _model.UpdatePieces(items);
        LbxItems.Items.Clear();
        foreach (Logic.Piece item in items) LbxItems.Items.Add(item);
        if (LbxItems.SelectedItems == null) return;
        foreach (Logic.Piece item in selected) LbxItems.SelectedItems.Add(item);
    }
    
    protected override void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        int index = LbxItems.SelectedIndex;
        List<long> selected = LbxItems.SelectedItems.Cast<Logic.Piece>().Select(x => x.PieceId).ToList();
        foreach (long id in selected)
        {
            _model.RemovePiece(id);
        }

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    private void OpenLayerEditor()
    {
        if(_listLayersEditor != null){return;}
        if(LbxItems.SelectedItems?[0] is not Logic.Piece piece){return;}
        _listLayersEditor = new ListLayersEditor(_model,piece.PieceId);
        _listLayersEditor.Closing += (_, _) => IsEnabled = true;
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        IsEnabled = false;
    }

    private void UpdateListLayer()
    {
        long? pieceId = null;
        if (LbxItems.SelectedItems == null)
        {
            BtnChangeLayers.IsEnabled = false;
            _model.LoadLayersOfPiece(pieceId);
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
                if(LbxItems.SelectedItems[0] is not Logic.Piece piece){return;}
                pieceId = piece.PieceId;
                BtnChangeLayers.IsEnabled = true;
                break;
            }
        }
        _model.LoadLayersOfPiece(pieceId);
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
        _model.NewPiece(piece);
    }
}