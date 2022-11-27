using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class Room
    {
        // Properties
        public string Name { get; set; }
        public double Area { get; set;  }
        public double CeilingHeight { get; set; }
        public HumiditySensor HumiditySensor { get; set; }
        public TemperatureSensor TemperatureSensor { get; set; }
        public CarbonDioxideSensor CarbonDioxideSensor { get; set; }
        
        /*Setters may be unnecessary, the idea behind this is that
         Devices can become broken and they will need to be replaced
         LightLevel can change from time to time e.g. 
         10:00-12:00 AverageIllumination
         12:00-17:00 HighIllumination
         17:00-10:00 LowIllumination*/
        public LightLevel LightLevel { get; set; }
        public Conditioner Conditioner { get; set; }
        public Humidifier Humidifier { get; set; }
        public Purificator Purificator { get; set; }

        // Contructors
        public Room()
        {
        }

        public Room(string _name, double _area,
            double _ceilingHeight, LightLevel _lightLevel,
            Conditioner _conditioner, Humidifier _humidifier, Purificator _purificator,
            TemperatureSensor _temperatureSensor, HumiditySensor _humiditySensor,
            CarbonDioxideSensor _carbonDioxideSensor)
        {
            Name = _name;
            Area = _area;
            CeilingHeight = _ceilingHeight;
            LightLevel = _lightLevel;
            Conditioner = _conditioner;
            Humidifier = _humidifier;
            Purificator = _purificator;
            TemperatureSensor = _temperatureSensor;
            HumiditySensor = _humiditySensor;
            CarbonDioxideSensor = _carbonDioxideSensor;
        }
    }
}