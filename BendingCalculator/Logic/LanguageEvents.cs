using System;

namespace BendingCalculator.Logic;

public static class LanguageEvents
{
    public static event EventHandler<EventArgs>? LanguageChanged;

    public static void RaiseLanguageChanged()
    {
        LanguageChanged?.Invoke(null, EventArgs.Empty);
    }
}