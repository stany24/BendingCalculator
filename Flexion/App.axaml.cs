using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Flexion.Database.Actions;
using Flexion.ViewModels;
using Flexion.Views;

namespace Flexion;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Main(new MainViewModel(DataBaseInitializer.InitializeDatabaseConnection() ?? throw new InvalidOperationException()));
        }

        base.OnFrameworkInitializationCompleted();
    }
}