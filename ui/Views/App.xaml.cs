using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystem.ui.Views;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedRoomStore _selectedRoomStore;
        
        public App()
        {
            _selectedRoomStore = new SelectedRoomStore();
            ClimateControlSystemSerializer t = new ClimateControlSystemSerializer();
            ClimateControlSystem sys = new ClimateControlSystem(new List<Room>());
            sys.Rooms.Add( new Room(
                "Kitchen",
                20,
                20,
                LightLevel.AverageIllumination,
                new Conditioner(true, 20, ConditionerMode.Cooling, 11),
                new Humidifier(12, true),
                new Purificator(12, true),
                new TemperatureSensor(20),
                new HumiditySensor(20),
                new CarbonDioxideSensor(20)));
            t.Serialize(sys);
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new ConfigurationCreationView()
            {
                DataContext = new ConfigurationCreationView()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
