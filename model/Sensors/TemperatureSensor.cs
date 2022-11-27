using System;

namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class TemperatureSensor
    {
        public double Temperature { get; set; }
        public TemperatureSensor() {}
        public TemperatureSensor(double _temperature)
        {
            Temperature = _temperature;
        }
        
        public double ProvideData() => Temperature;
    }
}