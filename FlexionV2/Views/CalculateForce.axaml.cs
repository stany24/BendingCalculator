using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FlexionV2.Views;

public partial class CalculateForce : Window
{
    public CalculateForce()
    {
        InitializeComponent();
        NudMasse.ValueChanged += ModifyForce;
        NudRayon.ValueChanged += ModifyForce;
        NudSpeed.ValueChanged += ModifyForce;
        NudGravity.ValueChanged += ModifyForce;
    }

    private void ModifyForce(object? sender, NumericUpDownValueChangedEventArgs numericUpDownValueChangedEventArgs)
    {
        double m = (double)NudMasse.Value;
        double r = (double)NudRayon.Value;
        double v = (double)NudSpeed.Value;
        double g = (double)NudGravity.Value;
        NudForce.Value = Convert.ToInt32(m * Math.Sqrt(Math.Pow(g, 2) + (Math.Pow(v, 4) / Math.Pow(r, 2))));
    }
}