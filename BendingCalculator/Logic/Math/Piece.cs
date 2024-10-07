using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BendingCalculator.Assets.Localization.Static;
using CommunityToolkit.Mvvm.ComponentModel;

// ReSharper disable ValueParameterNotUsed

namespace BendingCalculator.Logic.Math;

public partial class Piece : ObservableObject
{
    #region Display

    public override string ToString()
    {
        return Layers.Count switch
        {
            0 => $"{Name} / {Length * 1000}mm",
            _ => $"{Name} / {Length * 1000}mm / {Layers.Count} {Static.Layers}"
        };
    }

    #endregion

    #region Variables

    public long Id { get; set; } = -1;
    public EventHandler<RiskOfDetachmentOfLayersEventArgs>? RiskOfDetachmentBetweenLayer { get; set; }

    public ObservableCollection<Layer> Layers { get; set; } = new();

    [ObservableProperty] private string _name = string.Empty;

    [ObservableProperty] private double _length;

    private const double ERef = 69e9;

    private double[] _xs = Array.Empty<double>();

    private double[] SetX(double gap)
    {
        List<double> x = new();
        for (double i = 0; i <= Length; i += gap) x.Add(i);
        return x.ToArray();
    }

    #endregion

    #region Constructor / Destructor

    public Piece(double length, string name)
    {
        Length = length;
        Name = name;
    }

    public Piece()
    {
        Name = string.Empty;
        Length = 1;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Piece other)
        {
            return Id == other.Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Length);
    }

    #endregion

    #region Math

    private double[] MomentForce(double force)
    {
        double[] moments = new double[_xs.Length];
        double offset = -force / 2 * _xs[_xs.Length / 2] - force / 2 * _xs[_xs.Length / 2];

        for (int i = 0; i < _xs.Length; i++)
            if (_xs[i] < Length / 2)
                moments[i] = -force / 2 * _xs[i];
            else
                moments[i] = force / 2 * _xs[i] + offset;
        return moments;
    }

    /// <summary>
    ///     Function used to calculate the bending of a piece
    /// </summary>
    /// <param name="force">The force applied to a piece</param>
    /// <param name="gap">The gap between measurements</param>
    /// <returns></returns>
    public BendingResult CalculateBending(double force, double gap)
    {
        BendingResult result = new();
        CheckRisks();
        _xs = SetX(gap);
        result.Integral1 = new double[_xs.Length];
        result.Integral2 = new double[_xs.Length];
        result.Ns = Ns();
        result.Moment = MomentForce(force);
        result.I = CalculateI();
        result.Constraint = result.Moment.Zip(result.I, (x, y) => x / y).ToArray();
        result.Integral1 = FirstIntegral(result.Constraint, result.Integral1, gap);
        result.Integral2 = SecondIntegral(result.Integral1, result.Integral2, gap);
        return result;
    }

    private void CheckRisks()
    {
        for (int i = 1; i < Layers.Count; i++)
        {
            if (Layers[i - 1].Material is not { } material1) return;
            if (Layers[i].Material is not { } material2) return;
            double ratio;
            if (material1.E*(int)material1.Unit > material2.E*(int)material2.Unit)
                ratio = (double)material1.E*(int)material1.Unit / material2.E*(int)material2.Unit;
            else
                ratio = (double)material2.E*(int)material1.Unit / material1.E*(int)material2.Unit;
            if (ratio <= 100) continue;
            RiskOfDetachmentBetweenLayer?.Invoke(null,
                new RiskOfDetachmentOfLayersEventArgs(i - 1, i, Layers[i - 1], Layers[i]));
            return;
        }
    }

    private static double[] FirstIntegral(IReadOnlyList<double> function, double[] integral1, double gap)
    {
        integral1[0] = function[0] * gap;
        for (int i = 1; i < function.Count; i++) integral1[i] = integral1[i - 1] + function[i] * gap;
        double constant = integral1[integral1.Length / 2];
        return Array.ConvertAll(integral1, x => x - constant).ToArray();
    }

    private static double[] SecondIntegral(IReadOnlyList<double> integral1, double[] integral2, double gap)
    {
        integral2[0] = integral1[0] * gap;
        for (int i = 1; i < integral2.Length; i++) integral2[i] = integral2[i - 1] + integral1[i] * gap;
        return Array.ConvertAll(integral2, x => x / -ERef);
    }

    private double[] CalculateI()
    {
        double[][] ix = new double[Layers.Count][];
        double[] I = new double[_xs.Length];
        //calculate the Ix in a generalized way.
        for (int i = 0; i < Layers.Count; i++)
        {
            double[] heights = Layers[i].Height(Length, _xs);
            double[] power = Array.ConvertAll(heights, x => x * x * x);
            IEnumerable<double> widths = Layers[i].Width(Length, ERef, _xs);
            double[] divided = power.Zip(widths, (x, y) => x * y).ToArray();
            ix[i] = Array.ConvertAll(divided, x => x / 12);
        }

        //calculate I with the Ix
        for (int i = 0; i < Layers.Count; i++)
        {
            double[] p1 = CalculateNx(i, _xs.Length).Zip(Ns(), (x, y) => x - y).ToArray();
            double[] p2 = Array.ConvertAll(p1, x => x * x);
            IEnumerable<double> surfaces = Layers[i].Area(Length, ERef, _xs);
            double[] p3 = surfaces.Zip(p2, (x, y) => x * y).ToArray();
            double[] p4 = ix[i].Zip(p3, (x, y) => x + y).ToArray();
            I = I.Zip(p4, (x, y) => x + y).ToArray();
        }

        return I;
    }

    private double[] Ns()
    {
        double[][] nx = new double[Layers.Count][];
        double[] divided = new double[_xs.Length];
        double[] divider = new double[_xs.Length];
        //calculate Nx in a generalized way.
        for (int i = 0; i < nx.Length; i++)
        {
            nx[i] = CalculateNx(i, _xs.Length);
            double[] ni = nx[i].Zip(Layers[i].Area(Length, ERef, _xs), (x, y) => x * y).ToArray();
            divided = divided.Zip(ni, (x, y) => x + y).ToArray();
            divider = divider.Zip(Layers[i].Area(Length, ERef, _xs), (x, y) => x + y).ToArray();
        }

        //calculation of Ns
        return divided.Zip(divider, (x, y) => x / y).ToArray();
    }

    private double[] CalculateNx(int i, int length)
    {
        double[] nx = new double[length];
        for (int j = 0; j <= i; j++)
        {
            double[] heights = Layers[j].Height(Length, _xs);
            if (j == i) heights = Array.ConvertAll(heights, x => x / 2);
            nx = nx.Zip(heights, (x, y) => x + y).ToArray();
        }

        return nx;
    }

    #endregion
}