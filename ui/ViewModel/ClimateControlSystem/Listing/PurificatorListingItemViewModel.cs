using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorListingItemViewModel : ViewModelBase
    {
        public PurificatorListingItemViewModel(Purificator purificator)
        {
            Purificator = purificator;
        }

        public Purificator Purificator { get; }

        public string Name => "Purificator";
    }
}