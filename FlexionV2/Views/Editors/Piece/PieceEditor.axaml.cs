using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views.Editors.Piece;

public partial class PieceEditor : Window
{
    private ListLayersEditor? _listLayersEditor;
    public PieceEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        NudLength.ValueChanged += (_,_) => NumericChanged();
        TbxName.TextChanged += (_, _) => TextChanged();
        BtnRemove.Click +=(_,_) => RemoveItems();
        BtnAdd.Click += (_, _) => CreateNewPiece();
        LbxItems.SelectionChanged += (_,_) => UpdateListLayer();
        BtnChangeLayers.Click += (_, _) => OpenLayerEditor();
        Closing += (_, _) => _listLayersEditor?.Close();
    }

    private void NumericChanged()
    {
        if(LbxItems.SelectedItems == null){return;}
        if(NudLength.Value == null){return;}
        if(DataContext is not MainViewModel model){return;}
        List<Logic.Piece> pieces = LbxItems.SelectedItems.Cast<Logic.Piece>().ToList();
        foreach (Logic.Piece piece in pieces)
        {
            piece.Length = (double)NudLength.Value/1000;
        }
        model.UpdatePieces(pieces);
    }

    private void TextChanged()
    {
        if(LbxItems.SelectedItems == null){return;}
        if(TbxName.Text == null){return;}
        if(DataContext is not MainViewModel model){return;}
        List<Logic.Piece> pieces = LbxItems.SelectedItems.Cast<Logic.Piece>().ToList();
        foreach (Logic.Piece piece in pieces)
        {
            piece.Name = TbxName.Text;
        }
        model.UpdatePieces(pieces);
    }

    private void RemoveItems()
    {
        if (LbxItems.SelectedItems == null) return;
        if(DataContext is not MainViewModel model){return;}
        int index = LbxItems.SelectedIndex;
        List<long> selected = LbxItems.SelectedItems.Cast<Logic.Piece>().Select(x => x.PieceId).ToList();
        foreach (long id in selected)
        {
            model.RemovePiece(id);
        }

        if (index <= 0) return;
        LbxItems.SelectedIndex = LbxItems.Items.Count > index ? index : LbxItems.Items.Count;
    }
    
    private void OpenLayerEditor()
    {
        if(_listLayersEditor != null){return;}
        if(DataContext is not MainViewModel model){return;}
        if(LbxItems.SelectedItems?[0] is not Logic.Piece piece){return;}
        _listLayersEditor = new ListLayersEditor(model,piece.PieceId);
        _listLayersEditor.Closing += (_, _) => IsEnabled = true;
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        IsEnabled = false;
    }

    private void UpdateListLayer()
    {
        if(DataContext is not MainViewModel model){return;}
        long? pieceId = null;
        bool enabled = false;
        if (LbxItems.SelectedItems is { Count: 1 })
        {
            if(LbxItems.SelectedItems[0] is not Logic.Piece piece){return;}
            pieceId = piece.PieceId;
            enabled = true;
            BtnChangeLayers.IsEnabled = true;
        }
        
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => {BtnChangeLayers.IsEnabled = enabled; });
        model.LoadLayersOfPiece(pieceId);
    }

    private void CreateNewPiece()
    {
        if(DataContext is not MainViewModel model){return;}
        Logic.Piece piece = new(Convert.ToDouble(NudLength.Value/1000 ?? 1), TbxName.Text ?? "nouveau");
        model.NewPiece(piece);
    }
}