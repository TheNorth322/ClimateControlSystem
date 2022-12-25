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
        }

        public ClimateControlSystem(List<Room> _rooms)
        {
            Rooms = _rooms ?? throw new NullReferenceException("Rooms can't be null!");
        }

        // Properties 
        public List<Room> Rooms { get; }
        public byte[] PassCode { get; set; }

        public void UpdateRoomsData()
        {
            CompareExpectedToCurrent();
            ChangeConditionersWorkingTemperature();
            ChangeConditionersMode();
            foreach (IRoom room in Rooms)
                room.UpdateData();
        }

        public void AddRoom(Room _room)
        {
            if (_room != null)
            {
                Rooms.Add(_room);
                return;
            }

            throw new NullReferenceException("Room can't be null!");
        }

        private void ChangeConditionersMode()
        {
            foreach (IRoom room in Rooms)
            {
                if (room.TemperatureSensor.Temperature > room.TemperatureSensor.ExpectedTemperature)
                {
                    foreach (IConditioner conditioner in room.Conditioners)
                        conditioner.TurnOnCoolingMode();
                    return;
                }

                foreach (IConditioner conditioner in room.Conditioners)
                    conditioner.TurnOnHeatingMode();
            }
        }

        private void ChangeConditionersWorkingTemperature()
        {
            foreach (IRoom room in Rooms)
            foreach (IConditioner conditioner in room.Conditioners)
                conditioner.WorkingTemperature = room.TemperatureSensor.ExpectedTemperature;
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
            foreach (IRoom room in Rooms)
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
                    TurnOff(room.Purificators);
                else
                    TurnOn(room.Purificators);
            }
        }
    }
}