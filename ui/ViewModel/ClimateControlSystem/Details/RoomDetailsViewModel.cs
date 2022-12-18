using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private SelectedRoomStore _selectedRoomStore => SelectedRoomStore.getInstance();

        public RoomDetailsViewModel()
        {
            _selectedRoomStore.SelectedRoomChanged += SelectedRoomStore_SelectedRoomChanged;
        }

        public Room SelectedRoom => _selectedRoomStore.SelectedRoom;
        public string Name => SelectedRoom?.Name ?? "Unknown";
        public string Temperature => SelectedRoom?.TemperatureSensor.Temperature.ToString() ?? "Unknown";
        public string Humidity => SelectedRoom?.HumiditySensor.Humidity.ToString() ?? "Unknown";
        public string CarbonDioxideLevel => SelectedRoom?.CarbonDioxideSensor.CarbonDioxide.ToString() ?? "Unknown";
        public string LightLevel => SelectedRoom != null ? SelectedRoom.LightLevel.GetEnumDescription() : "Unknown";
        
        protected override void Dispose()
        {
            _selectedRoomStore.SelectedRoomChanged -= SelectedRoomStore_SelectedRoomChanged;
            base.Dispose();
        }

        private void SelectedRoomStore_SelectedRoomChanged()
        {
            OnPropertyChange(nameof(Name));
            OnPropertyChange(nameof(Temperature));
            OnPropertyChange(nameof(Humidity));
            OnPropertyChange(nameof(CarbonDioxideLevel));
            OnPropertyChange(nameof(LightLevel));
        }
    }
}