using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ClimateControlSystemViewModel : ViewModelBase
    {
        public ListingViewModel ListingViewModel { get; }
        public RoomDetailsViewModel DetailsViewModel { get; }

        public ClimateControlSystemViewModel(SelectedRoomStore _selectedRoomStore)
        {
            ListingViewModel = new ListingViewModel(_selectedRoomStore);
            DetailsViewModel = new RoomDetailsViewModel(_selectedRoomStore);
        }
    }
}