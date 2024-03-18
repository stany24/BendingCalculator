using System;

namespace BendingCalculator.Logic.Math;

public class ConstraintEventArgs:EventArgs
{
    public double[] MaxConstraint { get; init; }
    
    public ConstraintEventArgs(double[] maxConstraint)
    {
        MaxConstraint = maxConstraint;
    }
}