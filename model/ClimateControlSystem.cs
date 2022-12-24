using System;
using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class ClimateControlSystem : IClimateControlSystem
    {
        // Constructors
        public ClimateControlSystem()
        {
            Rooms = new List<Room>();
            ExpectedTemperature = 24;
            ExpectedCarbonDioxideLevel = 600;
            ExpectedHumidityLevel = 60;
        }

        public ClimateControlSystem(List<Room> _rooms, double _expectedTemperature,
            double _expectedCarbonDioxideLevel, double _expectedHumidityLevel)
        {
            Rooms = _rooms;
            ExpectedTemperature = _expectedTemperature;
            ExpectedHumidityLevel = _expectedHumidityLevel;
            ExpectedCarbonDioxideLevel = _expectedCarbonDioxideLevel;
        }

        // Properties 
        public List<Room> Rooms { get; }
        public byte[] PassCode { get; set; }
        public double ExpectedTemperature { get; set; }
        public double ExpectedCarbonDioxideLevel { get; set; }
        public double ExpectedHumidityLevel { get; set; }

        public void UpdateRoomsData()
        {
            CompareExpectedToCurrent();
            ChangeConditionersWorkingTemperature();  
            ChangeConditionersMode();
            foreach (Room room in Rooms)
                room.UpdateData();
        }

        private void ChangeConditionersMode()
        {
            foreach (Room room in Rooms)
            {
                if (room.TemperatureSensor.Temperature > room.TemperatureSensor.ExpectedTemperature)
                {
                    foreach (Conditioner conditioner in room.Conditioners)
                        conditioner.TurnOnCoolingMode();
                    return;
                }

                foreach (Conditioner conditioner in room.Conditioners)
                    conditioner.TurnOnHeatingMode();
            }
        }

        private void ChangeConditionersWorkingTemperature()
        {
            foreach (Room room in Rooms)
                foreach (Conditioner conditioner in room.Conditioners)
                    conditioner.WorkingTemperature = ExpectedTemperature;
        }
        private void TurnOff<T>(List<T> _list)
        {
            foreach (var item in _list)
            {
                if (item.GetType() == typeof(Conditioner))
                    (item as Conditioner).TurnOff();
                if (item.GetType() == typeof(Humidifier))
                    (item as Humidifier).TurnOff();
                if (item.GetType() == typeof(Purificator))
                    (item as Purificator).TurnOff();
            }
        }

        private void TurnOn<T>(List<T> _list)
        {
            foreach (var item in _list)
            {
                if (item.GetType() == typeof(Conditioner))
                    (item as Conditioner).TurnOn();
                if (item.GetType() == typeof(Humidifier))
                    (item as Humidifier).TurnOn();
                if (item.GetType() == typeof(Purificator))
                    (item as Purificator).TurnOn();
            }
        }

        private void CompareExpectedToCurrent()
        {
            foreach (Room room in Rooms)
            {
                if (Math.Abs(room.TemperatureSensor.Temperature - room.TemperatureSensor.ExpectedTemperature) <= 0.5)
                    TurnOff(room.Conditioners);
                else
                    TurnOn(room.Conditioners);

                if (room.HumiditySensor.Humidity >= room.HumiditySensor.ExpectedHumidity)
                   TurnOff(room.Humidifiers); 
                else
                   TurnOn(room.Humidifiers); 

                if (room.CarbonDioxideSensor.CarbonDioxide <= room.CarbonDioxideSensor.ExpectedCarbonDioxide)
                   TurnOff<Purificator>(room.Purificators); 
                else
                   TurnOn<Purificator>(room.Purificators); 
            }
        }
    }
}