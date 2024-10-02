using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.Logic.Math;

public partial class Element : ObservableObject
{
    [ObservableProperty] private string _display = string.Empty;
    public long Id { get; set; } = -1;

    protected void UpdateDisplay()
    {
        Display = ToString() ?? string.Empty;
    }

    protected void UpdateDisplay(object? sender, EventArgs e)
    {
        Display = ToString() ?? string.Empty;
    }
}