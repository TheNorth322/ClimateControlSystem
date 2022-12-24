using System.Windows.Forms.VisualStyles;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorDetailsViewModel : ViewModelBase
    {
        private SelectedPurificatorStore _selectedPurificatorStore => SelectedPurificatorStore.getInstance();
        private IPurificator SelectedPurificator => _selectedPurificatorStore.SelectedPurificator;

        public string PurificatorAirFlow => SelectedPurificator?.AirFlow.ToString() ?? "Unknown";


        public string PurificatorStatus => SelectedPurificator?.IsOn.ToString();
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
            EditViewModelStore.getInstance().EditViewModel = new PurificatorDetailsEditViewModel();
        }

        public PurificatorDetailsViewModel()
        {
            _selectedPurificatorStore.SelectedPurificatorChanged += UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged += UpdateContents;
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