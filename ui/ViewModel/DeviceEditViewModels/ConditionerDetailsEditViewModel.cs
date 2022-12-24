using System;
using ClimateControlSystem.Domain;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.DeviceEditViewModels
{
    public class ConditionerDetailsEditViewModel : ViewModelBase
    {
        private double _workingTemperature;
        private bool _status;
        private ConditionerMode _mode;
        private RelayCommand _confirmEditCommand;
        private EditConditionerValidator conditionerValidator;
        private EditConditionerUpdater conditionerUpdater;
        private RelayCommand _closeModalCommand;

        public ConditionerDetailsEditViewModel()
        {
            conditionerValidator = new EditConditionerValidator();
            conditionerUpdater = new EditConditionerUpdater();
        }

        public double WorkingTemperature
        {
            get { return _workingTemperature; }
            set
            {
                _workingTemperature = value;
                OnPropertyChange(nameof(WorkingTemperature));
            }
        }

        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChange(nameof(Status));
            }
        }

        public ConditionerMode Mode
        {
            get { return _mode; }
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

        private void CloseModal()
        {
            EditViewModelStore.getInstance().CloseModal();
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