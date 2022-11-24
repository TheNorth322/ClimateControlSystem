using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Input;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class ConfigurationCreationViewModel : ViewModelBase
    {
        public ClimateControlSystemSerializer ClimateControlSystemSerializer { get; }
        public ClimateControlSystemNamespace.ClimateControlSystem ClimateControlSystem { get; }
        public RoomConfigurationViewModel RoomViewModel { get; }
        public DeviceConfigurationViewModel DeviceViewModel { get; }

        private RelayCommand _addRoom;
        private RelayCommand _createConfiguration;

        public RelayCommand AddRoomCommand
        {
            get
            {
                return _addRoom ?? ( _addRoom = new RelayCommand(
                    _object => this.AddRoom(),
                    _object => ValidateRoomConfiguration()
                ));
            }
        }

        public RelayCommand CreateConfigurationCommand
        {
            get
            {
                return _createConfiguration ?? (_createConfiguration = new RelayCommand(
                    _object => this.CreateConfiguration(),
                    _object => ValidateConfigurationCreation()
                    ));
            }
        }

        public void CreateConfiguration() => ClimateControlSystemSerializer.Serialize(ClimateControlSystem);
        public bool ValidateConfigurationCreation() => (ClimateControlSystem.Rooms.Count == 0) ? false : true;
        public void AddRoom()
        {
            Room _room = new Room(
                RoomViewModel.Name,
                RoomViewModel.Area,
                RoomViewModel.Height,
                RoomViewModel.LightLevel,
                new Conditioner(DeviceViewModel.ConditionerStatus, DeviceViewModel.ConditionerAirFlow,
                    DeviceViewModel.ConditionerMode, 24),
                new Humidifier(DeviceViewModel.HumidifierWaterConsumption, DeviceViewModel.HumidifierStatus),
                new Purificator(DeviceViewModel.PurificatorAirFlow, DeviceViewModel.PurificatorStatus),
                new TemperatureSensor(RoomViewModel.Temperature),
                new HumiditySensor(RoomViewModel.Humidity),
                new CarbonDioxideSensor(RoomViewModel.CarbonDioxideLevel));

            ClimateControlSystem.Rooms.Add(_room);
        }
       
        bool ValidateRoomConfiguration()
        {
            if (RoomViewModel.Area <= 0 ||
                RoomViewModel.Height <= 0 ||
                String.IsNullOrWhiteSpace(RoomViewModel.Name) ||
                RoomViewModel.Humidity <= 0 ||
                RoomViewModel.CarbonDioxideLevel <= 0)
                return false;
            return true;
        }

        public ConfigurationCreationViewModel()
        {
            ClimateControlSystem = new ClimateControlSystemNamespace.ClimateControlSystem();
            ClimateControlSystemSerializer = new ClimateControlSystemSerializer();
            DeviceViewModel = new DeviceConfigurationViewModel();
            RoomViewModel = new RoomConfigurationViewModel();
        }
    }
}