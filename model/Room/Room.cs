using System;
using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class Room
    {
        // Contructors
        public Room()
        {
            Conditioners = new List<Conditioner>();
            Humidifiers = new List<Humidifier>();
            Purificators = new List<Purificator>();
            TemperatureSensor = new TemperatureSensor();
            HumiditySensor = new HumiditySensor();
            CarbonDioxideSensor = new CarbonDioxideSensor();
        }

        public Room(string _name, double _area,
            double _ceilingHeight, LightLevel _lightLevel,
            List<Conditioner> _conditioners, List<Humidifier> _humidifiers, List<Purificator> _purificators,
            TemperatureSensor _temperatureSensor, HumiditySensor _humiditySensor,
            CarbonDioxideSensor _carbonDioxideSensor)
        {
            Name = _name;
            Area = _area;
            CeilingHeight = _ceilingHeight;
            LightLevel = _lightLevel;
            Conditioners = _conditioners;
            Humidifiers = _humidifiers;
            Purificators = _purificators;
            TemperatureSensor = _temperatureSensor;
            HumiditySensor = _humiditySensor;
            CarbonDioxideSensor = _carbonDioxideSensor;
        }

        // Properties
        public string Name { get; set; }
        public double Area { get; set; }
        public double CeilingHeight { get; set; }
        public HumiditySensor HumiditySensor { get; set; }
        public TemperatureSensor TemperatureSensor { get; set; }
        public CarbonDioxideSensor CarbonDioxideSensor { get; set; }
        public LightLevel LightLevel { get; set; }
        public List<Conditioner> Conditioners { get; set; }
        public List<Humidifier> Humidifiers { get; set; }
        public List<Purificator> Purificators { get; set; }
    }
}