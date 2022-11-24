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
            if (room == null ||
                room.Area <= 0 ||
                room.CeilingHeight <= 0 ||
                String.IsNullOrWhiteSpace(room.Name) ||
                room.HumiditySensor.Humidity <= 0 ||
                room.CarbonDioxideSensor.CarbonDioxide <= 0)
                return false;
            return true;
            /* Can throw exception to catch them in viewmodel
             and show MessageBox in view with exception message
            if (room == null)
                throw new ArgumentNullException("...");
            if (room == null)
                throw new ArgumentNullException("...");
            if (room == null)
                throw new ArgumentNullException("...");
            */
        }
    }
}