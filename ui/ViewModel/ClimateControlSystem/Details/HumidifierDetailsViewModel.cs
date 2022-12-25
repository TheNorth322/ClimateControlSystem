using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class HumidifierDetailsViewModel : ViewModelBase
    {
        private RelayCommand _editCommand;

        public HumidifierDetailsViewModel()
        {
            _selectedHumidifierStore.SelectedHumidifierChanged += UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged += UpdateContents;
        }

        private SelectedHumidifierStore _selectedHumidifierStore => SelectedHumidifierStore.getInstance();
        private IHumidifier SelectedHumidifier => _selectedHumidifierStore.SelectedHumidifier;

        //TODO
        public string WaterConsumption => SelectedHumidifier?.WaterConsumption.ToString() ?? "Unknown";
        public string HumidifierStatus => SelectedHumidifier?.IsOn.ToString();

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
            EditViewModelStore.getInstance().EditViewModel = new HumidifierDetailsEditViewModel();
        }

        protected override void Dispose()
        {
            _selectedHumidifierStore.SelectedHumidifierChanged -= UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged -= UpdateContents;
            base.Dispose();
        }

        private void UpdateContents()
        {
            OnPropertyChange(nameof(WaterConsumption));
            OnPropertyChange(nameof(HumidifierStatus));
        }
    }
}