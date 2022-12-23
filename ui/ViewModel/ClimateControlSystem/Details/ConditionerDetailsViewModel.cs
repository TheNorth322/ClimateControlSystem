using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
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
        public int RoomIndex { get; set; }
        public string ConditionerMode => SelectedConditioner != null
            ? EnumExtensionMethods.GetEnumDescription(SelectedConditioner.ConditionerMode)
            : "Unknown";

        public string ConditionerStatus => SelectedConditioner.isOn.ToString();
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
            EditViewModelStore.getInstance().EditViewModel = new ConditionerDetailsEditViewModel(RoomIndex);
        }
        public ConditionerDetailsViewModel(int _roomIndex)
        {
            _selectedConditionerStore.SelectedConditionerChanged += SelectedConditionerStore_SelectedConditionerChanged;
            RoomIndex = _roomIndex;
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