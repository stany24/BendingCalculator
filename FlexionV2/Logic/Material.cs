using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace FlexionV2.Logic;

public class Material:ObservableObject
{
    public long MaterialId { get; set; }
        
    private string _name;

    [JsonInclude]
    public string Name
    {
        get => _name;
        set {
            if (value != "")
            {
                SetProperty(ref _name, value);
            }}
    }

    private long _e;
    [JsonInclude]
    public long E
    {
        get => _e;
        set {
            if (value > 0)
            {
                SetProperty(ref _e, value);
            } }
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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}