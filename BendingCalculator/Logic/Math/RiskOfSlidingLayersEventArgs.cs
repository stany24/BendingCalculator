using System;

namespace BendingCalculator.Logic.Math;

public class RiskOfSlidingLayersEventArgs:EventArgs
{
    public int Position1 { get; }
    public int Position2 { get; }
    public Layer Layer1 { get; }
    public Layer Layer2 { get; }
    
    public RiskOfSlidingLayersEventArgs(int position1, int position2, Layer layer1, Layer layer2)
    {
        Position1 = position1;
        Position2 = position2;
        Layer1 = layer1;
        Layer2 = layer2;
    }
}