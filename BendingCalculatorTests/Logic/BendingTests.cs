﻿using System.Collections.ObjectModel;
using BendingCalculator.Logic.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BendingCalculatorTests.Logic;

[TestClass]
public class BendingTests
{
    // All length values are in meters except the results in millimeters
    [TestMethod]
    public void SingleLayerRectangularPieceBendingTest()
    {
        Piece piece = new(0.77, "Test")
        {
            Layers = new ObservableCollection<Layer>
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
                        E = 17
                    }
                }
            }
        };
        IEnumerable<double> values = piece.CalculateBending(100, piece.Length / 10000).Integral2;
        Assert.AreEqual(-14.924, values.Min() * 1000, 0.001);
    }

    [TestMethod]
    public void MultiLayerRectangularPieceBendingTest()
    {
        Piece piece = new(0.77, "Test")
        {
            Layers = new ObservableCollection<Layer>
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
                        E = 69
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
                        E = 17
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
                        E = 69
                    }
                }
            }
        };
        IEnumerable<double> values = piece.CalculateBending(100, piece.Length / 10000).Integral2;
        Assert.AreEqual(-2.609, values.Min() * 1000, 0.001);
    }

    [TestMethod]
    public void MultiLayerPieceBendingTest()
    {
        Piece piece = new(0.77, "Test")
        {
            Layers = new ObservableCollection<Layer>
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
                        E = 69
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
                        E = 17
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
                        E = 69
                    }
                }
            }
        };
        IEnumerable<double> values = piece.CalculateBending(100, piece.Length / 10000).Integral2;
        Assert.AreEqual(-1.653, values.Min() * 1000, 0.001);
    }
}