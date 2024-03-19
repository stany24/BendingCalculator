using System;

namespace BendingCalculator.Logic.Math;

public class BendingResult
{
    public double[] I { get; set; } = Array.Empty<double>();
    public double[] Moment { get; set; } = Array.Empty<double>();
    public double[] Integral1  { get; set; } = Array.Empty<double>();
    public double[] Integral2  { get; set; } = Array.Empty<double>();
    public double[] Constraint { get; set; } = Array.Empty<double>();
    public double[] Ns { get; set; } = Array.Empty<double>();
}