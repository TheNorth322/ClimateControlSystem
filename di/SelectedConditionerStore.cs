using System;

namespace ClimateControlSystemNamespace
{
    public class SelectedConditionerStore
    {
        private static SelectedConditionerStore instance;

        private Conditioner selectedConditioner;

        private SelectedConditionerStore()
        {
        }

        public Conditioner SelectedConditioner
        {
            get => selectedConditioner;
            set
            {
                selectedConditioner = value;
                SelectedConditionerChanged?.Invoke();
            }
        }

        public static SelectedConditionerStore getInstance()
        {
            if (instance == null)
                instance = new SelectedConditionerStore();
            return instance;
        }

        public event Action SelectedConditionerChanged;
    }
}