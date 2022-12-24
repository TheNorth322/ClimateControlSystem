using System;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private SelectedRoomStore _selectedRoomStore => SelectedRoomStore.getInstance();
        public RoomDetailsViewModel(PlotPointsStore _pointsStore)
        {
            PointsStore = _pointsStore;
            _selectedRoomStore.SelectedRoomChanged += UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged += UpdateContents;
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

        public PlotPointsStore PointsStore;
        protected override void Dispose()
        {
            _selectedRoomStore.SelectedRoomChanged -= UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged -= UpdateContents;
            base.Dispose();
        }

        private RelayCommand _editCommand;

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ?? new RelayCommand(_object => OpenEditModal(),
                    _object => ValidateSelectedRoom());
            }
        }

        

        private bool ValidateSelectedRoom()
        {
            return (SelectedRoom != null);
        }

        private void OpenEditModal()
        {
            EditViewModelStore.getInstance().EditViewModel = new RoomDetailsEditViewModel();
        }

        private void UpdateContents()
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