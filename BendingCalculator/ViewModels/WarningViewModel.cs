using System.Collections.Generic;
using System.Collections.ObjectModel;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<KeyValuePair<int, Layer>> _warningDetachmentOfLayers = new();
    public ObservableCollection<KeyValuePair<int, Layer>> WarningDetachmentOfLayers { 
        get => _warningDetachmentOfLayers;
        set => SetProperty(ref _warningDetachmentOfLayers, value);
    }
}