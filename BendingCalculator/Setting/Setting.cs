using System.Text.Json.Serialization;

namespace BendingCalculator.Setting;

public class Setting
{
    [JsonConstructor]
    public Setting()
    {
        Language = string.Empty;
    }

    public Setting(string language, bool warningDisabled)
    {
        Language = language;
        WarningDisabled = warningDisabled;
    }

    [JsonInclude] public string Language { get; set; }

    [JsonInclude] public bool WarningDisabled { get; init; }
}