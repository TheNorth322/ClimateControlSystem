using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel.EnterConfigurationPath;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class ConfigurationCreationViewModel : ViewModelBase, ICloseWindows
    {
        // Validators as fields may be unnecessary
        public ClimateControlSystemValidator ClimateControlSystemValidator { get; }
        public RoomValidator RoomValidator { get; }
        public ClimateControlSystemSerializer ClimateControlSystemSerializer { get; }
        public ClimateControlSystemNamespace.ClimateControlSystem ClimateControlSystem { get; }
        public Room Room { get; set; }
        private string _path;

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChange(nameof(Path));
            }
        }

        private string _passCode;

        public string PassCode
        {
            get { return _passCode; }
            set
            {
                _passCode = value;
                OnPropertyChange(nameof(PassCode));
            }
        }
        public RoomConfigurationViewModel RoomViewModel { get; }
        public DeviceConfigurationViewModel DeviceViewModel { get; }

        private RelayCommand _addRoom;
        private RelayCommand _createConfiguration;

        public RelayCommand AddRoomCommand
        {
            get
            {
                return _addRoom ?? (_addRoom = new RelayCommand(
                    _object => this.AddRoom(),
                    _object => this.ValidateRoom()
                ));
            }
        }

        public RelayCommand CreateConfigurationCommand
        {
            get
            {
                return _createConfiguration ?? (_createConfiguration = new RelayCommand(
                    _object => this.CreateConfiguration(),
                    _object => this.ValidateClimateControlSystem()
                ));
            }
        }

        public bool ValidateRoom()
        {
            // TODO
            return true;
        }

        public void AddRoom()
        {
            try
            {
                Room = new Room(
                    RoomViewModel.Name,
                    RoomViewModel.Area,
                    RoomViewModel.Height,
                    RoomViewModel.LightLevel,
                    new Conditioner(DeviceViewModel.ConditionerStatus, DeviceViewModel.ConditionerAirFlow,
                        DeviceViewModel.ConditionerMode, 24),
                    new Humidifier(DeviceViewModel.HumidifierStatus, DeviceViewModel.HumidifierWaterConsumption,
                        60),
                    new Purificator(DeviceViewModel.PurificatorStatus, DeviceViewModel.PurificatorAirFlow, 60),
                    new TemperatureSensor(RoomViewModel.Temperature),
                    new HumiditySensor(RoomViewModel.Humidity),
                    new CarbonDioxideSensor(RoomViewModel.CarbonDioxideLevel));

                RoomValidator.Validate(Room);
                ClimateControlSystem.Rooms.Add(Room);
            }
            catch (Exception e)
            {
                MessageBox_Show(null, e.Message, "Error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool ValidateClimateControlSystem()
        {
            return (!String.IsNullOrWhiteSpace(Path));
        }

        public void CreateConfiguration()
        {
            try
            {
                PasswordHash hash = new PasswordHash(PassCode);
                ClimateControlSystem.PassCode = hash.ToArray();
                ClimateControlSystemValidator.Validate(ClimateControlSystem);
                ClimateControlSystemSerializer.Serialize(ClimateControlSystem, Path);
                ConfigurationPathView view = new ConfigurationPathView
                {
                    DataContext = new ConfigurationPathViewModel()
                };
                view.Show();
                Close?.Invoke();
            }
            catch (Exception e)
            {
                MessageBox_Show(null, e.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ConfigurationCreationViewModel()
        {
            ClimateControlSystem = new ClimateControlSystemNamespace.ClimateControlSystem();
            ClimateControlSystemSerializer = new ClimateControlSystemSerializer();
            DeviceViewModel = new DeviceConfigurationViewModel();
            RoomViewModel = new RoomConfigurationViewModel();
            ClimateControlSystemValidator = new ClimateControlSystemValidator();
            RoomValidator = new RoomValidator();
        }

        public Action Close { get; set; }
    }
}