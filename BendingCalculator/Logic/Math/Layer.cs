using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

// ReSharper disable ValueParameterNotUsed  

namespace BendingCalculator.Logic.Math;

public class Layer:ObservableObject
{
    #region Variables

    public long LayerId { get; set; }

    private double _widthAtCenter;
    public double WidthAtCenter
    {
        get =>_widthAtCenter;
        set
        {
            if (value <= 0) return;
            _widthAtCenter = value;
            Display = ToString();
        }
    }

    private double _widthOnSides;
    public double WidthOnSides
    {
        get =>_widthOnSides;
        set
        {
            if (value <= 0) return;
            _widthOnSides = value;
            Display = ToString();
        }
    }

    private double _heightAtCenter;
    public double HeightAtCenter
    {
        get =>_heightAtCenter;
        set
        {
            if (value <= 0) return;
            _heightAtCenter = value;
            Display = ToString();
        }
    }

    private double _heightOnSides;
    public double HeightOnSides
    {
        get =>_heightOnSides;
        set
        {
            if (value <= 0) return;
            _heightOnSides = value;
            Display = ToString();
        }
    }

    private Material? _material;
    public Material? Material { get => _material;
        set
        {
            _material = value;
            Display = ToString();
        }
        
    }
    
    private string? _display;
    public string Display
    {
        get => _display ?? ToString();
        set => SetProperty(ref _display, value);
    }

    #endregion

    #region Constructor / Destructor
    
    public Layer()
    {
        LanguageEvents.LanguageChanged += UpdateDisplay;
    }
        
    public Layer(Material? material, double widthCenter, double widthSides, double heightCenter, double heightSides)
    {
        Material = material;
        WidthAtCenter = widthCenter;
        WidthOnSides=widthSides;
        HeightAtCenter=heightCenter;
        HeightOnSides=heightSides;
        LanguageEvents.LanguageChanged += UpdateDisplay;
    }

    ~Layer()
    {
        LanguageEvents.LanguageChanged -= UpdateDisplay;
    }

    #endregion

    #region Display

    private void UpdateDisplay(object? sender, EventArgs e)
    {
        Display = ToString();
    }
        
    public sealed override string ToString()
    {
        return Material != null 
            ? $"{Material.Name} {Assets.Localization.Logic.LogicLocalization.Center}={WidthAtCenter*1000}x{HeightAtCenter*1000} {Assets.Localization.Logic.LogicLocalization.Sides}={WidthOnSides*1000}x{HeightOnSides*1000}" 
            : $"{Assets.Localization.Logic.LogicLocalization.No} {Assets.Localization.Logic.LogicLocalization.MaterialWithColon} {Assets.Localization.Logic.LogicLocalization.Center}={WidthAtCenter*1000}x{HeightAtCenter*1000} {Assets.Localization.Logic.LogicLocalization.Sides}={WidthOnSides*1000}x{HeightOnSides*1000}";
    }

    #endregion

    #region Math

    /// <summary>
    /// Function used to get all the width of the layer
    /// </summary>
    /// <param name="length">The length of the piece</param>
    /// <param name="eRef">The E reference</param>
    /// <param name="xs">All the distances where we should me the calculations</param>
    /// <returns></returns>
    public IEnumerable<double> Width(double length, double eRef, double[] xs)
    {
        double l1 = (4 * WidthOnSides - 4 * WidthAtCenter) / (length*length);

        double[] l2 = Array.ConvertAll(xs, x => (x - length / 2)*(x - length / 2));

        double[] lf = Array.ConvertAll(l2,x=>x*l1+WidthAtCenter);

        return Array.ConvertAll(lf,x => x / eRef * (Material ?? new Material("",69000000000)).E);
    }

    /// <summary>
    /// Function used to get all the heights of the layer
    /// </summary>
    /// <param name="length">The length of the piece</param>
    /// <param name="xs">All the distances where we should me the calculations</param>
    /// <returns></returns>
    public double[] Height(double length, double[] xs)
    {
        double e1 = (4 * HeightOnSides - 4 * HeightAtCenter) / (length*length);

        double[] e2 = Array.ConvertAll(xs,x => (x - length / 2)*(x - length / 2));

        return Array.ConvertAll(e2,x => e1 * x + HeightAtCenter);
    }

    /// <summary>
    /// Function used to get all the surfaces of the layer
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