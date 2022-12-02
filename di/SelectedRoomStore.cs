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

        public event Action SelectedRoomChanged;
    }
}