using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RoomListingItemViewModel> _roomListingItemViewModels;
        private readonly SelectedRoomStore _selectedRoomStore;
        private RoomListingItemViewModel selectedRoomListingItemViewModel;

        public ListingViewModel(SelectedRoomStore selectedRoomStore)
        {
            _selectedRoomStore = selectedRoomStore;
            _roomListingItemViewModels = new ObservableCollection<RoomListingItemViewModel>();
            UpdateListing();
        }

        public IEnumerable<RoomListingItemViewModel> RoomListingItemViewModels => _roomListingItemViewModels;

        public RoomListingItemViewModel SelectedRoomListingItemViewModel
        {
            get => selectedRoomListingItemViewModel;
            set
            {
                selectedRoomListingItemViewModel = value;

                _selectedRoomStore.SelectedRoom = selectedRoomListingItemViewModel.Room;
                OnPropertyChange(nameof(SelectedRoomListingItemViewModel));
            }
        }

        private void UpdateListing()
        {
            _roomListingItemViewModels.Clear();
            foreach (var _room in ClimateControlSystemStore.getInstance().ClimateControlSystem.Rooms)
                _roomListingItemViewModels.Add(new RoomListingItemViewModel(_room));
        }
    }
}