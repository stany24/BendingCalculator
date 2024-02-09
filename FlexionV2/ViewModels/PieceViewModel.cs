using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;
using FlexionV2.Views.Editors.Piece;

namespace FlexionV2.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<Piece> _pieces = new();
    public ObservableCollection<Piece> Pieces { 
        get => _pieces;
        set => SetProperty(ref _pieces, value);
    }
    
    private ObservableCollection<Piece> _selectedPieces = new();
    public ObservableCollection<Piece> SelectedPieces { 
        get => _selectedPieces;
        set
        {
            SetProperty(ref _selectedPieces, value);
            UpdateListLayer();
        }
    }

    public double PieceLength { get; set; } = 1;
    public string PieceName { get; set; } = string.Empty;
    public bool BtnChangeLayerEnabled { get; set; }
    
    private ListLayersEditor? _listLayersEditor;

    public void CloseLayerOfPieceEditor()
    {
        _listLayersEditor?.Close();
    }
    
    private void ReloadPieces()
    {
        List<Piece> pieces = DataBaseLoader.LoadPieces(_connection);
        while (pieces.Count != Pieces.Count)
        {
            if (pieces.Count < Pieces.Count)
            {
                Pieces.RemoveAt(0);
            }
            else
            {
                Pieces.Add(new Piece());
            }
        }

        for (int i = 0; i < pieces.Count; i++)
        {
            Pieces[i].Layers = pieces[i].Layers;
            Pieces[i].PieceId = pieces[i].PieceId;
            Pieces[i].Name = pieces[i].Name;
            Pieces[i].Length = pieces[i].Length;
        }
    }
    
    public void PieceLengthChanged()
    {
        foreach (Piece piece in SelectedPieces)
        {
            piece.Length = PieceLength/1000;
        }
        DataBaseUpdater.UpdatePieces(_connection,SelectedPieces.ToList());
    }

    public void PieceNameChanged()
    {
        foreach (Piece piece in SelectedPieces)
        {
            piece.Name = PieceName;
        }
        DataBaseUpdater.UpdatePieces(_connection,SelectedPieces.ToList());
    }

    private int SelectedPieceIndex { get; set; }
    public void RemovePiece()
    {
        int index = SelectedPieceIndex;
        List<long> selected = SelectedPieces.Select(x => x.PieceId).ToList();
        foreach (long id in selected)
        {
            DataBaseRemover.RemovePiece(_connection,id);
        }

        if (index <= 0) return;
        SelectedPieceIndex = SelectedPieces.Count > index ? index : SelectedPieces.Count;
    }
    
    public void OpenLayerOfPieceEditor()
    {
        if(_listLayersEditor != null){return;}
        _listLayersEditor = new ListLayersEditor(this,SelectedPieces[0].PieceId);
        _listLayersEditor.Closing += (_, _) => BtnChangeLayerEnabled = true;
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        BtnChangeLayerEnabled = false;
    }

    private void UpdateListLayer()
    {
        long? pieceId = null;
        bool enabled = false;
        if (SelectedPieces is { Count: 1 })
        {
            pieceId = SelectedPieces[0].PieceId;
            enabled = true;
            BtnChangeLayerEnabled = true;
        }
        
        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => {BtnChangeLayerEnabled = enabled; });
        LoadLayersOfPiece(pieceId);
    }

    public void CreateNewPiece()
    {
        Piece piece = new(PieceLength/1000, PieceName, 69e9);
        DataBaseCreator.NewPiece(_connection,piece);
    }
}