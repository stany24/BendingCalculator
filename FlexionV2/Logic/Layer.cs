using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
// ReSharper disable ValueParameterNotUsed

namespace FlexionV2.Logic;

public class Layer:ObservableObject
{
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
        
    [JsonConstructor]
    public Layer() { }
        
    public Layer(Material? material, double widthCenter, double widthSides, double heightCenter, double heightSides)
    {
        Material = material;
        WidthAtCenter = widthCenter;
        WidthOnSides=widthSides;
        HeightAtCenter=heightCenter;
        HeightOnSides=heightSides;
    }
        
    public sealed override string ToString()
    {
        return Material != null 
            ? $"{Material.Name} Centre(mm)={WidthAtCenter*1000}x{HeightAtCenter*1000} Coté(mm)={WidthOnSides*1000}x{HeightOnSides*1000}" 
            : $"Pas de matière Centre(mm)={WidthAtCenter*1000}x{HeightAtCenter*1000} Coté(mm)={WidthOnSides*1000}x{HeightOnSides*1000}";
    }

    public double[] Base(double longueur, double eRef, double[] xs)
    {
        double l1 = (4 * WidthOnSides - 4 * WidthAtCenter) / Math.Pow(longueur, 2);
        double[] l2 = AdditionalMath.OperationDoubleArray(xs, longueur / 2, AdditionalMath.Operation.Minus);
        l2 = AdditionalMath.OperationDoubleArray(l2, 2, AdditionalMath.Operation.Power);
        double[] baseArea = AdditionalMath.OperationDoubleArray(l2, l1, AdditionalMath.Operation.Multiplication);
        baseArea = AdditionalMath.OperationDoubleArray(baseArea, WidthAtCenter, AdditionalMath.Operation.Plus);
        double divider = eRef / (Material ?? new Material("",69000000000)).E;
        return AdditionalMath.OperationDoubleArray(baseArea, divider, AdditionalMath.Operation.Divided);
    }

    private IEnumerable<double> Width(double longueur, double eRef, IEnumerable<double> xs)
    {
        double l1 = (4 * WidthOnSides - 4 * WidthAtCenter) / Math.Pow(longueur, 2);

        List<double> l2 = xs.Select(x => Math.Pow(x - longueur / 2, 2)).ToList();

        List<double> lf = l2.Select(l => l1 * l + WidthAtCenter).ToList();

        return lf.Select(l => l / eRef * (Material ?? new Material("",69000000000)).E).ToList();
    }

    public List<double> Height(double longueur, IEnumerable<double> xs)
    {
        double e1 = (4 * HeightOnSides - 4 * HeightAtCenter) / Math.Pow(longueur, 2);

        List<double> e2 = xs.Select(x => Math.Pow(x - longueur / 2, 2)).ToList();

        return e2.Select(l2 => e1 * l2 + HeightAtCenter).ToList();
    }

    public List<double> Surface(double length, double eRef, double[] xs)
    {
        IEnumerable<double> widths = Width(length, eRef, xs);
        List<double> heights = Height(length, xs);
        return widths.Select((t, i) => t * heights[i]).ToList();
    }
}