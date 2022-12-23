using System;
using ClimateControlSystem.Domain;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.DeviceEditViewModels
{
    public class RoomDetailsEditViewModel : ViewModelBase
    {
        private double expectedTemperature;
        private double expectedHumidity;
        private double expectedCarbonDioxide;
        private RelayCommand _confirmEditCommand;
        private EditRoomValidator roomValidator = new EditRoomValidator();
        private EditRoomUpdater roomUpdater = new EditRoomUpdater();

        private RelayCommand _closeModalCommand;
        public int RoomIndex { get; set; }

        public RoomDetailsEditViewModel()
        {
            roomValidator = new EditRoomValidator();
            roomUpdater = new EditRoomUpdater();
        }

        public RoomDetailsEditViewModel(int _roomIndex)
        {
            roomValidator = new EditRoomValidator();
            roomUpdater = new EditRoomUpdater();
            RoomIndex = _roomIndex;
        }

        public double ExpectedTemperature
        {
            get { return expectedTemperature; }
            set
            {
                expectedTemperature = value;
                OnPropertyChange(nameof(ExpectedTemperature));
            }
        }

        public double ExpectedHumidity
        {
            get { return expectedHumidity; }
            set
            {
                expectedHumidity = value;
                OnPropertyChange(nameof(ExpectedHumidity));
            }
        }

        public double ExpectedCarbonDioxide
        {
            get { return expectedCarbonDioxide; }
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
                roomUpdater.Update(ExpectedTemperature, ExpectedHumidity, ExpectedCarbonDioxide, RoomIndex);

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