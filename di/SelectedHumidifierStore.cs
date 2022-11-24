using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedHumidifierStore
    {
        
        private Humidifier _selectedHumidifier;

        public Humidifier SelectedHumidifier
        {
            get { return _selectedHumidifier; }
            set
            {
                _selectedHumidifier = value;
                SelectedHumidifierChanged?.Invoke();
            }
        }

        public event Action SelectedHumidifierChanged;    
    }
}