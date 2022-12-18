using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class HumidifierDetailsViewModel : ViewModelBase
    {
        private SelectedHumidifierStore _selectedHumidifierStore => SelectedHumidifierStore.getInstance();
        private Humidifier SelectedHumidifier => _selectedHumidifierStore.SelectedHumidifier;
        
        //TODO
        public string WaterConsumption => SelectedHumidifier?.WaterConsumption.ToString() ?? "Unknown";
        public string ExpectedHumidity => SelectedHumidifier?.ExpectedHumidityLevel.ToString() ?? "Unknown";
        public string HumidifierStatus => SelectedHumidifier?.isOn.ToString();

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
            OnPropertyChange(nameof(ExpectedHumidity));
            OnPropertyChange(nameof(HumidifierStatus));
        }
    }
}