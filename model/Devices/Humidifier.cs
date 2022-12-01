using System;
namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class Humidifier : ClimateControlSystemDevice
    {
        // Properties
        public double ExpectedHumidityLevel { get; set; }
        
        public double WaterConsumption { get; set; }
        
        public Humidifier() {}
        // Constructors
        public Humidifier(bool _isOn, double _waterConsumption, double _expectedHumidityLevel)
            : base(_isOn)
        {
            WaterConsumption = _waterConsumption;
            ExpectedHumidityLevel = _expectedHumidityLevel;
        }

        // Methods
        // return waterConsumption per minute in Room humidity is going to be recalculated 
        
    }
}
