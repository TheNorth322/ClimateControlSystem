using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class HumidifierDetailsViewModel : ViewModelBase
    {
        private SelectedHumidifierStore _selectedHumidifierStore => SelectedHumidifierStore.getInstance();
        private Humidifier SelectedHumidifier => _selectedHumidifierStore.SelectedHumidifier;

        //TODO
        public string WaterConsumption => SelectedHumidifier?.WaterConsumption.ToString() ?? "Unknown";
        public string HumidifierStatus => SelectedHumidifier?.isOn.ToString();
        public int RoomIndex { get; set; }
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
            EditViewModelStore.getInstance().EditViewModel = new HumidifierDetailsEditViewModel(RoomIndex);
        }

        public HumidifierDetailsViewModel()
        {
            _selectedHumidifierStore.SelectedHumidifierChanged += SelectedHumidifierStore_SelectedHumidifierChanged;
        }

        protected override void Dispose()
        {
            _selectedHumidifierStore.SelectedHumidifierChanged -= SelectedHumidifierStore_SelectedHumidifierChanged;
            base.Dispose();
        }

        private void SelectedHumidifierStore_SelectedHumidifierChanged()
        {
            OnPropertyChange(nameof(WaterConsumption));
            OnPropertyChange(nameof(HumidifierStatus));
        }
    }
}