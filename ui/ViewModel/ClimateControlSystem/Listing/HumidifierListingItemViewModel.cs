using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class HumidifierListingItemViewModel : ViewModelBase
    {
        public HumidifierListingItemViewModel(Humidifier humidifier, int _humidifierIndex, int _roomIndex)
        {
            Humidifier = humidifier;
            HumidifierIndex = _humidifierIndex;
            RoomIndex = _roomIndex;
        }
        public int HumidifierIndex { get; set; }
        public int RoomIndex { get; set; }
        public Humidifier Humidifier{ get; }
        
        public string Name => "Humidifier";
    }
}