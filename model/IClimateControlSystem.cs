using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    public interface IClimateControlSystem
    {
        List<Room> Rooms { get; }

        byte[] PassCode { get; set; }

        void UpdateRoomsData();
    }
}