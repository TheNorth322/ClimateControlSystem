using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;

        public RoomDetailsViewModel(SelectedRoomStore selectedRoomStore)
        {
            _selectedRoomStore = selectedRoomStore;
            _selectedRoomStore.SelectedRoomChanged += SelectedRoomStore_SelectedRoomChanged;
        }

        public Room SelectedRoom => _selectedRoomStore.SelectedRoom;
        public string Name => SelectedRoom?.Name ?? "Unknown";
        public string Temperature => SelectedRoom?.TemperatureSensor.Temperature.ToString() ?? "Unknown";
        public string Humidity => SelectedRoom?.HumiditySensor.Humidity.ToString() ?? "Unknown";
        public string CarbonDioxideLevel => SelectedRoom?.CarbonDioxideSensor.CarbonDioxide.ToString() ?? "Unknown";
        public string LightLevel => SelectedRoom != null ? SelectedRoom.LightLevel.GetEnumDescription() : "Unknown";
        /*public string WorkingTemperature => SelectedRoom?.Conditioner.WorkingTemperature.ToString() ?? "Unknown";
        public string ConditionerAirFlow => SelectedRoom?.Conditioner.AirFlow.ToString() ?? "Unknown";

        public string ConditionerMode => SelectedRoom != null
            ? EnumExtensionMethods.GetEnumDescription(SelectedRoom.Conditioner.ConditionerMode)
            : "Unknown";

        public string ConditionerStatus => SelectedRoom.Conditioner.isOn.ToString();
        public string WaterConsumption => SelectedRoom?.Humidifier.WaterConsumption.ToString() ?? "Unknown";
        public string ExpectedHumidity => SelectedRoom?.Humidifier.ExpectedHumidityLevel.ToString() ?? "Unknown";
        public string HumidifierStatus => SelectedRoom.Humidifier.isOn.ToString();
        public string PurificatorAirFlow => SelectedRoom?.Purificator.AirFlow.ToString() ?? "Unknown";

        public string ExpectedCarbonDioxide =>
            SelectedRoom?.Purificator.ExpectedCarbonDioxideLevel.ToString() ?? "Unknown";

        public string PurificatorStatus => SelectedRoom.Purificator.isOn.ToString();
*/
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
            //OnPropertyChange(nameof(WorkingTemperature));
            //OnPropertyChange(nameof(ConditionerAirFlow));
            OnPropertyChange(nameof(ConditionerMode));
            /*OnPropertyChange(nameof(ConditionerStatus));
            OnPropertyChange(nameof(WaterConsumption));
            OnPropertyChange(nameof(ExpectedHumidity));
            OnPropertyChange(nameof(HumidifierStatus));
            OnPropertyChange(nameof(PurificatorAirFlow));
            OnPropertyChange(nameof(ExpectedCarbonDioxide));
            OnPropertyChange(nameof(PurificatorStatus));*/
        }
    }
}