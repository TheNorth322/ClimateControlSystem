using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
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

        public RelayCommand LoadConfiguration
        {
            get
            {
                WindowService.CreateWindow createWindow = delegate()
                {
                    ClimateControlSystemSerializer serializer = new ClimateControlSystemSerializer();
                    ClimateControlSystemView view = new ClimateControlSystemView
                    {
                        DataContext = new ClimateControlSystemViewModel(new SelectedRoomStore(),
                            serializer.Deserialize(ConfigurationPath))
                    };
                    view.Show();
                    Close?.Invoke();
                };

                return _createConfiguration ?? (_createConfiguration = new RelayCommand(
                    _object =>
                    {
                        ClimateControlSystemSerializer serializer = new ClimateControlSystemSerializer();
                        ClimateControlSystemView view = new ClimateControlSystemView
                        {
                            DataContext = new ClimateControlSystemViewModel(new SelectedRoomStore(),
                                serializer.Deserialize(ConfigurationPath))
                        };
                        view.Show();
                        Close?.Invoke();
                    },
                    _object => this.ValidateConfigurationPath()
                ));
            }
        }

        private RelayCommand _createConfiguration;

        public RelayCommand CreateConfiguration
        {
            get
            {
                WindowService.CreateWindow createWindow = delegate()
                {
                    ConfigurationCreationView view = new ConfigurationCreationView();
                    view.Show();
                    Close?.Invoke();
                };

                return _createConfiguration ?? (_createConfiguration = new RelayCommand(
                    _object => createWindow(),
                    _object => true
                ));
            }
        }

        public bool ValidateConfigurationPath()
        {
            return !String.IsNullOrEmpty(ConfigurationPath);
        }

        public Action Close { get; set; }
    }
}