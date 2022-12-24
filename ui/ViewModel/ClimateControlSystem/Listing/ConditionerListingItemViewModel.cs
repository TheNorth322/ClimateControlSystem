using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ConditionerListingItemViewModel : ViewModelBase
    {
        public ConditionerListingItemViewModel(IConditioner conditioner)
        {
            Conditioner = conditioner;
        }
        
        public IConditioner Conditioner { get; }

        public string Name => "Conditioner";
    }
}