using System;
using System.Windows.Media;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;

namespace ClimateControlSystemNamespace
{
    public class SelectedViewModelStore
    {
        private static SelectedViewModelStore instance;

        private ViewModelBase selectedViewModel;

        private SelectedViewModelStore()
        {
            selectedViewModel = new RoomDetailsViewModel(new PlotPointsStore());
        }

        public ViewModelBase SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                SelectedViewModelChanged?.Invoke();
            }
        }

        public static SelectedViewModelStore getInstance()
        {
            if (instance == null)
                instance = new SelectedViewModelStore();
            return instance;
        }

        public event Action SelectedViewModelChanged;
    }
}