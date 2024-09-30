using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BendingCalculator.Logic.Math;

public partial class Element: ObservableObject
{
    public long Id { get; set; } = -1;
    [ObservableProperty] private string _display = string.Empty;

    protected void UpdateDisplay()
    {
        Display = ToString() ?? string.Empty;
    }

    protected void UpdateDisplay(object? sender,EventArgs e)
    {
        Display = ToString() ?? string.Empty;
    }
}