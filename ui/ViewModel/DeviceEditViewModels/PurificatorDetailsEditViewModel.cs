using System;
using ClimateControlSystem.Domain;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.DeviceEditViewModels
{
    public class PurificatorDetailsEditViewModel : ViewModelBase
    {
        private RelayCommand _closeModalCommand;
        private RelayCommand _confirmEditCommand;
        private readonly SelectedPurificatorStore _selectedPurificatorStore = SelectedPurificatorStore.getInstance();
        private bool _status;
        private readonly EditPurificatorUpdater purificatorUpdater;
        private readonly EditPurificatorValidator purificatorValidator;

        public PurificatorDetailsEditViewModel()
        {
            purificatorValidator = new EditPurificatorValidator();
            purificatorUpdater = new EditPurificatorUpdater();
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
                purificatorValidator.Validate(Status, _selectedPurificatorStore.SelectedPurificator.AirFlow);
                purificatorUpdater.Update(Status);

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