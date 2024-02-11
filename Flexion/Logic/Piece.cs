using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

// ReSharper disable ValueParameterNotUsed

namespace Flexion.Logic;

public class Piece:ObservableObject
{
    public long PieceId { get; set; }
    
    [JsonInclude]
    public List<Layer> Layers { get; set; }

    private string _name;
    [JsonInclude]
    public string Name
    {
        get => _name;
        set
        {
            if (value == "") return;
            _name = value;
            Display = ToString();
        }
    }

    private double _length;
    [JsonInclude]
    public double Length
    {
        get => _length;
        set
        {
            if (value <= 0) return;
            _length = value;
            Display = ToString();
        }
    }

    private double _eRef = 69e9;
    [JsonInclude]
    public double ERef
    {
        get => _eRef;
        set { if (value > 0) { _eRef = value; }}
    }
        
    private double[] _xs;

    private double[] SetX(double gap)
    {
        List<double> x = new();
        for (double i = 0; i <= Length + gap; i += gap)
        {
            x.Add(i);
        }
        return x.ToArray();
    }
    
    private string? _display;
    public string Display
    {
        get => _display ?? ToString();
        set => SetProperty(ref _display, ToString());
    }

    public Piece(double length, string name, double? eRef)
    {
        Layers = new List<Layer>();
        _length = length;
        _name = name;
        _eRef = eRef ?? 69e9;
    }

    [JsonConstructor]
    public Piece() { }
    
    public override string ToString()
    {
        return Layers.Count switch
        {
            0 => $"{Name} / {Length*1000}mm",
            _ => $"{Name} / {Length*1000}mm / {Layers.Count} {Assets.Localization.Resources.Layers}"
        };
    }

    /// <summary>
    /// Function used to calculate the torque
    /// </summary>
    /// <param name="force">The force applied to the piece</param>
    /// <returns></returns>
    private double[] MomentForce(double force)
    {
        double b1 = Length / 2;
        double[] x = _xs;
        double[] moments = new double[_xs.Length];

        double[] mfa1 = AdditionalMath.OperationDoubleArray((double[])_xs.Clone(), -force * b1, AdditionalMath.Operation.Multiplication);
        mfa1 = AdditionalMath.OperationDoubleArray(mfa1, Length, AdditionalMath.Operation.Divided);

        double[] mfb1 = AdditionalMath.OperationDoubleArray((double[])_xs.Clone(), Length - b1, AdditionalMath.Operation.Minus);
        mfb1 = AdditionalMath.OperationDoubleArray(mfb1, force, AdditionalMath.Operation.Multiplication);
        mfb1 = AdditionalMath.OperationDoubleArray(mfa1, mfb1, AdditionalMath.Operation.Plus);

        for (int i = 0; i < _xs.Length; i++)
        {
            if (x[i] < b1)
            {
                moments[i] = mfa1[i];
            }
            else
            {
                moments[i] = mfb1[i];
            }
        }
        return moments;
    }
    
    /// <summary>
    /// Function used to calculate the flexion of a piece
    /// </summary>
    /// <param name="force">The force applied to a piece</param>
    /// <param name="gap">The gap between measurements</param>
    /// <returns></returns>
    public IEnumerable<double> CalculateFlexion(double force, double gap)
    {
        _xs = SetX(gap);
        double[] integral1 = new double[_xs.Length];
        double[] integral2 = new double[_xs.Length];
        double[] integral3 = new double[_xs.Length];
        double[] moment = MomentForce(force);
        double[] I = CalculateI();
        for (int i = 0; i < moment.Length; i++)
        {
            integral1[i] = moment[i] / I[i];
        }
        // first integral
        for (int i = 0; i < moment.Length; i++)
        {
            if (i - 1 < 0)
            {
                integral2[i] = integral1[i] * gap;
            }
            else
            {
                integral2[i] = integral2[i - 1] + integral1[i] * gap;
            }
        }

        double offset = integral2[Convert.ToInt32(integral2.Length / 2)];
        for (int i = 0; i < integral2.Length; i++)
        {
            integral2[i] -= offset;
        }

        // second integral
        for (int i = 0; i < integral3.Length; i++)
        {
            if (i - 1 < 0)
            {
                integral3[i] = integral2[i] * gap;
            }
            else
            {
                integral3[i] = integral3[i - 1] + integral2[i] * gap;
            }
        }
        for (int i = 0; i < integral3.Length; i++)
        {
            integral3[i] /= -ERef;
        }
        return integral3;
    }

    private double[] CalculateI()
    {
        double[][] ix = new double[Layers.Count][];
        double[] I = new double[_xs.Length];

        //initialize the arrays
        for (int i = 0; i < ix.Length; i++)
        {
            ix[i] = new double[_xs.Length];
        }

        //calculate the Ix in a generalized way.
        for (int i = 0; i < Layers.Count; i++)
        {
            double[] power = AdditionalMath.OperationDoubleArray(Layers[i].Height(Length, (double[])_xs.Clone()).ToArray(), 3, AdditionalMath.Operation.Power);
            double[] divider = AdditionalMath.OperationDoubleArray(power, Layers[i].Base(Length, ERef, (double[])_xs.Clone()), AdditionalMath.Operation.Multiplication);
            ix[i] = AdditionalMath.OperationDoubleArray(divider, 12, AdditionalMath.Operation.Divided);
        }

        for (int i = 0; i < Layers.Count; i++)
        {
            double[] p1 = AdditionalMath.OperationDoubleArray(CalculateNx(i, _xs.Length), Ns(), AdditionalMath.Operation.Minus);
            double[] p2 = AdditionalMath.OperationDoubleArray(p1, 2, AdditionalMath.Operation.Power);
            double[] p3 = AdditionalMath.OperationDoubleArray(Layers[i].Surface(Length, ERef, (double[])_xs.Clone()).ToArray(), p2, AdditionalMath.Operation.Multiplication);
            double[] p4 = AdditionalMath.OperationDoubleArray(ix[i], p3, AdditionalMath.Operation.Plus);
            I = AdditionalMath.OperationDoubleArray(I, p4, AdditionalMath.Operation.Plus);
        }
        return I;
    }

    private double[] Ns()
    {
        double[][] nx = new double[Layers.Count][];
        double[] divided = new double[_xs.Length];
        double[] divider = new double[_xs.Length];

        //initialize the arrays
        for (int i = 0; i < nx.Length; i++)
        {
            nx[i] = new double[_xs.Length];
        }

        //calculate Nx in a generalized way.
        for (int i = 0; i < Layers.Count; i++)
        {
            nx[i] = CalculateNx(i, _xs.Length);
        }

        //calculation of the divided
        divided = Layers.Select((t, i) => AdditionalMath.OperationDoubleArray(t.Surface(Length, ERef, (double[])_xs.Clone()).ToArray(), nx[i], AdditionalMath.Operation.Multiplication)).Aggregate(divided, (current, added) => AdditionalMath.OperationDoubleArray(current, added, AdditionalMath.Operation.Plus));

        // calculation of dividing
        divider = Layers.Aggregate(divider, (current, t) => AdditionalMath.OperationDoubleArray(current, t.Surface(Length, ERef, (double[])_xs.Clone()).ToArray(), AdditionalMath.Operation.Plus));
        //calculation of Ns
        return AdditionalMath.OperationDoubleArray(divided, divider, AdditionalMath.Operation.Divided);
    }

    private double[] CalculateNx(int i, int length)
    {
        double[] nx = new double[length];
        for (int j = 0; j <= i; j++)
        {
            if (j == i)
            {
                double[] add = AdditionalMath.OperationDoubleArray(Layers[j].Height(Length, (double[])_xs.Clone()).ToArray(), 2, AdditionalMath.Operation.Divided);
                nx = AdditionalMath.OperationDoubleArray(nx, add, AdditionalMath.Operation.Plus);
            }
            else
            {
                nx = AdditionalMath.OperationDoubleArray(nx, Layers[j].Height(Length, (double[])_xs.Clone()).ToArray(), AdditionalMath.Operation.Plus);
            }
        }
        return nx;
    }
}