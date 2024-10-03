// ReSharper disable ValueParameterNotUsed

using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.Logic.Math;

public partial class Material : Element
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private Unit _unit;
    [ObservableProperty] private long _e;

    public override string ToString()
    {
        return $"{Name}:{E} {Unit}";
    }

    #region Variables

    [ObservableProperty] private Color _color;

    #endregion

    #region Constructor

    public Material(string name, long e)
    {
        Name = name;
        _e = e;
        Color = Colors.White;
        Unit = Unit.GPa;
    }

    public Material()
    {
        Name = "new";
        Color = Colors.White;
        Unit = Unit.GPa;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is Material other)
        {
            return Id == other.Id;
        }
        return false;
    }

    #endregion
}