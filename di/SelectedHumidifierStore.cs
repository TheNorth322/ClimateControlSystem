using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedHumidifierStore
    {
        private static SelectedHumidifierStore instance;

        private Humidifier selectedHumidifier;
        public int SelectedHumidifierIndex { get; set; }
        private SelectedHumidifierStore()
        {
        }

        public Humidifier SelectedHumidifier
        {
            get => selectedHumidifier;
            set
            {
                selectedHumidifier = value;
                SelectedHumidifierChanged?.Invoke();
            }
        }

        public static SelectedHumidifierStore getInstance()
        {
            if (instance == null)
                instance = new SelectedHumidifierStore();
            return instance;
        }

        public event Action SelectedHumidifierChanged;
    }
}