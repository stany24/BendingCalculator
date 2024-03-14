using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.Views.Editors.Piece;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    private ListLayersEditor? _listLayersEditor;
    
    private bool _btnChangeLayerEnabled;
    public bool BtnChangeLayerEnabled { 
        get => _btnChangeLayerEnabled;
        set => SetProperty(ref _btnChangeLayerEnabled, value);
    }
    
    private ObservableCollection<Piece> _pieces = new();
    public ObservableCollection<Piece> Pieces { 
        get => _pieces;
        set => SetProperty(ref _pieces, value);
    }

    public ObservableCollection<Piece> SelectedPieces { get; set; } = new();
    private int SelectedPieceIndex { get; set; }

    private double _pieceLength = 1;

    public double? PieceLength
    {
        get => _pieceLength;
        set
        {
            _pieceLength = value ?? _pieceLength;
            PieceLengthChanged();
        }
    }

    private string _pieceName = string.Empty;
    public string PieceName { get => _pieceName;
        set
        {
            _pieceName = value;
            PieceNameChanged();
        }
    }

    #endregion

    #region Piece Edition

    public void CreateNewPiece()
    {
        Piece piece = new(_pieceLength/1000, "nouveau");
        DataBaseCreator.NewPiece(_connection,piece);
    }

    public void RemovePieces()
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
    
    private void PieceLengthChanged()
    {
        foreach (Piece piece in SelectedPieces)
        {
            piece.Length = _pieceLength/1000;
        }
        DataBaseUpdater.UpdatePieces(_connection,SelectedPieces.ToList());
    }

    private void PieceNameChanged()
    {
        foreach (Piece piece in SelectedPieces)
        {
            piece.Name = PieceName;
        }
        DataBaseUpdater.UpdatePieces(_connection,SelectedPieces.ToList());
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
    
    #endregion

    #region LayerOfPieceEditor

    public void CloseLayerOfPieceEditor()
    {
        _listLayersEditor?.Close();
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

    #endregion
    
    private void SelectedPieceChanged()
    {
        if(SelectedPieces.Count == 0)
        {
            BtnChangeLayerEnabled = false;
            return;
        }
        BtnChangeLayerEnabled = true;
        LoadLayersOfPiece(SelectedPieces[0].PieceId);
    }
}