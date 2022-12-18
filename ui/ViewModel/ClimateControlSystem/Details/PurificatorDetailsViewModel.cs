using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorDetailsViewModel : ViewModelBase
    {
        private SelectedPurificatorStore _selectedPurificatorStore => SelectedPurificatorStore.getInstance();
        private Purificator SelectedPurificator => _selectedPurificatorStore.SelectedPurificator;
        
        public string PurificatorAirFlow => SelectedPurificator?.AirFlow.ToString() ?? "Unknown";

        public string ExpectedCarbonDioxide =>
            SelectedPurificator?.ExpectedCarbonDioxideLevel.ToString() ?? "Unknown";

        public string PurificatorStatus => SelectedPurificator?.isOn.ToString();

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
            OnPropertyChange(nameof(ExpectedCarbonDioxide));
            OnPropertyChange(nameof(PurificatorStatus));
        }
    }
}