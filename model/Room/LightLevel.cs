using System.ComponentModel;

namespace ClimateControlSystemNamespace
{
    public enum LightLevel
    {
        [Description("Low Illumination")] LowIllumination = 1,
        [Description("Average Illumination")] AverageIllumination = 2,
        [Description("High Illumination")] HighIllumination = 3
    }
}