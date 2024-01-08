using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FlexionV2.Logic;

public class Layer
{
    public long LayerId { get; set; }

    private double _widthAtCenter;
    [JsonInclude]
    public double WidthAtCenter
    {
        get =>_widthAtCenter;
        set { if (value > 0) { _widthAtCenter = value; } }
    }

    private double _widthOnSides;
    [JsonInclude]
    public double WidthOnSides
    {
        get =>_widthOnSides;
        set { if (value > 0) { _widthOnSides = value; } }
    }

    private double _heightAtCenter;
    [JsonInclude]
    public double HeightAtCenter
    {
        get =>_heightAtCenter;
        set { if (value > 0) { _heightAtCenter = value; } }
    }

    private double _heightOnSides;
    [JsonInclude]
    public double HeightOnSides
    {
        get =>_heightOnSides;
        set { if (value > 0) { _heightOnSides = value; } }
    }

    [JsonInclude]
    public Material? Material { get; set; }
        
    [JsonConstructor]
    public Layer() { }
        
    public Layer(double width, double height)
    {
        WidthAtCenter=width;
        WidthOnSides=width;
        HeightAtCenter=height;
        HeightOnSides = height;
    }
        
    public Layer(Material material, double width, double height)
    {
        Material = material;
        WidthAtCenter=width;
        WidthOnSides=width;
        HeightAtCenter=height;
        HeightOnSides = height;
    }
        
    public Layer(Material material, double widthCenter, double widthSides, double heightCenter, double heightSides)
    {
        Material = material;
        WidthAtCenter = widthCenter;
        WidthOnSides=widthSides;
        HeightAtCenter=heightCenter;
        HeightOnSides=heightSides;
    }
        
    public override string ToString()
    {
        return Material != null 
            ? $"{Material.Name} M={WidthAtCenter * 1000}x{HeightAtCenter * 1000} C={WidthOnSides * 1000}x{HeightOnSides * 1000}" 
            : $"Pas de matière M={WidthAtCenter * 1000}x{HeightAtCenter * 1000} C={WidthOnSides * 1000}x{HeightOnSides * 1000}";
    }

    public double[] Base(double longueur, double eref, double[] xs)
    {
        double l1 = (4 * WidthOnSides - 4 * WidthAtCenter) / Math.Pow(longueur, 2);
        double[] l2 = AdditionalMath.OperationDoubleArray(xs, longueur / 2, AdditionalMath.Operation.Minus);
        l2 = AdditionalMath.OperationDoubleArray(l2, 2, AdditionalMath.Operation.Power);
        double[] baseArea = AdditionalMath.OperationDoubleArray(l2, l1, AdditionalMath.Operation.Multiplication);
        baseArea = AdditionalMath.OperationDoubleArray(baseArea, WidthAtCenter, AdditionalMath.Operation.Plus);
        double divider = eref / Material.E;
        return AdditionalMath.OperationDoubleArray(baseArea, divider, AdditionalMath.Operation.Divided);
    }

    private IEnumerable<double> Width(double longueur, double eref, IEnumerable<double> xs)
    {
        double l1 = (4 * WidthOnSides - 4 * WidthAtCenter) / Math.Pow(longueur, 2);

        List<double> L2 = xs.Select(x => Math.Pow(x - longueur / 2, 2)).ToList();

        List<double> Lf = L2.Select(l2 => l1 * l2 + WidthAtCenter).ToList();

        return Lf.Select(lf => lf / eref * Material.E).ToList();
    }

    public List<double> Height(double longueur, IEnumerable<double> xs)
    {
        double e1 = (4 * HeightOnSides - 4 * HeightAtCenter) / Math.Pow(longueur, 2);

        List<double> e2 = xs.Select(x => Math.Pow(x - longueur / 2, 2)).ToList();

        return e2.Select(l2 => e1 * l2 + HeightAtCenter).ToList();
    }

    public List<double> Surface(double length, double eref, double[] xs)
    {
        IEnumerable<double> widths = Width(length, eref, xs);
        List<double> heights = Height(length, xs);
        return widths.Select((t, i) => t * heights[i]).ToList();
    }
}