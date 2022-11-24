using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class ClimateControlSystemValidator
    {
        public ClimateControlSystemNamespace.ClimateControlSystem ClimateControlSystem { get; }

        public ClimateControlSystemValidator(ClimateControlSystemNamespace.ClimateControlSystem climateControlSystem)
        {
            ClimateControlSystem = climateControlSystem;
        }

        public bool Validate()
        {
            RoomValidator roomValidator = new RoomValidator();
            foreach (Room room in ClimateControlSystem.Rooms)
                if (!roomValidator.Validate(room))
                    return false;
            return true;
        }
    }
}