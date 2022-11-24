using System.ComponentModel;

namespace ClimateControlSystemNamespace
{
    public enum ConditionerMode 
    {
        [Description("Cooling")]
        Cooling,
        [Description("Heating")]
        Heating 
    };
}