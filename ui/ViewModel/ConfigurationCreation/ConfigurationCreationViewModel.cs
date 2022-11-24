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
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class ConfigurationCreationViewModel : ViewModelBase
    {
        // Validators as fields may be unnecessary
        public ClimateControlSystemValidator ClimateControlSystemValidator { get; }
        public RoomValidator RoomValidator { get; }
        public ClimateControlSystemSerializer ClimateControlSystemSerializer { get; }
        public ClimateControlSystemNamespace.ClimateControlSystem ClimateControlSystem { get; }
        public Room Room { get; set; }
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

           try
           {
               RoomValidator.Validate(Room);
               return true;
           }
           catch (Exception e)
           {
               MessageBox.Show(e.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
               return false;
           }  
        }
        public void AddRoom()
        {
            ClimateControlSystem.Rooms.Add(Room);
        }
        public bool ValidateClimateControlSystem()
        {
           try
           {
               ClimateControlSystemValidator.Validate(ClimateControlSystem);
               return true;
           }
           catch (Exception e)
           {
               MessageBox.Show(e.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
               return false;
           }  
        }
        public void CreateConfiguration() => ClimateControlSystemSerializer.Serialize(ClimateControlSystem);

        public ConfigurationCreationViewModel()
        {
            ClimateControlSystem = new ClimateControlSystemNamespace.ClimateControlSystem();
            ClimateControlSystemSerializer = new ClimateControlSystemSerializer();
            DeviceViewModel = new DeviceConfigurationViewModel();
            RoomViewModel = new RoomConfigurationViewModel();
        }
    }
}