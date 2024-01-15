using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlexionV2.Database.Actions;
using FlexionV2.Logic;

namespace FlexionV2.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<Piece> _pieces = new();
    public ObservableCollection<Piece> Pieces { 
        get => _pieces;
        set => SetProperty(ref _pieces, value);
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
    
    public void NewPiece(Piece piece)
    {
        DataBaseCreator.NewPiece(_connection,piece);
    }

    public void UpdatePieces(List<Piece> piece)
    {
        DataBaseUpdater.UpdatePieces(_connection,piece);
    }

    public void RemovePiece(long id)
    {
        DataBaseRemover.RemovePiece(_connection,id);
    }
}