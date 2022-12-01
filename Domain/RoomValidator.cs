using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class RoomValidator
    {
        public RoomValidator()
        {
        }

        public bool Validate(Room room)
        {
            if (room == null)
                throw new ArgumentNullException("Room can't be null!");
            if (room.Area <= 0)
                throw new ArgumentException("Room area must be greater than zero!");
            if (room.CeilingHeight <= 0)
                throw new ArgumentException("Room height must be greater than zero!");
            if (String.IsNullOrWhiteSpace(room.Name))
                throw new ArgumentException("Room name can't be null or whitespace!");
            if (room.HumiditySensor.Humidity <= 0)
                throw new ArgumentException("Humidity must be greater than zero!");
            if (room.CarbonDioxideSensor.CarbonDioxide <= 0)
                throw new ArgumentException("Carbon dioxide level must be greater than zero!");
            return true;
        }
    }
}