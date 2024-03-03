using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;

// ReSharper disable ValueParameterNotUsed

namespace Flexion.Logic.Math;

public class Material:ObservableObject
{
    #region Variables

    public long MaterialId { get; set; }
        
    private string _name;

    [JsonInclude]
    public string Name
    {
        get => _name;
        set
        {
            if (value == "") return;
            _name= value;
            Display = ToString();
        }
    }

    private long _e;
    [JsonInclude]
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
    
    private string? _display;
    public string Display
    {
        get => _display ?? ToString();
        set => SetProperty(ref _display, ToString());
    }

    #endregion

    #region Constructor

    public Material(string name, long e)
    {
        _name = name;
        _e = e;
    }

    [JsonConstructor]
    public Material() { }

    #endregion
        
    public override string ToString()
    {
        return E > 1e9 - 1 ? $"{Name}:{E / 1e9} GPa" : $"{Name}:{E / 1e6} MPa";
    }
}