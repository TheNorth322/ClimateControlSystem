using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystem.ui.ViewModel.EnterConfigurationPath;
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
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new ConfigurationPathView()
            {
                DataContext = new ConfigurationPathViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
