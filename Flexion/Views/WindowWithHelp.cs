using System.Collections.Generic;
using Avalonia.Controls;
using Flexion.Logic.Helper;
using Flexion.ViewModels;

namespace Flexion.Views;

public class WindowWithHelp:Window
{
    private HelperWindow? _helperWindow;

    protected WindowWithHelp()
    {
        Closing += (_,_) => _helperWindow?.Close();
    }
    
    internal void OpenHelpWindow(List<IHelperModule> modules)
    {
        if (_helperWindow != null) return;
        if(DataContext is not MainViewModel model){return;}
        _helperWindow = new HelperWindow(modules,model);
        _helperWindow.Show();
        _helperWindow.Closed += (_,_) => _helperWindow = null;
    }
}