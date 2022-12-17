using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class HumiditySensor
    {
        public HumiditySensor()
        {
        }

        public HumiditySensor(double _humidity)
        {
            Humidity = _humidity;
        }

        public double Humidity { get; set; }

        public double ProvideData()
        {
            return Humidity;
        }
    }
}