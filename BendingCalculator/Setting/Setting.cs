using System.Text.Json.Serialization;

namespace BendingCalculator.Setting;

public class Setting
{
    [JsonInclude]
    public string Language { get; set; }

    public bool WarningDisabled { get; set; }

    [JsonConstructor]
    public Setting()
    {
    }

    public Setting(string language,bool warningDisabled)
    {
        Language = language;
        WarningDisabled = warningDisabled;
    }
}