using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ConditionerDetailsViewModel : ViewModelBase
    {
        private SelectedConditionerStore _selectedConditionerStore => SelectedConditionerStore.getInstance();
        private Conditioner SelectedConditioner => _selectedConditionerStore.SelectedConditioner;
        //TODO
        public string WorkingTemperature => SelectedConditioner?.WorkingTemperature.ToString() ?? "Unknown";
        public string ConditionerAirFlow => SelectedConditioner?.AirFlow.ToString() ?? "Unknown";

        public string ConditionerMode => SelectedConditioner != null
            ? EnumExtensionMethods.GetEnumDescription(SelectedConditioner.ConditionerMode)
            : "Unknown";

        public string ConditionerStatus => SelectedConditioner.isOn.ToString();

        public ConditionerDetailsViewModel()
        {
            _selectedConditionerStore.SelectedConditionerChanged += SelectedConditionerStore_SelectedConditionerChanged;
        }
        protected override void Dispose()
        {
            _selectedConditionerStore.SelectedConditionerChanged -= SelectedConditionerStore_SelectedConditionerChanged;
            base.Dispose();
        }

        private void SelectedConditionerStore_SelectedConditionerChanged()
        {
            OnPropertyChange(nameof(WorkingTemperature));
            OnPropertyChange(nameof(ConditionerAirFlow));
            OnPropertyChange(nameof(ConditionerMode));
            OnPropertyChange(nameof(ConditionerStatus));
        }
    }
}