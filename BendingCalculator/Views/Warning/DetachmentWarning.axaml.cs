using Avalonia.Controls;
using BendingCalculator.ViewModels;

namespace BendingCalculator.Views.Warning;

public partial class DetachmentWarning : Window
{
    public DetachmentWarning(WarningViewModel model)
    {
        DataContext = model;
        InitializeComponent();
    }
}