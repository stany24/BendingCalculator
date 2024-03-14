using BendingCalculator.Database.Actions;
using BendingCalculator.ViewModels;
using Xunit;

namespace Tests.ViewModel;

[Collection("SettingsCollection")]
public class PieceViewModelTests
{
    private readonly MainViewModel _model = new(DataBaseInitializer.InitializeDatabaseConnection());
    
    [Fact]
    public void CreateNewPieceTest()
    {
        int before = _model.Pieces.Count;
        _model.CreateNewPiece();
        Assert.Equal(_model.Pieces.Count,before+1);
    }

    [Fact]
    public void UpdatePieceTest()
    {

    }
    
    [Fact]
    public void RemovePieceTest()
    {
        Random rand = new();
        int nbPiece = rand.Next(1, 11);
        for (int i = 0; i < nbPiece; i++)
        {
            _model.CreateNewPiece();
            if (rand.Next(0, 2) != 1) continue;
            _model.SelectedPieces.Add(_model.Pieces[^1]);
        }
        int finalCount = _model.Pieces.Count - _model.SelectedPieces.Count;
        _model.RemovePieces();
        Assert.Equal(finalCount,_model.Pieces.Count);
    }
}