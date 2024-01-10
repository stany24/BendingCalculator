using System;
using System.Data.SQLite;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FlexionV2.Database.Actions;
using FlexionV2.ViewModels;
using FlexionV2.Views;
using Path = Avalonia.Controls.Shapes.Path;

namespace FlexionV2;

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
            desktop.MainWindow = new Main(new MainViewModel(DataBaseInitializer.InitializeDatabaseConnection()));
        }

        base.OnFrameworkInitializationCompleted();
    }
}