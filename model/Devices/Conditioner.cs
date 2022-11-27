using System;
using System.ComponentModel;

namespace ClimateControlSystemNamespace
{
    

    [Serializable]
    public class Conditioner : ClimateControlSystemDevice
    {
        // Properties
        public bool IsOn { get; set; }
        
        public double AirFlow { get; }
        
        public ConditionerMode ConditionerMode { get; set; }

        public double WorkingTemperature { get; set; }
        
        public Conditioner() {}
        
        // Contructors
        public Conditioner(bool _isOn, double _airFlow, ConditionerMode _conditionerMode, double _workingTemperature)
            : base(_isOn) 
        { 
            AirFlow = _airFlow;
            ConditionerMode = _conditionerMode;
            WorkingTemperature = _workingTemperature;
        }
    }
}
