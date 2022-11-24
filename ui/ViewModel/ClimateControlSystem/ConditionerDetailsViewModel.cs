using System.Windows.Input;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ConditionerDetailsViewModel : ViewModelBase
    {
        private readonly SelectedConditionerStore selectedConditionerStore;
        public double WorkingTemperature => selectedConditionerStore.SelectedConditioner.WorkingTemperature;
        public double AirFlow => selectedConditionerStore.SelectedConditioner.AirFlow;
        public bool isOn => selectedConditionerStore.SelectedConditioner.isOn;
        public ConditionerMode ConditionerMode => selectedConditionerStore.SelectedConditioner.ConditionerMode;
        
        public ICommand ConfirmChanges { get; }
        public ConditionerDetailsViewModel(SelectedConditionerStore _selectedConditionerStore)
        {
            selectedConditionerStore = _selectedConditionerStore;
        }
    }
}