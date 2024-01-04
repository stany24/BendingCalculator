using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FlexionV2.Logic;

public class Piece
{
    [JsonInclude]
    public List<Layer> Layers { get; set; }

    private string _name;
    [JsonInclude]
    public string Name
    {
        get => _name;
        set{if (value != "") { _name = value; }}
    }

    private double _length;
    [JsonInclude]
    public double Length
    {
        get => _length;
        set {if (value > 0) { _length = value; }}
    }

    private double _eref;
    [JsonInclude]
    public double Eref
    {
        get => _eref;
        set { if (value > 0) { _eref = value; }}
    }
        
    private double[] Xs;

    private double[] SetX(double gap)
    {
        List<double> X = new List<double>();
        for (double i = 0; i <= Length + gap; i += gap)
        {
            X.Add(i);
        }
        return X.ToArray();
    }

    /// <summary>
    /// Instancie une pièce avec une longueur et un nom
    /// </summary>
    /// <param name="length">Longueur de la pièce</param>
    /// <param name="name">Nom de la pièce</param>
    public Piece(double length, string name)
    {
        Eref = 69e9;
        Layers = new List<Layer>();
        Length = length;
        Name = name;
    }

    public Piece(double length, string name, double eref)
    {
        Layers = new List<Layer>();
        Length = length;
        Name = name;
        Eref = eref;
    }

    [JsonConstructor]
    public Piece() { }

    /// <summary>
    /// Retourne le nom et la longueur de la pièce
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Layers.Count switch
        {
            0 => $"{Name} / {Length}m",
            1 => $"{Name} / {Length}m / 1 couche",
            _ => $"{Name} / {Length}m / {Layers.Count} couches"
        };
    }

    private double[] MomentForce(double force)
    {
        double b1 = Length / 2;
        double[] x = Xs;
        double[] moments = new double[Xs.Length];

        double[] Mfa1 = AdditionalMath.OperationDoubleArray((double[])Xs.Clone(), -force * b1, AdditionalMath.Operation.Multiplication);
        Mfa1 = AdditionalMath.OperationDoubleArray(Mfa1, Length, AdditionalMath.Operation.Divided);

        double[] Mfb1 = AdditionalMath.OperationDoubleArray((double[])Xs.Clone(), Length - b1, AdditionalMath.Operation.Minus);
        Mfb1 = AdditionalMath.OperationDoubleArray(Mfb1, force, AdditionalMath.Operation.Multiplication);
        Mfb1 = AdditionalMath.OperationDoubleArray(Mfa1, Mfb1, AdditionalMath.Operation.Plus);

        for (int i = 0; i < Xs.Length; i++)
        {
            if (x[i] < b1)
            {
                moments[i] = Mfa1[i];
            }
            else
            {
                moments[i] = Mfb1[i];
            }
        }
        return moments;
    }

    public double[] Intégrale(double force, double gap)
    {
        Xs = SetX(gap);
        double[] integrale1 = new double[Xs.Length];
        double[] integrale2 = new double[Xs.Length];
        double[] integrale3 = new double[Xs.Length];
        double[] moment = MomentForce(force);
        double[] I = CalculateI();
        // calcule
        for (int i = 0; i < moment.Length; i++)
        {
            integrale1[i] = moment[i] / I[i];
        }
        // première intégrale
        for (int i = 0; i < moment.Length; i++)
        {
            if (i - 1 < 0)
            {
                integrale2[i] = integrale1[i] * gap;
            }
            else
            {
                integrale2[i] = integrale2[i - 1] + integrale1[i] * gap;
            }
        }

        double offset = integrale2[Convert.ToInt32(integrale2.Length / 2)];
        for (int i = 0; i < integrale2.Length; i++)
        {
            integrale2[i] -= offset;
        }

        // deuxième intégrale
        for (int i = 0; i < integrale3.Length; i++)
        {
            if (i - 1 < 0)
            {
                integrale3[i] = integrale2[i] * gap;
            }
            else
            {
                integrale3[i] = integrale3[i - 1] + integrale2[i] * gap;
            }
        }
        for (int i = 0; i < integrale3.Length; i++)
        {
            integrale3[i] /= -Eref;
        }
        return integrale3;
    }

    private double[] CalculateI()
    {
        double[][] ix = new double[Layers.Count][];
        double[] I = new double[Xs.Length];

        //initialise les arrays
        for (int i = 0; i < ix.Length; i++)
        {
            ix[i] = new double[Xs.Length];
        }

        //calcule les Ix de manière généralisé.
        for (int i = 0; i < Layers.Count; i++)
        {
            double[] power = AdditionalMath.OperationDoubleArray(Layers[i].Height(Length, (double[])Xs.Clone()).ToArray(), 3, AdditionalMath.Operation.Power);
            double[] divise = AdditionalMath.OperationDoubleArray(power, Layers[i].Base(Length, Eref, (double[])Xs.Clone()), AdditionalMath.Operation.Multiplication);
            ix[i] = AdditionalMath.OperationDoubleArray(divise, 12, AdditionalMath.Operation.Divided);
        }

        for (int i = 0; i < Layers.Count; i++)
        {
            double[] p1 = AdditionalMath.OperationDoubleArray(CalculateNx(i, Xs.Length), Ns(), AdditionalMath.Operation.Minus);
            double[] p2 = AdditionalMath.OperationDoubleArray(p1, 2, AdditionalMath.Operation.Power);
            double[] p3 = AdditionalMath.OperationDoubleArray(Layers[i].Surface(Length, Eref, (double[])Xs.Clone()).ToArray(), p2, AdditionalMath.Operation.Multiplication);
            double[] p4 = AdditionalMath.OperationDoubleArray(ix[i], p3, AdditionalMath.Operation.Plus);
            I = AdditionalMath.OperationDoubleArray(I, p4, AdditionalMath.Operation.Plus);
        }
        return I;
    }

    private double[] Ns()
    {
        double[][] nx = new double[Layers.Count][];
        double[] divise = new double[Xs.Length];
        double[] divisant = new double[Xs.Length];

        //initialise les arrays
        for (int i = 0; i < nx.Length; i++)
        {
            nx[i] = new double[Xs.Length];
        }

        //calcule les Nx de manière généralisé.
        for (int i = 0; i < Layers.Count; i++)
        {
            nx[i] = CalculateNx(i, Xs.Length);
        }

        //calucule du divisé
        divise = Layers.Select((t, i) => AdditionalMath.OperationDoubleArray(t.Surface(Length, Eref, (double[])Xs.Clone()).ToArray(), nx[i], AdditionalMath.Operation.Multiplication)).Aggregate(divise, (current, ajout) => AdditionalMath.OperationDoubleArray(current, ajout, AdditionalMath.Operation.Plus));

        // calcule du divisant
        divisant = Layers.Aggregate(divisant, (current, t) => AdditionalMath.OperationDoubleArray(current, t.Surface(Length, Eref, (double[])Xs.Clone()).ToArray(), AdditionalMath.Operation.Plus));
        //calcule de Ns
        return AdditionalMath.OperationDoubleArray(divise, divisant, AdditionalMath.Operation.Divided);
    }

    private double[] CalculateNx(int i, int length)
    {
        double[] nx = new double[length];
        for (int j = 0; j <= i; j++)
        {
            if (j == i)
            {
                double[] add = AdditionalMath.OperationDoubleArray(Layers[j].Height(Length, (double[])Xs.Clone()).ToArray(), 2, AdditionalMath.Operation.Divided);
                nx = AdditionalMath.OperationDoubleArray(nx, add, AdditionalMath.Operation.Plus);
            }
            else
            {
                nx = AdditionalMath.OperationDoubleArray(nx, Layers[j].Height(Length, (double[])Xs.Clone()).ToArray(), AdditionalMath.Operation.Plus);
            }
        }
        return nx;
    }
}