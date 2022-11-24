using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomListingItemViewModel : ViewModelBase
    {
        public Room Room { get; }

        public string Name => Room.Name;

        public RoomListingItemViewModel(Room room)
        {
            Room = room;
        }
    }
}