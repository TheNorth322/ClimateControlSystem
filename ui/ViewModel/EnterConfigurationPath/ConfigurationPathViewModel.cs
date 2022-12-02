using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystem.ui.ViewModel.ConfigurationCreation;
using ClimateControlSystem.ui.ViewModel.LogIn;
using ClimateControlSystem.ui.Views;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.EnterConfigurationPath
{
    public class ConfigurationPathViewModel : ViewModelBase, ICloseWindows
    {
        private string _configurationPath;

        public string ConfigurationPath
        {
            get { return _configurationPath; }
            set
            {
                _configurationPath = value;
                OnPropertyChange(nameof(ConfigurationPath));
            }
        }

        private RelayCommand _loadConfiguration;

        public RelayCommand LoadConfigurationCommand
        {
            get
            {
                return _loadConfiguration ?? (_loadConfiguration = new RelayCommand(
                    _object => LoadConfiguration(),
                    _object => this.ValidateConfigurationPath()
                ));
            }
        }

        private RelayCommand _createConfiguration;

        public RelayCommand CreateConfigurationCommand
        {
            get
            {
                return _createConfiguration ?? (_createConfiguration = new RelayCommand(
                    _object => CreateConfiguration(),
                    _object => true
                ));
            }
        }

        private void CreateConfiguration()
        {
            ConfigurationCreationView view = new ConfigurationCreationView
            {
                DataContext = new ConfigurationCreationViewModel()
            };
            view.Show();
            Close?.Invoke();
        }

        private void LoadConfiguration()
        {
            try
            {
                ClimateControlSystemSerializer serializer = new ClimateControlSystemSerializer();
                LogInView view = new LogInView(serializer.Deserialize(ConfigurationPath));
                view.Show();
                Close?.Invoke();
            }
            catch (Exception e)
            {
                MessageBox_Show(null, e.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool ValidateConfigurationPath()
        {
            return !String.IsNullOrEmpty(ConfigurationPath);
        }

        public Action Close { get; set; }
    }
}