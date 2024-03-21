using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;
using BendingCalculator.Views.Editors.Piece;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    #region Bindings

    private ListLayersEditor? _listLayersEditor;
    
    private bool _uiEnabledPieceEditor;
    public bool UiEnabledPieceEditor { 
        get => _uiEnabledPieceEditor;
        set => SetProperty(ref _uiEnabledPieceEditor, value);
    }
    
    private ObservableCollection<Piece> _pieces = new();
    public ObservableCollection<Piece> Pieces { 
        get => _pieces;
        set => SetProperty(ref _pieces, value);
    }

    private Piece? _selectedPiece;
    public Piece? SelectedPiece
    {
        get => _selectedPiece;
        set
        {
            SetProperty(ref _selectedPiece, value);
            SelectedPieceChanged();
        }
    }

    private double _pieceLength;
    public double PieceLength
    {
        get => _pieceLength;
        set
        {
            SetProperty(ref _pieceLength, value);
            PieceLengthChanged();
        }
    }

    private string _pieceName;
    public string PieceName 
    { 
        get => _pieceName;
        set
        {
            SetProperty(ref _pieceName, value);
            PieceNameChanged();
        }
    }

    #endregion

    #region Piece Edition

    public void CreateNewPiece()
    {
        Piece piece = new(1, "new");
        DataBaseCreator.NewPiece(_connection,piece);
        SelectedPiece = Pieces[^1];
    }

    public void RemovePiece()
    {
        if(SelectedPiece == null){return;}
        DataBaseRemover.RemovePiece(_connection,SelectedPiece.PieceId);
        SelectedPiece = null;
    }
    
    private void PieceLengthChanged()
    {
        if(SelectedPiece == null){return;}
        SelectedPiece.Length = PieceLength/1000;
        DataBaseUpdater.UpdatePieces(_connection,SelectedPiece);
    }

    private void PieceNameChanged()
    {
        if(SelectedPiece == null){return;}
        SelectedPiece.Name = PieceName;
        DataBaseUpdater.UpdatePieces(_connection,SelectedPiece);
    }
    
    private void ReloadPieces(object? sender, EventArgs eventArgs)
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
        if(SelectedPiece is null){return;}   
        if(_listLayersEditor != null){return;}
        _listLayersEditor = new ListLayersEditor(this,SelectedPiece.PieceId);
        _listLayersEditor.Closing += (_, _) => UiEnabledPieceEditor = true;
        _listLayersEditor.Closed += (_, _) => _listLayersEditor = null;
        _listLayersEditor.Show();
        UiEnabledPieceEditor = false;
    }

    #endregion
    
    private void SelectedPieceChanged()
    {
        if(SelectedPiece == null)
        {
            UiEnabledPieceEditor = false;
            PieceName = string.Empty;
            PieceLength = 0;
            return;
        }
        UiEnabledPieceEditor = true;
        PieceName = SelectedPiece.Name;
        PieceLength = SelectedPiece.Length*1000;
        LoadLayersOfPiece(SelectedPiece.PieceId);
    }
}