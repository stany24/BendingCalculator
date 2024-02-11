using Flexion.Database.Actions;
using Flexion.ViewModels;
using Xunit;

namespace FlexionTests.ViewModel;

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

    }
}