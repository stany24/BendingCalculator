using System;
using System.Collections.Generic;
using System.Linq;
using BendingCalculator.Assets.Localization.Static;
using CommunityToolkit.Mvvm.ComponentModel;

// ReSharper disable ValueParameterNotUsed  

namespace BendingCalculator.Logic.Math;

public partial class Layer : ObservableObject
{
    #region Display

    public sealed override string ToString()
    {
        return Material != null
            ? $"{Material.Name} {Static.Center}={WidthAtCenter * 1000}x{HeightAtCenter * 1000} {Static.Sides}={WidthOnSides * 1000}x{HeightOnSides * 1000}"
            : $"{Static.No} {Static.Material} {Static.Center}={WidthAtCenter * 1000}x{HeightAtCenter * 1000} {Static.Sides}={WidthOnSides * 1000}x{HeightOnSides * 1000}";
    }

    #endregion

    #region Variables

    public long Id { get; set; } = -1;
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private double _widthAtCenter;
    [ObservableProperty] private double _widthOnSides;
    [ObservableProperty] private double _heightAtCenter;
    [ObservableProperty] private double _heightOnSides;
    [ObservableProperty] private Material? _material;
    
    #endregion

    #region Constructor

    public Layer(){}
    public Layer(Material? material, double widthCenter, double widthSides, double heightCenter, double heightSides)
    {
        Material = material;
        WidthAtCenter = widthCenter;
        WidthOnSides = widthSides;
        HeightAtCenter = heightCenter;
        HeightOnSides = heightSides;
    }

    #endregion

    #region Math

    /// <summary>
    ///     Function used to get all the width of the layer
    /// </summary>
    /// <param name="length">The length of the piece</param>
    /// <param name="eRef">The E reference</param>
    /// <param name="xs">All the distances where we should me the calculations</param>
    /// <returns></returns>
    public IEnumerable<double> Width(double length, double eRef, double[] xs)
    {
        double l1 = (4 * WidthOnSides - 4 * WidthAtCenter) / (length * length);

        double[] l2 = Array.ConvertAll(xs, x => (x - length / 2) * (x - length / 2));

        double[] lf = Array.ConvertAll(l2, x => x * l1 + WidthAtCenter);
        Material ??= new Material("", 69);
        return Array.ConvertAll(lf, x => x / eRef * Material.E*(int)Material.Unit);
    }

    /// <summary>
    ///     Function used to get all the heights of the layer
    /// </summary>
    /// <param name="length">The length of the piece</param>
    /// <param name="xs">All the distances where we should me the calculations</param>
    /// <returns></returns>
    public double[] Height(double length, double[] xs)
    {
        double e1 = (4 * HeightOnSides - 4 * HeightAtCenter) / (length * length);

        double[] e2 = Array.ConvertAll(xs, x => (x - length / 2) * (x - length / 2));

        return Array.ConvertAll(e2, x => e1 * x + HeightAtCenter);
    }

    /// <summary>
    ///     Function used to get all the surfaces of the layer
    /// </summary>
    /// <param name="length">The length of the piece</param>
    /// <param name="eRef">The E reference</param>
    /// <param name="xs">All the distances where we should me the calculations</param>
    /// <returns></returns>
    public IEnumerable<double> Area(double length, double eRef, double[] xs)
    {
        IEnumerable<double> widths = Width(length, eRef, xs);

        double[] heights = Height(length, xs);

        return widths.Zip(heights, (x, y) => x * y).ToArray();
    }

    #endregion
}