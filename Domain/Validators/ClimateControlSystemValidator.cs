using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class ClimateControlSystemValidator
    {
        public static bool Validate(IClimateControlSystem _climateControlSystem)
        {
            foreach (var room in _climateControlSystem.Rooms)
                if (!RoomValidator.Validate(room))
                    return false;
            return true;
        }
    }
}