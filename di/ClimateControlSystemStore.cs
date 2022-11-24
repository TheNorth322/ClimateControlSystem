using System;

namespace ClimateControlSystemNamespace
{
    public class ClimateControlSystemStore
    {
        private ClimateControlSystem _climateControlSystem;

        public ClimateControlSystem ClimateControlSystem
        {
            get { return _climateControlSystem; }
            set
            {
                _climateControlSystem = value;
                SelectedClimateControlSystemChanged?.Invoke();
            }
        }
        public event Action SelectedClimateControlSystemChanged;    
    }
}