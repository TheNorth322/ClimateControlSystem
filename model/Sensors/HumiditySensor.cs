using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class HumiditySensor
    {
        public HumiditySensor()
        {
        }

        public HumiditySensor(double _humidity, double _expectedHumidity)
        {
            Humidity = _humidity;
            ExpectedHumidity = _expectedHumidity;
        }

        public double Humidity { get; set; }
        public double ExpectedHumidity { get; set; }

        public double ProvideData()
        {
            return Humidity;
        }
    }
}