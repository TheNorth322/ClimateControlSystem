using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class Humidifier : ClimateControlSystemDevice
    {
        public Humidifier()
        {
        }

        // Constructors
        public Humidifier(bool _isOn, double _waterConsumption)
            : base(_isOn)
        {
            WaterConsumption = _waterConsumption;
        }

        // Properties
        public double WaterConsumption { get; set; }

        // Methods
        // return waterConsumption per minute in Room humidity is going to be recalculated 
    }
}