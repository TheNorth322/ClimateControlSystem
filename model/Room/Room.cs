using System;
using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class Room : IRoom
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
            Conditioners = _conditioners ?? throw new NullReferenceException("Conditioners list can't be null!");
            Humidifiers = _humidifiers ?? throw new NullReferenceException("Humidifiers list can't be null!");
            Purificators = _purificators ?? throw new NullReferenceException("Purificators list can't be null!");
            TemperatureSensor = _temperatureSensor ??
                                throw new NullReferenceException("Temperature sensor can't be null");
            HumiditySensor = _humiditySensor ?? throw new NullReferenceException("Humidity sensor can't be null!");
            CarbonDioxideSensor = _carbonDioxideSensor ??
                                  throw new NullReferenceException("Carbon dioxide sensor can't be null!");
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
            var RoomVolume = Area * CeilingHeight;
            var AirMass = RoomVolume * 5;
            /* Volume ration of airflow and air mass of room multiplied on conditioner temperature
            sums up with volume ration of left air mass of room multiplied on room temperature*/
            foreach (IConditioner conditioner in Conditioners)
                TemperatureSensor.Temperature = conditioner.ProvideHeat() / RoomVolume +
                                                (RoomVolume - conditioner.AirFlow) / RoomVolume *
                                                TemperatureSensor.Temperature + (int)LightLevel * 0.04;

            foreach (IHumidifier humidifier in Humidifiers)
                HumiditySensor.Humidity =
                    (humidifier.ProvideHumidity() / 60 + HumiditySensor.Humidity / 100 * AirMass) / AirMass * 100;

            foreach (IPurificator purificator in Purificators)
                CarbonDioxideSensor.CarbonDioxide -= purificator.ProvidePurification() / 60 * 8;
        }

        public void AddConditioner(Conditioner _conditioner)
        {
            if (_conditioner == null)
                throw new NullReferenceException("Conditioner can't be null!");
            Conditioners.Add(_conditioner);
        }

        public void AddHumidifier(Humidifier _humidifier)
        {
            if (_humidifier == null)
                throw new NullReferenceException("Humidifier can't be null!");
            Humidifiers.Add(_humidifier);
        }

        public void AddPurificator(Purificator _purificator)
        {
            if (_purificator == null)
                throw new NullReferenceException("Purificator can't be null!");
            Purificators.Add(_purificator);
        }

        public void UpdateLightLevel(LightLevel _lightLevel)
        {
            LightLevel = _lightLevel;
        }
    }
}