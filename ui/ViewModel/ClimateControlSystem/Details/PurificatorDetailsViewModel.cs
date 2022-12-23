using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorDetailsViewModel : ViewModelBase
    {
        private SelectedPurificatorStore _selectedPurificatorStore => SelectedPurificatorStore.getInstance();
        private Purificator SelectedPurificator => _selectedPurificatorStore.SelectedPurificator;

        public string PurificatorAirFlow => SelectedPurificator?.AirFlow.ToString() ?? "Unknown";


        public string PurificatorStatus => SelectedPurificator?.isOn.ToString();
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
            EditViewModelStore.getInstance().EditViewModel = new PurificatorDetailsEditViewModel(RoomIndex);
        }

        public PurificatorDetailsViewModel()
        {
            _selectedPurificatorStore.SelectedPurificatorChanged += SelectedPurificatorStore_SelectedPurificatorChanged;
        }

        protected override void Dispose()
        {
            _selectedPurificatorStore.SelectedPurificatorChanged -= SelectedPurificatorStore_SelectedPurificatorChanged;
            base.Dispose();
        }

        private void SelectedPurificatorStore_SelectedPurificatorChanged()
        {
            OnPropertyChange(nameof(PurificatorAirFlow));
            OnPropertyChange(nameof(PurificatorStatus));
        }
    }
}