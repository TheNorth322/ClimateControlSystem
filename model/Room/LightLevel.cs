using System.ComponentModel;

namespace ClimateControlSystemNamespace
{
    public enum LightLevel
    {
        [Description("Low Illumination")] LowIllumination = 30,
        [Description("Average Illumination")] AverageIllumination = 35,
        [Description("High Illumination")] HighIllumination = 40
    };

}