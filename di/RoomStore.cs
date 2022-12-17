using System;
using System.Windows.Media;

namespace ClimateControlSystemNamespace
{
    public class RoomStore
    {
        private static RoomStore instance;
        private Room _room;

        private RoomStore()
        {
            Room = new Room();
        }

        public Room Room
        {
            get => _room;
            set
            {
                _room = value;
                RoomChanged?.Invoke();
            }
        }

        public static RoomStore getInstance()
        {
            if (instance == null)
                instance = new RoomStore();

            return instance;
        }

        public void Clear()
        {
            Room = new Room();
        }
        
        public event Action RoomChanged;
    }
}