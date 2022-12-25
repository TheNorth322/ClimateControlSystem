using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorDetailsViewModel : ViewModelBase
    {
        private RelayCommand _editCommand;

        public PurificatorDetailsViewModel()
        {
            _selectedPurificatorStore.SelectedPurificatorChanged += UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged += UpdateContents;
        }

        private SelectedPurificatorStore _selectedPurificatorStore => SelectedPurificatorStore.getInstance();
        private IPurificator SelectedPurificator => _selectedPurificatorStore.SelectedPurificator;

        public string PurificatorAirFlow => SelectedPurificator?.AirFlow.ToString() ?? "Unknown";


        public string PurificatorStatus => SelectedPurificator?.IsOn.ToString();

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
            EditViewModelStore.getInstance().EditViewModel = new PurificatorDetailsEditViewModel();
        }

        protected override void Dispose()
        {
            _selectedPurificatorStore.SelectedPurificatorChanged -= UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged -= UpdateContents;
            base.Dispose();
        }

        private void UpdateContents()
        {
            OnPropertyChange(nameof(PurificatorAirFlow));
            OnPropertyChange(nameof(PurificatorStatus));
        }
    }
}