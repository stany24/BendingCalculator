using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace Flexion.Logic;

public static class ApplicationRestarter
{
    public static void Restart()
    {
        if (Application.Current?.ApplicationLifetime is not IControlledApplicationLifetime lifetime) return;
        // Close the current instance of the application
        lifetime.Shutdown();

        // Start a new instance of the application
        StartNewInstance();
    }

    private static void StartNewInstance()
    {
        // Start a new process with the same executable
        if (Environment.ProcessPath != null) Process.Start(Environment.ProcessPath);
    }
}