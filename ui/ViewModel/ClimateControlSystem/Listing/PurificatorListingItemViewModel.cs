using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class PurificatorListingItemViewModel : ViewModelBase
    {
        public PurificatorListingItemViewModel(IPurificator purificator)
        {
            Purificator = purificator;
        }
        public IPurificator Purificator { get; }

        public string Name => "Purificator";
    }
}