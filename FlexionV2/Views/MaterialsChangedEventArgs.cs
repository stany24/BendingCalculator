using System;
using System.Collections.Generic;
using FlexionV2.Logic;

namespace FlexionV2.Views;

public class MaterialsChangedEventArgs:EventArgs
{
    public List<Material> Materials;

    public MaterialsChangedEventArgs(List<Material> materials)
    {
        Materials = materials;
    }
}