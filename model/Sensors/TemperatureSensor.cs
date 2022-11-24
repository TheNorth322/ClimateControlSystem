using System;

namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class TemperatureSensor : ISensor
    {
        public double Temperature { get; set; }

        public TemperatureSensor(double _temperature)
        {
            Temperature = _temperature;
        }
        
        public double ProvideData() => Temperature;
    }
}