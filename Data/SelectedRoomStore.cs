using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedRoomStore
    {
        private static SelectedRoomStore instance;

        private Room selectedRoom;

        private SelectedRoomStore()
        {
        }

        public Room SelectedRoom
        {
            get => selectedRoom;
            set
            {
                selectedRoom = value;
                SelectedRoomChanged?.Invoke();
            }
        }

        public static SelectedRoomStore getInstance()
        {
            if (instance == null)
                instance = new SelectedRoomStore();
            return instance;
        }

        public event Action SelectedRoomChanged;
    }
}