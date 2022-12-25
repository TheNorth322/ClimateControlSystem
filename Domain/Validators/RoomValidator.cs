using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class RoomValidator
    {
        public static bool Validate(IRoom room)
        {
            if (room == null)
                throw new ArgumentNullException("Room can't be null!");
            if (room.Area <= 0)
                throw new ArgumentException("Room area must be greater than zero!");
            if (room.CeilingHeight <= 0 || room.CeilingHeight >= 20)
                throw new ArgumentException("Room height must be greater than zero and less than 20!");
            if (string.IsNullOrWhiteSpace(room.Name))
                throw new ArgumentException("Room name can't be null or whitespace!");
            if (room.HumiditySensor.Humidity <= 0 || room.HumiditySensor.Humidity > 100)
                throw new ArgumentException("Humidity must be greater than zero!");
            if (room.CarbonDioxideSensor.CarbonDioxide <= 0)
                throw new ArgumentException("Carbon dioxide level must be greater than zero!");
            return true;
        }
    }
}