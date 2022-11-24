using System;
using System.Collections.Generic;
using System.Xml;
namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class ClimateControlSystem
    {
        // Fields 
        private List<Room> rooms;
        
        // Properties 
        public List<Room> Rooms
        {
            get { return rooms; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Wrong rooms value! Shouldn't be null!");
                rooms = value;
            }
        }
        
        
        // Constructors
        public ClimateControlSystem()
        {
            Rooms = new List<Room>();
        }

        public ClimateControlSystem(List<Room> _rooms) => rooms = _rooms;

        // Methods
        /*
        public void updateRoomCharacteristics()
        {
            if (conditioner.DeviceMode == DeviceMode.On) {
                double incomeTemperature = (conditioner.AirFlow / room.Volume); //conditioner.WorkTemperature;
                room.Temperature = (conditioner.ConditionerMode == ConditionerMode.Heating) ? room.Temperature + incomeTemperature : room.Temperature - incomeTemperature;
            }
 
        }
        */
    }
}
