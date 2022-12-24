using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class HumidifierListingItemViewModel : ViewModelBase
    {
        public HumidifierListingItemViewModel(IHumidifier humidifier)
        {
            Humidifier = humidifier;
        }
        public IHumidifier Humidifier{ get; }
        
        public string Name => "Humidifier";
    }
}