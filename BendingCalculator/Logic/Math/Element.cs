using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.Logic.Math;

public abstract partial class Element: ObservableObject
{
    [ObservableProperty] private long _id = -1;
    [ObservableProperty] private string _display = string.Empty;
    
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            if (value == string.Empty) return;
            _name = value;
            Display = ToString() ?? string.Empty;
        }
    }
}