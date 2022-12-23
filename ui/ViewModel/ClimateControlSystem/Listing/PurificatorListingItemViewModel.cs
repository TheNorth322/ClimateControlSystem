using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorListingItemViewModel : ViewModelBase
    {
        public PurificatorListingItemViewModel(Purificator purificator, int _purificatorIndex, int _roomIndex)
        {
            Purificator = purificator;
            PurificatorIndex = _purificatorIndex;
            RoomIndex = _roomIndex;
        }
        public int PurificatorIndex { get; set; }
        public int RoomIndex { get; set; }
        public Purificator Purificator { get; }

        public string Name => "Purificator";
    }
}