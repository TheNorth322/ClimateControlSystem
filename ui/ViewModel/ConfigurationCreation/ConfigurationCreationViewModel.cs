using System;
using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel.EnterConfigurationPath;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class ConfigurationCreationViewModel : ViewModelBase, ICloseWindows
    {
        private RelayCommand _addRoom;
        private RelayCommand _createConfiguration;

        private string _passCode;
        private string _path;
        private Room Room = RoomStore.getInstance().Room;
        private readonly ClimateControlSystemNamespace.ClimateControlSystem ClimateControlSystem =
            ClimateControlSystemStore.getInstance().ClimateControlSystem;

        public ConfigurationCreationViewModel()
        {
            ClimateControlSystem = new ClimateControlSystemNamespace.ClimateControlSystem();
            ClimateControlSystemSerializer = new ClimateControlSystemSerializer();
            DeviceViewModel = new DeviceConfigurationViewModel();
            RoomViewModel = new RoomConfigurationViewModel();
        }

        public ClimateControlSystemSerializer ClimateControlSystemSerializer { get; }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChange(nameof(Path));
            }
        }

        public string PassCode
        {
            get => _passCode;
            set
            {
                _passCode = value;
                OnPropertyChange(nameof(PassCode));
            }
        }

        public RoomConfigurationViewModel RoomViewModel { get; }
        public DeviceConfigurationViewModel DeviceViewModel { get; }

        public RelayCommand AddRoomCommand
        {
            get
            {
                return _addRoom ?? (_addRoom = new RelayCommand(
                    _object => AddRoom(),
                    _object => ValidateRoom()
                ));
            }
        }

        public RelayCommand CreateConfigurationCommand
        {
            get
            {
                return _createConfiguration ?? (_createConfiguration = new RelayCommand(
                    _object => CreateConfiguration(),
                    _object => ValidateClimateControlSystem()
                ));
            }
        }

        public Action Close { get; set; }


        public bool ValidateRoom()
        {
            // TODO
            return true;
        }

        public void AddRoom()
        {
            try
            {
                AddRoomData();
                RoomValidator.Validate(Room);
                ClimateControlSystem.Rooms.Add(Room);
                RoomStore.getInstance().Clear();
            }
            catch (Exception e)
            {
                MessageBox_Show(null, e.Message, "Error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool ValidateClimateControlSystem()
        {
            return !string.IsNullOrWhiteSpace(Path) && !string.IsNullOrWhiteSpace(PassCode);
        }

        public void AddRoomData()
        {
            Room.Area = RoomViewModel.Area;
            Room.Name = RoomViewModel.Name;
            Room.CeilingHeight = RoomViewModel.Height;
            Room.LightLevel = RoomViewModel.LightLevel;
            Room.TemperatureSensor.Temperature = RoomViewModel.Temperature;
            Room.CarbonDioxideSensor.CarbonDioxide = RoomViewModel.CarbonDioxideLevel;
            Room.HumiditySensor.Humidity = RoomViewModel.Humidity;
        }
        public void CreateConfiguration()
        {
            try
            {
                var hash = new PasswordHash(PassCode);
                ClimateControlSystem.PassCode = hash.ToArray();
                ClimateControlSystemValidator.Validate(ClimateControlSystem);
                ClimateControlSystemSerializer.Serialize(ClimateControlSystem, Path);
                var view = new ConfigurationPathView
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
    }
}