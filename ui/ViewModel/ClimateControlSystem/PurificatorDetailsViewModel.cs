using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorDetailsViewModel : ViewModelBase
    {
        private readonly SelectedPurificatorStore selectedPurificatorStore;
        public double AirFlow => selectedPurificatorStore.SelectedPurificator.AirFlow;
        public double ExpectedCarbonDioxideLevel => selectedPurificatorStore.SelectedPurificator.ExpectedCarbonDioxideLevel;
        public bool isOn => selectedPurificatorStore.SelectedPurificator.isOn;
        public PurificatorDetailsViewModel(SelectedPurificatorStore _selectedPurificatorStore)
        {
            selectedPurificatorStore = _selectedPurificatorStore;
        }
    }
}