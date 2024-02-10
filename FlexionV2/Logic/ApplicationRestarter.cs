using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace FlexionV2.Logic;

public static class ApplicationRestarter
{
    public static void Restart()
    {
        IControlledApplicationLifetime? lifetime = Application.Current.ApplicationLifetime as IControlledApplicationLifetime;
        if (lifetime == null) return;
        // Close the current instance of the application
        lifetime.Shutdown();

        // Start a new instance of the application
        StartNewInstance();
    }

    private static void StartNewInstance()
    {
        // Get the path to the current executable
        string executablePath = Process.GetCurrentProcess().MainModule.FileName;

        // Start a new process with the same executable
        Process.Start(executablePath);

        // Note: Depending on your application's requirements, you might want to pass some arguments 
        // or handle some cleanup tasks before starting the new instance.
    }
}