using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedPurificatorStore
    {
        
        private Purificator _selectedPurificator;

        public Purificator SelectedPurificator
        {
            get { return _selectedPurificator; }
            set
            {
                _selectedPurificator = value;
                SelectedPurificatorChanged?.Invoke();
            }
        }

        public event Action SelectedPurificatorChanged;
    }
}