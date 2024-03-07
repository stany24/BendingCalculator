using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

// ReSharper disable ValueParameterNotUsed

namespace Flexion.Logic.Math;

public class Piece:ObservableObject
{
    #region Variables

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

    private const double ERef = 69e9;

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

    #endregion

    #region Constructor / Destructor

    public Piece(double length, string name)
    {
        Layers = new List<Layer>();
        _length = length;
        _name = name;
        LanguageEvents.LanguageChanged += UpdateDisplay;
    }

    [JsonConstructor]
    public Piece()
    {
        LanguageEvents.LanguageChanged += UpdateDisplay;
    }
    
    ~Piece()
    {
        LanguageEvents.LanguageChanged -= UpdateDisplay;
    }

    #endregion

    #region Display

    private void UpdateDisplay(object? sender, EventArgs e)
    {
        Display = ToString();
    }
    
    public override string ToString()
    {
        return Layers.Count switch
        {
            0 => $"{Name} / {Length*1000}mm",
            _ => $"{Name} / {Length*1000}mm / {Layers.Count} {Assets.Localization.Logic.LogicLocalization.Layers}"
        };
    }

    #endregion

    #region Math

    /// <summary>
    /// Function used to calculate the torque
    /// </summary>
    /// <param name="force">The force applied to the piece</param>
    /// <returns></returns>
    private double[] MomentForce(double force)
    {
        double b1 = Length / 2;
        double[] xs = _xs;
        double[] moments = new double[_xs.Length];

        double[] mfa1 = Array.ConvertAll(_xs, x => x * (-force * b1));
        mfa1 = Array.ConvertAll(mfa1, x => x / Length);

        double[] mfb1 = Array.ConvertAll(_xs, x => x - Length - b1);
        mfb1 = Array.ConvertAll(mfb1, x => x * force);
        mfb1 = mfb1.Zip(mfa1, (x, y) => x + y).ToArray();

        for (int i = 0; i < _xs.Length; i++)
        {
            if (xs[i] < b1)
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
        // first integral
        for (int i = 0; i < moment.Length; i++)
        {
            integral1[i] = moment[i] / I[i];
        }
        // second integral
        SecondIntegral(ref integral1,ref integral2,ref moment,gap);
        // third integral
        ThirdIntegral(ref integral2, ref integral3,gap);
        
        return integral3;
    }

    private static void SecondIntegral(ref double[] integral1,ref double[] integral2,ref double[] moment, double gap)
    {
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
    }

    private static void ThirdIntegral(ref double[] integral2,ref double[] integral3, double gap)
    {
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
            double[] heights = Layers[i].Height(Length,_xs);
            double[] power = Array.ConvertAll(heights, x => x * x * x);
            IEnumerable<double> bases = Layers[i].Base(Length, ERef, _xs);
            double[] divider = power.Zip(bases, (x, y) => x * y).ToArray();
            ix[i] = Array.ConvertAll(divider, x => x / 12);
        }

        for (int i = 0; i < Layers.Count; i++)
        {
            double[] p1 = CalculateNx(i, _xs.Length).Zip(Ns(), (x, y) => x - y).ToArray();
            double[] p2 = Array.ConvertAll(p1, x => x * x);
            IEnumerable<double> surfaces = Layers[i].Surface(Length, ERef, _xs);
            double[] p3 = surfaces.Zip(p2, (x, y) => x * y).ToArray();
            double[] p4 = ix[i].Zip(p3, (x, y) => x + y).ToArray();
            I = I.Zip(p4, (x, y) => x + y).ToArray();
        }
        return I;
    }

    private IEnumerable<double> Ns()
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
        divided = MultiplyAndAggregate(divided, Layers, nx);

        // calculation of dividing
        divider = Layers.Aggregate(divider, CombineSurfaces);
        
        //calculation of Ns
        return divided.Zip(divider, (x, y) => x / y).ToArray();
    }
    
    private double[] CombineSurfaces(double[] currentDivider, Layer layer)
    {
        IEnumerable<double> surface = layer.Surface(Length, ERef, _xs);
        return currentDivider.Zip(surface,(x,y)=>x+y).ToArray();
    }

    private double[] MultiplyAndAggregate(double[] divided, IEnumerable<Layer> layers, IReadOnlyList<double[]> nx)
    {
        return layers
            .Select((layer, i) =>
                layer.Surface(Length, ERef, _xs).Zip(nx[i], (x, y) => x * y))
            .Aggregate(divided, (current, added) =>
                current.Zip(added, (x, y) => x + y).ToArray());
    }

    private double[] CalculateNx(int i, int length)
    {
        double[] nx = new double[length];
        for (int j = 0; j <= i; j++)
        {
            if (j == i)
            {
                double[] heights = Layers[j].Height(Length, _xs);
                double[] add = Array.ConvertAll(heights, x => x / 2);
                nx = nx.Zip(add, (x, y) => x + y).ToArray();
            }
            else
            {
                double[] heights = Layers[j].Height(Length,_xs);
                nx = nx.Zip(heights,(x,y)=>x+y).ToArray();
            }
        }
        return nx;
    }

    #endregion
}