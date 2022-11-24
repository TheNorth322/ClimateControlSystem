using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class HumidifierDetailsViewModel : ViewModelBase
    {
        private readonly SelectedHumidifierStore selectedHumidifierStore;
        public double WaterConsumption => selectedHumidifierStore.SelectedHumidifier.WaterConsumption;
        public double ExpectedHumidity => selectedHumidifierStore.SelectedHumidifier.ExpectedHumidityLevel;
        public bool isOn => selectedHumidifierStore.SelectedHumidifier.isOn;
        public HumidifierDetailsViewModel(SelectedHumidifierStore _selectedHumidifierStore)
        {
            selectedHumidifierStore = _selectedHumidifierStore;
        }
    }
}