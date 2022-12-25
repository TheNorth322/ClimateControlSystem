using System;

namespace ClimateControlSystemNamespace
{
    public class ClimateControlSystemStore
    {
        private static ClimateControlSystemStore instance;
        private ClimateControlSystem _climateControlSystem;

        private ClimateControlSystemStore()
        {
        }

        public ClimateControlSystem ClimateControlSystem
        {
            get => _climateControlSystem;
            set
            {
                _climateControlSystem = value;
                ClimateControlSystemChanged?.Invoke();
            }
        }

        public static ClimateControlSystemStore getInstance()
        {
            if (instance == null)
                instance = new ClimateControlSystemStore();
            return instance;
        }

        public void ClimateControlSystemContentsChangedInvoke()
        {
            ClimateControlSystemContentsChanged?.Invoke();
        }

        public event Action ClimateControlSystemContentsChanged;
        public event Action ClimateControlSystemChanged;
    }
}