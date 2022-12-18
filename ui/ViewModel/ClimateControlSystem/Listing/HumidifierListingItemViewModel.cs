using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class HumidifierListingItemViewModel : ViewModelBase
    {
        public HumidifierListingItemViewModel(Humidifier humidifier)
        {
            Humidifier = humidifier;
        }

        public Humidifier Humidifier{ get; }

        public string Name => "Humidifier";
    }
}