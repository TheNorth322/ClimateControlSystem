using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class Conditioner : ClimateControlSystemDevice, IConditioner
    {
        public Conditioner()
        {
        }

        // Contructors
        public Conditioner(bool _isOn, double _airFlow, ConditionerMode _conditionerMode, double _workingTemperature)
            : base(_isOn)
        {
            AirFlow = _airFlow;
            ConditionerMode = _conditionerMode;
            WorkingTemperature = _workingTemperature;
        }

        // Properties
        public double AirFlow { get; set; }

        public ConditionerMode ConditionerMode { get; set; }
        
        public double WorkingTemperature { get; set; }

        public void TurnOnHeatingMode()
        {
            ConditionerMode = ConditionerMode.Heating;
        }

        public void TurnOnCoolingMode()
        {
            ConditionerMode = ConditionerMode.Cooling;
        }
        
        public double ProvideHeat()
        {
            return (IsOn) ? WorkingTemperature * AirFlow : 0;
        }
    }
}