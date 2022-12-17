using System;
using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class DeviceConfigurationViewModel : ViewModelBase
    {
        private RelayCommand _addConditioner;
        private RelayCommand _addHumidifier;
        private RelayCommand _addPurificator;
        private double _conditionerAirFlow;
        private ConditionerMode _conditionerMode;
        private bool _conditionerStatus;
        private double _conditionerTemperature;
        private bool _humidifierStatus;
        private double _humidifierWaterConsumption;
        private double _purificatorAirFlow;
        private bool _purificatorStatus;
        private Room Room = RoomStore.getInstance().Room;

        public DeviceConfigurationViewModel()
        {
            HumidifierStatus = true;
            PurificatorStatus = true;
            ConditionerStatus = true;
            ConditionerMode = ConditionerMode.Cooling;
        }

        public double HumidifierWaterConsumption
        {
            get => _humidifierWaterConsumption;
            set
            {
                _humidifierWaterConsumption = value;
                OnPropertyChange(nameof(HumidifierWaterConsumption));
            }
        }

        public bool HumidifierStatus
        {
            get => _humidifierStatus;
            set
            {
                _humidifierStatus = value;
                OnPropertyChange(nameof(HumidifierStatus));
            }
        }

        public double PurificatorAirFlow
        {
            get => _purificatorAirFlow;
            set
            {
                _purificatorAirFlow = value;
                OnPropertyChange(nameof(PurificatorAirFlow));
            }
        }

        public bool PurificatorStatus
        {
            get => _purificatorStatus;
            set
            {
                _purificatorStatus = value;
                OnPropertyChange(nameof(PurificatorStatus));
            }
        }

        public double ConditionerAirFlow
        {
            get => _conditionerAirFlow;
            set
            {
                _conditionerAirFlow = value;
                OnPropertyChange(nameof(ConditionerAirFlow));
            }
        }

        public double ConditionerTemperature
        {
            get => _conditionerTemperature;
            set
            {
                _conditionerTemperature = value;
                OnPropertyChange(nameof(ConditionerTemperature));
            }
        }

        public bool ConditionerStatus
        {
            get => _conditionerStatus;
            set
            {
                _conditionerStatus = value;
                OnPropertyChange(nameof(ConditionerStatus));
            }
        }

        public ConditionerMode ConditionerMode
        {
            get => _conditionerMode;
            set
            {
                _conditionerMode = value;
                OnPropertyChange(nameof(ConditionerMode));
            }
        }


        public RelayCommand AddConditionerCommand
        {
            get
            {
                return _addConditioner ?? (_addConditioner = new RelayCommand(
                    _object => this.AddConditioner(),
                    _object => this.ValidateConditioner()
                ));
            }
        }

        public RelayCommand AddHumidifierCommand
        {
            get
            {
                return _addHumidifier ?? (_addHumidifier = new RelayCommand(
                    _object => this.AddHumidifier(),
                    _object => this.ValidateHumidifier()
                ));
            }
        }

        public RelayCommand AddPurificatorCommand
        {
            get
            {
                return _addPurificator ?? (_addPurificator = new RelayCommand(
                    _object => this.AddPurificator(),
                    _object => this.ValidatePurificator()
                ));
            }
        }

        private void AddConditioner()
        {
            try
            {
                Conditioner conditioner = new Conditioner(ConditionerStatus, ConditionerAirFlow, ConditionerMode,
                    ConditionerTemperature);
                ConditionerValidator.Validate(conditioner);
                Room.Conditioners.Add(conditioner);
            }
            catch (Exception ex)
            {
                MessageBox_Show(null, ex.Message, "Error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddHumidifier()
        {
            try
            {
                Humidifier humidifier = new Humidifier(HumidifierStatus, HumidifierWaterConsumption, 60);
                HumidifierValidator.Validate(humidifier);
                Room.Humidifiers.Add(humidifier);
            }
            catch (Exception ex)
            {
                MessageBox_Show(null, ex.Message, "Error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPurificator()
        {
            try
            {
                Purificator purificator = new Purificator(PurificatorStatus, PurificatorAirFlow, 600);
                PurificatorValidator.Validate(purificator);
                Room.Purificators.Add(purificator);
            }
            catch (Exception ex)
            {
                MessageBox_Show(null, ex.Message, "Error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateConditioner()
        {
            // For change
            return true;
        }

        private bool ValidateHumidifier()
        {
            return true;
        }

        private bool ValidatePurificator()
        {
            return true;
        }
    }
}