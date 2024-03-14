using System;
using BendingCalculator.Logic.Helper;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Editors.Force;

public partial class ForceEditor : WindowWithHelp
{
    public ForceEditor(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        NudGravity.ValueChanged += (_, _) => CalculateForce();
        NudSpeed.ValueChanged += (_, _) => CalculateForce();
        NudMass.ValueChanged += (_, _) => CalculateForce();
        NudRadius.ValueChanged += (_, _) => CalculateForce();
        CalculateForce();
        HelpButton.Click += (_,_) => OpenHelpWindow(HelperInfo.ForceWindowModules);
    }

    public decimal CalculateForce()
    {
        if (NudMass.Value is not { } mass) { return 0; }
        if (NudRadius.Value is not { } radius) { return 0; }
        if (NudSpeed.Value is not { } speed) { return 0; }
        if (NudGravity.Value is not { } gravity) { return 0; }
        decimal value = Convert.ToInt32((double)mass * Math.Sqrt(Math.Pow((double)gravity, 2) + Math.Pow((double)speed, 4) / Math.Pow((double)radius, 2)));
        NudForce.Value = value;
        return value;
    }
}