using System;
using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.DeviceEditViewModels
{
    public class HumidifierDetailsEditViewModel : ViewModelBase
    {
        private bool _status;
        private RelayCommand _confirmEditCommand;
        private SelectedHumidifierStore _selectedHumidifierStore = SelectedHumidifierStore.getInstance();
        private EditHumidifierValidator humidifierValidator;
        private EditHumidifierUpdater humidifierUpdater;
        private RelayCommand _closeModalCommand;

        public HumidifierDetailsEditViewModel()
        {
            humidifierValidator = new EditHumidifierValidator();
            humidifierUpdater = new EditHumidifierUpdater();
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
                MessageBox_Show(null, e.Message, "Error occured!", MessageBoxButton.OK);
            }
        }

        private bool ValidateData()
        {
            // TODO
            return true;
        }
    }
}