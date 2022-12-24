using System;

namespace ClimateControlSystemNamespace
{
    public class ConfigurationPathStore
    {
        private static ConfigurationPathStore instance;

        private string _path;

        private ConfigurationPathStore()
        {
        }

        public string Path 
        {
            get => _path;
            set
            {
                _path = value;
                ConfigurationPathChanged?.Invoke();
            }
        }

        public static ConfigurationPathStore getInstance()
        {
            if (instance == null)
                instance = new ConfigurationPathStore();
            return instance;
        }

        public event Action ConfigurationPathChanged;
    }
}