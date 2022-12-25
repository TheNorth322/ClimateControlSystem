using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class Humidifier : ClimateControlSystemDevice, IHumidifier
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

        public double ProvideHumidity()
        {
            return IsOn ? WaterConsumption : 0;
        }
    }
}