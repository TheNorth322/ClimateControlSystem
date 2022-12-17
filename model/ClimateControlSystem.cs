using System;
using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class ClimateControlSystem
    {
        // Constructors
        public ClimateControlSystem()
        {
            Rooms = new List<Room>();
        }

        public ClimateControlSystem(List<Room> _rooms)
        {
            Rooms = _rooms;
        }

        // Properties 
        public List<Room> Rooms { get; }
        public byte[] PassCode { get; set; }
    }
}