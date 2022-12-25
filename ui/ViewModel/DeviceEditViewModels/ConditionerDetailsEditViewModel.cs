using System;
using ClimateControlSystem.Domain;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.DeviceEditViewModels
{
    public class ConditionerDetailsEditViewModel : ViewModelBase
    {
        private RelayCommand _closeModalCommand;
        private RelayCommand _confirmEditCommand;
        private ConditionerMode _mode;
        private bool _status;
        private double _workingTemperature;
        private readonly EditConditionerUpdater conditionerUpdater;
        private readonly EditConditionerValidator conditionerValidator;

        public ConditionerDetailsEditViewModel()
        {
            conditionerValidator = new EditConditionerValidator();
            conditionerUpdater = new EditConditionerUpdater();
        }

        public double WorkingTemperature
        {
            get => _workingTemperature;
            set
            {
                _workingTemperature = value;
                OnPropertyChange(nameof(WorkingTemperature));
            }
        }

        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChange(nameof(Status));
            }
        }

        public ConditionerMode Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                OnPropertyChange(nameof(Mode));
            }
        }

        public RelayCommand CloseModalCommand
        {
            get
            {
                return _closeModalCommand ?? new RelayCommand(
                    _object => CloseModal(),
                    _object => true);
            }
        }

        public RelayCommand ConfirmEditCommand
        {
            get
            {
                return _confirmEditCommand ?? new RelayCommand(
                    _object => ConfirmEdit(),
                    _object => ValidateData());
            }
        }

        private void CloseModal()
        {
            EditViewModelStore.getInstance().CloseModal();
        }

        private void ConfirmEdit()
        {
            try
            {
                conditionerValidator.Validate(Status, Mode, WorkingTemperature);
                conditionerUpdater.Update(Status, Mode, WorkingTemperature);
                ClimateControlSystemStore.getInstance().ClimateControlSystemContentsChangedInvoke();
                EditViewModelStore.getInstance().CloseModal();
            }
            catch (Exception e)
            {
                MessageBox_Show(null, e.Message, "Error occured!");
            }
        }

        private bool ValidateData()
        {
            return true;
        }
    }
}