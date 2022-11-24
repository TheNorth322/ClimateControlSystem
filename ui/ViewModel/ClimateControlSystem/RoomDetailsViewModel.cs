using System.ComponentModel;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;
        public Room SelectedRoom => _selectedRoomStore.SelectedRoom;
        
        public string Name => SelectedRoom?.Name ?? "Unknown";
        private string temperature;
        public string Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChange();    
            }
        }

        private string humidity; 
        public string Humidity
        {
            get { return humidity; }
            set
            {
                humidity = value;
                OnPropertyChange();    
            }
        }

        private string carbonDioxideLevel; 
        public string CarbonDioxideLevel
        {
            get { return carbonDioxideLevel; }
            set
            {
                carbonDioxideLevel = value;
                OnPropertyChange();    
            }
        }
        public string LightLevel => SelectedRoom?.LightLevel.ToString();
        
        public RoomDetailsViewModel(SelectedRoomStore selectedRoomStore)
        {
            _selectedRoomStore = selectedRoomStore;
            
            Temperature = SelectedRoom?.TemperatureSensor.Temperature.ToString() ?? "Unknown";
            Humidity = SelectedRoom?.HumiditySensor.Humidity.ToString() ?? "Unknown";
            CarbonDioxideLevel = SelectedRoom?.CarbonDioxideSensor.CarbonDioxide.ToString() ?? "Unknown";
            
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