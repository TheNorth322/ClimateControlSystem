using System.Collections.ObjectModel;
using System.Windows.Controls;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomListingItemViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MenuItem> MenuItems = new ObservableCollection<MenuItem>();

        public RoomListingItemViewModel(Room room)
        {
            Room = room;
            UpdateMenuItems();
        }

        public Room Room { get; }

        public string Name => Room.Name;

        private void UpdateMenuItems()
        {
            foreach (var conditioner in Room.Conditioners)
                MenuItems.Add(new MenuItem { Header = "Conditioner" });
            foreach (var humidifier in Room.Humidifiers)
                MenuItems.Add(new MenuItem { Header = "Humidifier" });
            foreach (var purificator in Room.Purificators)
                MenuItems.Add(new MenuItem { Header = "Purificator" });
        }
    }
}