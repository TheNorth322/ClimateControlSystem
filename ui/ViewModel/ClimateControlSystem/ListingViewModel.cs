using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ListingViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;
        private readonly ObservableCollection<RoomListingItemViewModel> _roomListingItemViewModels;

        public IEnumerable<RoomListingItemViewModel> RoomListingItemViewModels => _roomListingItemViewModels;
        private RoomListingItemViewModel selectedRoomListingItemViewModel;

        public RoomListingItemViewModel SelectedRoomListingItemViewModel
        {
            get { return selectedRoomListingItemViewModel; }
            set
            {
                selectedRoomListingItemViewModel = value;
                

                _selectedRoomStore.SelectedRoom = selectedRoomListingItemViewModel.Room;
                OnPropertyChange(nameof(SelectedRoomListingItemViewModel));
            }
        }

        public ListingViewModel(SelectedRoomStore selectedRoomStore)
        {
            _selectedRoomStore = selectedRoomStore;
            _roomListingItemViewModels = new ObservableCollection<RoomListingItemViewModel>();

            /*_roomListingItemViewModels.Add(new RoomListingItemViewModel(new Room(
                "Kitchen",
                20,
                20,
                LightLevel.AverageIllumination,
                new TemperatureSensor(20),
                new HumiditySensor(20),
                new CarbonDioxideSensor(20)
            )));
            _roomListingItemViewModels.Add(new RoomListingItemViewModel(new Room(
                "Room",
                30,
                30,
                LightLevel.AverageIllumination,
                new TemperatureSensor(30),
                new HumiditySensor(30),
                new CarbonDioxideSensor(30)
            )));
            _roomListingItemViewModels.Add(new RoomListingItemViewModel(new Room(
                "Bedroom",
                40,
                40,
                LightLevel.AverageIllumination,
                new TemperatureSensor(40),
                new HumiditySensor(40),
                new CarbonDioxideSensor(40)
            )));*/
        }
    }
}