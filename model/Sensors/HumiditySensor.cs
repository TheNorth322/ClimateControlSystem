using System;

namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class HumiditySensor
    {
        public double Humidity { get; set; }
        public HumiditySensor() {}
        public HumiditySensor(double _humidity)
        {
            Humidity = _humidity;
        }
        
        public double ProvideData() => Humidity;
    }
}