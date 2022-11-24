using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedConditionerStore
    {
        
        private Conditioner _selectedConditioner;

        public Conditioner SelectedConditioner
        {
            get { return _selectedConditioner; }
            set
            {
                _selectedConditioner = value;
                SelectedConditionerChanged?.Invoke();
            }
        }

        public event Action SelectedConditionerChanged;    
    }
}