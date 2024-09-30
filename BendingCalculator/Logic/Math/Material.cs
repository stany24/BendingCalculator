// ReSharper disable ValueParameterNotUsed

using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.Logic.Math;

public partial class Material : Element
{
    
    [ObservableProperty]private string _name = string.Empty;
    public override string ToString()
    {
        return E > 1e9 - 1 ? $"{Name}:{E / 1e9} GPa" : $"{Name}:{E / 1e6} MPa";
    }

    #region Variables

    private long _e;

    public long E
    {
        get => _e;
        set
        {
            if (value <= 0) return;
            _e = value;
            UpdateDisplay();
        }
    }

    [ObservableProperty] private Color _color;

    #endregion

    #region Constructor

    public Material(string name, long e)
    {
        Name = name;
        _e = e;
    }

    public Material()
    {
        Name = "new";
    }

    #endregion
}