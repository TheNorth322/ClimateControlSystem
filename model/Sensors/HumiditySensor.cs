using System;

namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class HumiditySensor : ISensor
    {
        public double Humidity { get; set; }

        public HumiditySensor(double _humidity)
        {
            Humidity = _humidity;
        }
        
        public double ProvideData() => Humidity;
    }
}