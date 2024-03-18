using System.Collections.Generic;
using System.Collections.ObjectModel;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.ViewModels;

public partial class MainViewModel
{
    private ObservableCollection<KeyValuePair<int, Layer>> _warningSlideLayers = new();
    public ObservableCollection<KeyValuePair<int, Layer>> WarningSlideLayers { 
        get => _warningSlideLayers;
        set => SetProperty(ref _warningSlideLayers, value);
    }
}