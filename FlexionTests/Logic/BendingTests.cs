using Flexion.Logic.Math;
using Xunit;

namespace FlexionTests.Logic;

public class BendingTests
{
    [Fact]
    public void SingleLayerRectangularPieceBendingTest()
    {
        Piece piece = new(0.77,"Test")
        {
            Layers = new List<Layer>
            {
                new()
                {
                    WidthAtCenter = 0.045,
                    WidthOnSides = 0.045,
                    HeightAtCenter = 0.01,
                    HeightOnSides = 0.01,
                    Material = new Material
                    {
                        Name = "Bois",
                        E = 17000000000
                    }
                }
            }
        };
        IEnumerable<double> values = piece.CalculateFlexion(100, piece.Length / 10000);
        Assert.Equal(-14.924,values.Min()*1000,0.001);
    }
    
    [Fact]
    public void MultiLayerRectangularPieceBendingTest()
    {
        Piece piece = new(0.77,"Test")
        {
            Layers = new List<Layer>
            {
                new()
                {
                    WidthAtCenter = 0.03,
                    WidthOnSides = 0.03,
                    HeightAtCenter = 0.002,
                    HeightOnSides = 0.002,
                    Material = new Material
                    {
                        Name = "Alu",
                        E = 69000000000
                    }
                },
                new()
                {
                    WidthAtCenter = 0.045,
                    WidthOnSides = 0.045,
                    HeightAtCenter = 0.01,
                    HeightOnSides = 0.01,
                    Material = new Material
                    {
                        Name = "Bois",
                        E = 17000000000
                    }
                },
                new()
                {
                    WidthAtCenter = 0.03,
                    WidthOnSides = 0.03,
                    HeightAtCenter = 0.002,
                    HeightOnSides = 0.002,
                    Material = new Material
                    {
                        Name = "Alu",
                        E = 69000000000
                    }
                }
            }
        };
        IEnumerable<double> values = piece.CalculateFlexion(100, piece.Length / 10000);
        Assert.Equal(-2.609,values.Min()*1000,0.001);
    }
    
    [Fact]
    public void MultiLayerPieceBendingTest()
    {
        Piece piece = new(0.77,"Test")
        {
            Layers = new List<Layer>
            {
                new()
                {
                    WidthAtCenter = 0.03,
                    WidthOnSides = 0.04,
                    HeightAtCenter = 0.002,
                    HeightOnSides = 0.004,
                    Material = new Material
                    {
                        Name = "Alu",
                        E = 69000000000
                    }
                },
                new()
                {
                    WidthAtCenter = 0.05,
                    WidthOnSides = 0.045,
                    HeightAtCenter = 0.012,
                    HeightOnSides = 0.01,
                    Material = new Material
                    {
                        Name = "Bois",
                        E = 17000000000
                    }
                },
                new()
                {
                    WidthAtCenter = 0.03,
                    WidthOnSides = 0.04,
                    HeightAtCenter = 0.002,
                    HeightOnSides = 0.004,
                    Material = new Material
                    {
                        Name = "Alu",
                        E = 69000000000
                    }
                }
            }
        };
        IEnumerable<double> values = piece.CalculateFlexion(100, piece.Length / 10000);
        Assert.Equal(-1.653,values.Min()*1000,0.001);
    }
}