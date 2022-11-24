using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class ClimateControlSystemValidator
    {
        public ClimateControlSystemValidator() {}
        public bool Validate(ClimateControlSystemNamespace.ClimateControlSystem _climateControlSystem)
        {
            RoomValidator roomValidator = new RoomValidator();
            foreach (Room room in _climateControlSystem.Rooms)
                if (!roomValidator.Validate(room))
                    return false;
            return true;
        }
    }
}