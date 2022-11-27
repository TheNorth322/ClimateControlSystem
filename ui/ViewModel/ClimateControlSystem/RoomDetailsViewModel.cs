using System.ComponentModel;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;
        public Room SelectedRoom => _selectedRoomStore.SelectedRoom;
        public string Name => SelectedRoom?.Name ?? "Unknown";
        public string Temperature => SelectedRoom?.TemperatureSensor.Temperature.ToString() ?? "Unknown";
        public string Humidity => SelectedRoom?.HumiditySensor.Humidity.ToString() ?? "Unknown";
        public string CarbonDioxideLevel => SelectedRoom?.CarbonDioxideSensor.CarbonDioxide.ToString() ?? "Unknown";
        public string LightLevel => EnumExtensionMethods.GetEnumDescription(SelectedRoom?.LightLevel) ?? "Unknown";
        
        public RoomDetailsViewModel(SelectedRoomStore selectedRoomStore)
        {
            _selectedRoomStore = selectedRoomStore;
            _selectedRoomStore.SelectedRoomChanged += SelectedRoomStore_SelectedRoomChanged;
        }

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