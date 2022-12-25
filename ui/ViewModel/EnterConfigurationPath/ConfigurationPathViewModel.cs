using System;
using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.EnterConfigurationPath
{
    public class ConfigurationPathViewModel : ViewModelBase, ICloseWindows
    {
        private string _configurationPath;

        private RelayCommand _createConfiguration;

        private RelayCommand _loadConfiguration;

        public string ConfigurationPath
        {
            get => _configurationPath;
            set
            {
                _configurationPath = value;
                OnPropertyChange(nameof(ConfigurationPath));
            }
        }

        public RelayCommand LoadConfigurationCommand
        {
            get
            {
                return _loadConfiguration ?? (_loadConfiguration = new RelayCommand(
                    _object => LoadConfiguration(),
                    _object => ValidateConfigurationPath()
                ));
            }
        }

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

        public Action Close { get; set; }

        private void CreateConfiguration()
        {
            var view = new ConfigurationCreationView();
            view.Show();
            Close?.Invoke();
        }

        private void LoadConfiguration()
        {
            try
            {
                ConfigurationPathStore.getInstance().Path = ConfigurationPath;
                var serializer = new ClimateControlSystemSerializer();
                ClimateControlSystemStore.getInstance().ClimateControlSystem =
                    serializer.Deserialize(ConfigurationPath);
                var view = new LogInView();
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
            return !string.IsNullOrEmpty(ConfigurationPath) && ConfigurationPath.Contains(".xml");
        }
    }
}