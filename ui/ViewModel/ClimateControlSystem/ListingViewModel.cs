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

        public ListingViewModel(SelectedRoomStore selectedRoomStore, ClimateControlSystemNamespace.ClimateControlSystem _system)
        {
            _selectedRoomStore = selectedRoomStore;
            _roomListingItemViewModels = new ObservableCollection<RoomListingItemViewModel>();
            
            foreach (Room _room in _system.Rooms)
                _roomListingItemViewModels.Add(new RoomListingItemViewModel(_room));
        }
    }
}