using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

// ReSharper disable ValueParameterNotUsed

namespace Flexion.Logic.Math;

public class Layer:ObservableObject
{
    #region Variables

    public long LayerId { get; set; }

    private double _widthAtCenter;
    [JsonInclude]
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
    [JsonInclude]
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
    [JsonInclude]
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
    [JsonInclude]
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
    [JsonInclude]
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
        set => SetProperty(ref _display, ToString());
    }

    #endregion

    #region Constructor / Destructor

    [JsonConstructor]
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

    public IEnumerable<double> Width(double longueur, double eRef, double[] xs)
    {
        double l1 = (4 * WidthOnSides - 4 * WidthAtCenter) / (longueur*longueur);

        double[] l2 = Array.ConvertAll(xs, x => (x - longueur / 2)*(x - longueur / 2));

        double[] lf = Array.ConvertAll(l2,x=>x*l1+WidthAtCenter);

        return Array.ConvertAll(lf,x => x / eRef * (Material ?? new Material("",69000000000)).E);
    }

    public double[] Height(double longueur, double[] xs)
    {
        double e1 = (4 * HeightOnSides - 4 * HeightAtCenter) / (longueur*longueur);

        double[] e2 = Array.ConvertAll(xs,x => (x - longueur / 2)*(x - longueur / 2));

        return Array.ConvertAll(e2,x => e1 * x + HeightAtCenter);
    }

    public IEnumerable<double> Surface(double length, double eRef, double[] xs)
    {
        IEnumerable<double> widths = Width(length, eRef, xs);
        
        double[] heights = Height(length, xs);
        
        return widths.Zip(heights, (x, y) => x * y).ToArray();
    }

    #endregion
}