using System;
using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel.EnterConfigurationPath;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class ConfigurationCreationViewModel : ViewModelBase, ICloseWindows
    {
        private readonly ClimateControlSystemNamespace.ClimateControlSystem ClimateControlSystem =
            ClimateControlSystemStore.getInstance().ClimateControlSystem;

        private RelayCommand _addRoom;
        private RelayCommand _createConfiguration;
        private string _passCode;
        private string _path;

        public ConfigurationCreationViewModel()
        {
            ClimateControlSystem = new ClimateControlSystemNamespace.ClimateControlSystem();
            ClimateControlSystemSerializer = new ClimateControlSystemSerializer();
            DeviceViewModel = new DeviceConfigurationViewModel();
            RoomViewModel = new RoomConfigurationViewModel();
            roomStore.RoomChanged += RoomStore_RoomChanged;
            DeviceViewModel.RoomStore_RoomDevicesChanged += RoomStore_RoomChanged;
        }

        private RoomStore roomStore => RoomStore.getInstance();

        private ClimateControlSystemSerializer ClimateControlSystemSerializer { get; }

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

        protected override void Dispose()
        {
            roomStore.RoomChanged -= RoomStore_RoomChanged;
            DeviceViewModel.RoomStore_RoomDevicesChanged -= RoomStore_RoomChanged;
            base.Dispose();
        }


        private bool ValidateRoom()
        {
            // TODO
            return true;
        }

        private void AddRoom()
        {
            try
            {
                AddRoomData();
                RoomValidator.Validate(roomStore.Room);
                ClimateControlSystem.AddRoom(roomStore.Room);
                roomStore.Clear();
            }
            catch (Exception e)
            {
                MessageBox_Show(null, e.Message, "Error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateClimateControlSystem()
        {
            return !string.IsNullOrWhiteSpace(Path)
                   && !string.IsNullOrWhiteSpace(PassCode)
                   && ClimateControlSystem.Rooms.Count != 0;
        }

        private void AddRoomData()
        {
            roomStore.Room.Area = RoomViewModel.Area;
            roomStore.Room.Name = RoomViewModel.Name;
            roomStore.Room.CeilingHeight = RoomViewModel.Height;
            roomStore.Room.LightLevel = RoomViewModel.LightLevel;
            roomStore.Room.TemperatureSensor.Temperature = RoomViewModel.Temperature;
            roomStore.Room.CarbonDioxideSensor.CarbonDioxide = RoomViewModel.CarbonDioxideLevel;
            roomStore.Room.HumiditySensor.Humidity = RoomViewModel.Humidity;
        }

        private void RoomStore_RoomChanged()
        {
            OnPropertyChange(nameof(roomStore));
        }

        private void CreateConfiguration()
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