using Avalonia.Controls;
using BendingCalculator.Logic.Math;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Warning;

public partial class SlideWarning : Window
{
    public SlideWarning(MainViewModel model,RiskOfSlidingLayersEventArgs e)
    {
        DataContext = model;
        InitializeComponent();
        TbxLayer1.Text = e.Layer1.ToString();
        TbxLayer2.Text = e.Layer2.ToString();
        TbxPos1.Text = e.Position1.ToString();
        TbxPos2.Text = e.Position2.ToString();
    }
}