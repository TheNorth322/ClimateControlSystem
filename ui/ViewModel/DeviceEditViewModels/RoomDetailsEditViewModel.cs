using System;
using ClimateControlSystem.Domain;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.DeviceEditViewModels
{
    public class RoomDetailsEditViewModel : ViewModelBase
    {
        private RelayCommand _closeModalCommand;
        private RelayCommand _confirmEditCommand;
        private double expectedCarbonDioxide;
        private double expectedHumidity;
        private double expectedTemperature;
        private readonly EditRoomUpdater roomUpdater = new EditRoomUpdater();
        private readonly EditRoomValidator roomValidator = new EditRoomValidator();

        public RoomDetailsEditViewModel()
        {
            roomValidator = new EditRoomValidator();
            roomUpdater = new EditRoomUpdater();
        }

        public double ExpectedTemperature
        {
            get => expectedTemperature;
            set
            {
                expectedTemperature = value;
                OnPropertyChange(nameof(ExpectedTemperature));
            }
        }

        public double ExpectedHumidity
        {
            get => expectedHumidity;
            set
            {
                expectedHumidity = value;
                OnPropertyChange(nameof(ExpectedHumidity));
            }
        }

        public double ExpectedCarbonDioxide
        {
            get => expectedCarbonDioxide;
            set
            {
                expectedCarbonDioxide = value;
                OnPropertyChange(nameof(ExpectedCarbonDioxide));
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
                roomValidator.Validate(ExpectedTemperature, ExpectedHumidity, ExpectedCarbonDioxide);
                roomUpdater.Update(ExpectedTemperature, ExpectedHumidity, ExpectedCarbonDioxide);

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

        public event Action CloseModalEvent;
    }
}