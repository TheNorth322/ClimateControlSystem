using System;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;

namespace ClimateControlSystemNamespace
{
    public class EditViewModelStore
    {
        private static EditViewModelStore instance;

        private ViewModelBase editViewModel;

        private EditViewModelStore()
        {
            editViewModel = new ConditionerDetailsEditViewModel();
        }

        public ViewModelBase EditViewModel
        {
            get => editViewModel;
            set
            {
                editViewModel = value;
                EditViewModelChanged?.Invoke();
            }
        }

        public static EditViewModelStore getInstance()
        {
            if (instance == null)
                instance = new EditViewModelStore();
            return instance;
        }

        public void CloseModal()
        {
            CloseModalEvent?.Invoke();
        }

        public event Action CloseModalEvent;
        public event Action EditViewModelChanged;
    }
}