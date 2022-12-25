using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedRoomStore
    {
        private static SelectedRoomStore instance;

        private IRoom selectedRoom;

        private SelectedRoomStore()
        {
        }

        public IRoom SelectedRoom
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