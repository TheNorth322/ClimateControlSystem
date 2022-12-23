using System;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
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

        public string ExpectedTemperature =>
            SelectedRoom?.TemperatureSensor.ExpectedTemperature.ToString() ?? "Unknown";

        public string ExpectedHumidity => SelectedRoom?.HumiditySensor.ExpectedHumidity.ToString() ?? "Unknown";

        public string ExpectedCarbonDioxide =>
            SelectedRoom?.CarbonDioxideSensor.ExpectedCarbonDioxide.ToString() ?? "Unknown";

        protected override void Dispose()
        {
            _selectedRoomStore.SelectedRoomChanged -= SelectedRoomStore_SelectedRoomChanged;
            base.Dispose();
        }

        private RelayCommand _editCommand;

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ?? new RelayCommand(_object => OpenEditModal(),
                    _object => true);
            }
        }

        private void OpenEditModal()
        {
            EditViewModelStore.getInstance().EditViewModel = new RoomDetailsEditViewModel(_selectedRoomStore.SelectedRoomIndex);
        }

        private void SelectedRoomStore_SelectedRoomChanged()
        {
            OnPropertyChange(nameof(Name));
            OnPropertyChange(nameof(Temperature));
            OnPropertyChange(nameof(Humidity));
            OnPropertyChange(nameof(CarbonDioxideLevel));
            OnPropertyChange(nameof(LightLevel));
            OnPropertyChange(nameof(ExpectedTemperature));
            OnPropertyChange(nameof(ExpectedHumidity));
            OnPropertyChange(nameof(ExpectedCarbonDioxide));
        }
    }
}