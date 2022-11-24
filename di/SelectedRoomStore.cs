using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedRoomStore
    {
        private Room selectedRoom;

        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set
            {
                selectedRoom = value;
                SelectedRoomChanged?.Invoke();
            }
        }

        /*public SelectedRoomStore(Room selectedRoom)
        {
            SelectedRoom = selectedRoom;
        }*/
        public event Action SelectedRoomChanged;
    }
}