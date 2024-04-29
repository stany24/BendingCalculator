// ReSharper disable ValueParameterNotUsed

using Avalonia.Media;

namespace BendingCalculator.Logic.Math;

public class Material : Element
{
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
            Display = ToString();
        }
    }

    private Color _color;
    public Color Color
    {
        get => _color;
        set
        {
            _color = value;
            Display = ToString();
        }
    }

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