using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ConditionerDetailsViewModel : ViewModelBase
    {
        private SelectedConditionerStore _selectedConditionerStore => SelectedConditionerStore.getInstance();
        private IConditioner SelectedConditioner => _selectedConditionerStore.SelectedConditioner;
        //TODO
        public string WorkingTemperature => SelectedConditioner?.WorkingTemperature.ToString() ?? "Unknown";
        public string ConditionerAirFlow => SelectedConditioner?.AirFlow.ToString() ?? "Unknown";
        public string ConditionerMode => SelectedConditioner != null
            ? EnumExtensionMethods.GetEnumDescription(SelectedConditioner.ConditionerMode)
            : "Unknown";

        public string ConditionerStatus => SelectedConditioner.IsOn.ToString();
        private RelayCommand _editCommand;

        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ?? new RelayCommand(_object => OpenEditModal(),
                    _object => true);
            }
        }

        private void OpenEditModal()
        {
            EditViewModelStore.getInstance().EditViewModel = new ConditionerDetailsEditViewModel();
        }
        public ConditionerDetailsViewModel()
        {
            _selectedConditionerStore.SelectedConditionerChanged += UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged += UpdateContents;
        }

        protected override void Dispose()
        {
            _selectedConditionerStore.SelectedConditionerChanged -= UpdateContents;
            ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChanged -= UpdateContents;
            base.Dispose();
        }
        
        private void UpdateContents() 
        {
            OnPropertyChange(nameof(WorkingTemperature));
            OnPropertyChange(nameof(ConditionerAirFlow));
            OnPropertyChange(nameof(ConditionerMode));
            OnPropertyChange(nameof(ConditionerStatus));
        }
    }
}