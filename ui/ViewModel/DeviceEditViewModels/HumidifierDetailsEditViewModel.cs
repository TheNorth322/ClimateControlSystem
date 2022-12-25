using System;
using ClimateControlSystem.Domain;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.DeviceEditViewModels
{
    public class HumidifierDetailsEditViewModel : ViewModelBase
    {
        private RelayCommand _closeModalCommand;
        private RelayCommand _confirmEditCommand;
        private readonly SelectedHumidifierStore _selectedHumidifierStore = SelectedHumidifierStore.getInstance();
        private bool _status;
        private readonly EditHumidifierUpdater humidifierUpdater;
        private readonly EditHumidifierValidator humidifierValidator;

        public HumidifierDetailsEditViewModel()
        {
            humidifierValidator = new EditHumidifierValidator();
            humidifierUpdater = new EditHumidifierUpdater();
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

        public RelayCommand ConfirmEditCommand
        {
            get
            {
                return _confirmEditCommand ?? new RelayCommand(
                    _object => ConfirmEdit(),
                    _object => ValidateData());
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

        private void ConfirmEdit()
        {
            try
            {
                humidifierValidator.Validate(Status, _selectedHumidifierStore.SelectedHumidifier.WaterConsumption);
                humidifierUpdater.Update(Status);

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
            // TODO
            return true;
        }
    }
}