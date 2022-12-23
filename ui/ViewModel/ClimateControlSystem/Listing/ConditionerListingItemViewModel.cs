using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ConditionerListingItemViewModel : ViewModelBase
    {
        public ConditionerListingItemViewModel(Conditioner conditioner, int _conditionerIndex, int _roomIndex)
        {
            Conditioner = conditioner;
            ConditionerIndex = _conditionerIndex;
            RoomIndex = _roomIndex;
        }
        
        public int ConditionerIndex { get; set; }
        public int RoomIndex { get; set; }
        public Conditioner Conditioner { get; }

        public string Name => "Conditioner";
    }
}