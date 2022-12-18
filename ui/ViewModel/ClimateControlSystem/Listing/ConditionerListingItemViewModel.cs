using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ConditionerListingItemViewModel : ViewModelBase
    {
        public ConditionerListingItemViewModel(Conditioner conditioner)
        {
            Conditioner = conditioner;
        }

        public Conditioner Conditioner { get; }

        public string Name => "Conditioner";
    }
}