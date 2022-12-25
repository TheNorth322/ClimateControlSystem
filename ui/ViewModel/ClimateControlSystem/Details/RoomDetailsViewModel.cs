using System;
using System.Collections.Generic;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;
using LiveCharts;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private RelayCommand _editCommand;

        private readonly PlotPointsStore PointsStore;

        public RoomDetailsViewModel(PlotPointsStore _pointsStore)
        {
            PointsStore = _pointsStore;
            _selectedRoomStore.SelectedRoomChanged += UpdateContents;
            PointsStore.PointsContentsChanged += OnPointsContentsChanged;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged += UpdateContents;
        }

        private SelectedRoomStore _selectedRoomStore => SelectedRoomStore.getInstance();

        private IRoom SelectedRoom => _selectedRoomStore.SelectedRoom;
        public string Name => SelectedRoom?.Name ?? "Unknown";

        public string Temperature => SelectedRoom == null
            ? "Unknown"
            : Math.Round(SelectedRoom.TemperatureSensor.Temperature, 2).ToString();

        public string Humidity => SelectedRoom == null
            ? "Unknown"
            : Math.Round(SelectedRoom.HumiditySensor.Humidity, 2).ToString();

        public string CarbonDioxideLevel => SelectedRoom == null
            ? "Unknown"
            : Math.Round(SelectedRoom.CarbonDioxideSensor.CarbonDioxide, 2).ToString();

        public string LightLevel => SelectedRoom != null ? SelectedRoom.LightLevel.GetEnumDescription() : "Unknown";

        public string ExpectedTemperature =>
            SelectedRoom?.TemperatureSensor.ExpectedTemperature.ToString() ?? "Unknown";

        public string ExpectedHumidity => SelectedRoom?.HumiditySensor.ExpectedHumidity.ToString() ?? "Unknown";

        public string ExpectedCarbonDioxide =>
            SelectedRoom?.CarbonDioxideSensor.ExpectedCarbonDioxide.ToString() ?? "Unknown";

        public SeriesCollection SeriesCollection => PointsStore.SeriesCollection;
        public List<double> Axis => PointsStore.Axis;

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ?? new RelayCommand(_object => OpenEditModal(),
                    _object => ValidateSelectedRoom());
            }
        }

        protected override void Dispose()
        {
            _selectedRoomStore.SelectedRoomChanged -= UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged -= UpdateContents;
            PointsStore.PointsContentsChanged -= OnPointsContentsChanged;
            base.Dispose();
        }

        private bool ValidateSelectedRoom()
        {
            return SelectedRoom != null;
        }

        private void OpenEditModal()
        {
            EditViewModelStore.getInstance().EditViewModel = new RoomDetailsEditViewModel();
        }

        private void OnPointsContentsChanged()
        {
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