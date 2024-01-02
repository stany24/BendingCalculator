using System;
using System.Collections.Generic;
using FlexionV2.Logic;

namespace FlexionV2.Views;

public class LayersChangedEventArgs:EventArgs
{
    public List<Layer> Layers;

    public LayersChangedEventArgs(List<Layer> layers)
    {
        Layers = layers;
    }
}