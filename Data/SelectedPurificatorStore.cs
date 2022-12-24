using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedPurificatorStore
    {
        private static SelectedPurificatorStore instance;

        private IPurificator selectedPurificator;

        private SelectedPurificatorStore()
        {
        }

        public IPurificator SelectedPurificator
        {
            get => selectedPurificator;
            set
            {
                selectedPurificator = value;
                SelectedPurificatorChanged?.Invoke();
            }
        }

        public static SelectedPurificatorStore getInstance()
        {
            if (instance == null)
                instance = new SelectedPurificatorStore();
            return instance;
        }

        public event Action SelectedPurificatorChanged;
    }
}