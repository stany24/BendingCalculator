using System.Collections.Generic;
using System.Collections.ObjectModel;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.ViewModels;

public class WarningViewModel
{
    public ObservableCollection<KeyValuePair<int, Layer>> WarningDetachmentOfLayers { get; set; }

    public WarningViewModel(ObservableCollection<KeyValuePair<int, Layer>> layers)
    {
        WarningDetachmentOfLayers = layers;
    }
}