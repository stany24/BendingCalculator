using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.Logic.Math;

public abstract class Element: ObservableObject
{
    internal EventHandler? ElementChanged { get; set; }
    public long Id { get; set; } = -1;
    public string Display { get; set; } = string.Empty;
    
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            if (value == string.Empty) return;
            _name = value;
            UpdateDisplay();
        }
    }

    protected void UpdateDisplay()
    {
        Display = ToString() ?? string.Empty;
        ElementChanged?.Invoke(this, EventArgs.Empty);
    }

    protected void UpdateDisplay(object? sender,EventArgs e)
    {
        Display = ToString() ?? string.Empty;
        ElementChanged?.Invoke(this, EventArgs.Empty);
    }
}