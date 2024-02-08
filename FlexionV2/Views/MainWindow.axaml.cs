using Avalonia.Controls;
using FlexionV2.ViewModels;

namespace FlexionV2.Views;

public partial class Main : Window
{
    public Main(MainViewModel model)
    {
        DataContext = model;
        InitializeComponent();
        Closing += (_, _) => CloseAllWindows();
    }

    private void CloseAllWindows()
    {
        if(DataContext is not MainViewModel model){return;}
        model.CloseAllWindow();
    }
}