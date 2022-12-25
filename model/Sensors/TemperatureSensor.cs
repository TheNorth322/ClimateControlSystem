using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class TemperatureSensor
    {
        public TemperatureSensor()
        {
        }

        public TemperatureSensor(double _temperature, double _expectedTemperature)
        {
            Temperature = _temperature;
            ExpectedTemperature = _expectedTemperature;
        }

        public double Temperature { get; set; }
        public double ExpectedTemperature { get; set; }

        public double ProvideData()
        {
            return Temperature;
        }
    }
}