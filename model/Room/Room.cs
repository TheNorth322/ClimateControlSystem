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

        public void UpdateData()
        {
            double RoomVolume = Area * CeilingHeight;
            double AirMass = RoomVolume * 10;
            /* Volume ration of airflow and air mass of room multiplied on conditioner temperature
            sums up with volume ration of left air mass of room multiplied on room temperature*/
            foreach (IConditioner conditioner in Conditioners)
                TemperatureSensor.Temperature = conditioner.ProvideHeat() / RoomVolume +
                                                 (RoomVolume - conditioner.AirFlow) / RoomVolume *
                                                 TemperatureSensor.Temperature;

            foreach (IHumidifier humidifier in Humidifiers)
                HumiditySensor.Humidity =
                    (humidifier.ProvideHumidity() / 60 + (HumiditySensor.Humidity / 100) * AirMass) / AirMass * 100;

            foreach (IPurificator purificator in Purificators)
                CarbonDioxideSensor.CarbonDioxide -= purificator.ReceivePurification() / 60 * 8;
        }
    }
}