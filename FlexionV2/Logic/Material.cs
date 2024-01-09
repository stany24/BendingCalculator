using System.Text.Json.Serialization;

namespace FlexionV2.Logic;

public class Material
{
    public long MaterialId { get; set; }
        
    private string _name;

    [JsonInclude]
    public string Name
    {
        get => _name;
        set {if (value != "") { _name = value; }}
    }

    private long _e;
    [JsonInclude]
    public long E
    {
        get => _e;
        set { if (value > 0) { _e = value; } }
    }
        
    public Material(string name, long e)
    {
        Name = name;
        E = e;
    }

    [JsonConstructor]
    public Material() { }
        
    public override string ToString()
    {
        return E > 1e9 - 1 ? $"{Name}:{E / 1e9} GPa" : $"{Name}:{E / 1e6} MPa";
    }
}