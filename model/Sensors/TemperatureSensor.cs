using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class TemperatureSensor
    {
        public TemperatureSensor()
        {
        }

        public TemperatureSensor(double _temperature)
        {
            Temperature = _temperature;
        }

        public double Temperature { get; set; }

        public double ProvideData()
        {
            return Temperature;
        }
    }
}