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
        for (double i = 0; i <= Length; i += gap)
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
    
    private IEnumerable<double> MomentForce(double force)
    {
        double[] moments = new double[_xs.Length];
        double offset = -force / 2 * _xs[_xs.Length / 2] - force / 2 * _xs[_xs.Length / 2];

        for (int i = 0; i < _xs.Length; i++)
        {
            if (_xs[i] < Length/2)
            {
                moments[i] = -force / 2 * _xs[i];
            }
            else
            {
                moments[i] = force / 2 * _xs[i] + offset;
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
        IEnumerable<double> moment = MomentForce(force);
        IEnumerable<double> I = CalculateI();
        double[] function = moment.Zip(I, (x, y) => x / y).ToArray();
        FirstIntegral(function,ref integral1,gap);
        SecondIntegral(integral1, ref integral2,gap);
        return integral2;
    }
    
    private static void FirstIntegral(IReadOnlyList<double> function,ref double[] integral1, double gap)
    {
        integral1[0] = function[0] * gap;
        for (int i = 1; i < function.Count; i++)
        {
            integral1[i] = integral1[i - 1] + function[i] * gap;
        }
        double constant = integral1[integral1.Length / 2];
        integral1 = Array.ConvertAll(integral1, x => x-constant);
    }

    private static void SecondIntegral(IReadOnlyList<double> integral1,ref double[] integral2, double gap)
    {
        integral2[0] = integral1[0] * gap;
        for (int i = 1; i < integral2.Length; i++)
        {
            integral2[i] = integral2[i - 1] + integral1[i] * gap;
        }
        integral2 = Array.ConvertAll(integral2, x => x / -ERef);
    }

    private IEnumerable<double> CalculateI()
    {
        double[][] ix = new double[Layers.Count][];
        double[] I = new double[_xs.Length];
        //calculate the Ix in a generalized way.
        for (int i = 0; i < Layers.Count; i++)
        {
            double[] heights = Layers[i].Height(Length,_xs);
            double[] power = Array.ConvertAll(heights, x => x * x * x );
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

    private IEnumerable<double> Ns()
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
            if (j == i) { heights = Array.ConvertAll(heights, x => x / 2); }
            nx = nx.Zip(heights, (x, y) => x + y).ToArray();
        }
        return nx;
    }

    #endregion
}