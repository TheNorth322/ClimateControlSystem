using System;
using System.Collections.Generic;
using System.Xml;
namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class ClimateControlSystem
    {
        // Properties 
        public List<Room> Rooms { get; }
        public byte[] PassCode { get; set; }
        // Constructors
        public ClimateControlSystem()
        {
            Rooms = new List<Room>();
        }
        public ClimateControlSystem(List<Room> _rooms) => Rooms = _rooms;
    }
}
