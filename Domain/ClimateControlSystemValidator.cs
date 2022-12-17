namespace ClimateControlSystem.Domain
{
    public class ClimateControlSystemValidator
    {
        public static bool Validate(ClimateControlSystemNamespace.ClimateControlSystem _climateControlSystem)
        {
            foreach (var room in _climateControlSystem.Rooms)
                if (!RoomValidator.Validate(room))
                    return false;
            return true;
        }
    }
}