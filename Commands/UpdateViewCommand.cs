using System;
using System.Windows.Input;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private SelectedViewModelStore selectedViewModelStore => SelectedViewModelStore.getInstance();
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Room":
                    selectedViewModelStore.SelectedViewModel = new RoomDetailsViewModel();
                    break;
                case "Conditioner":
                    selectedViewModelStore.SelectedViewModel = new ConditionerDetailsViewModel();
                    break;
                case "Humidifier":
                    selectedViewModelStore.SelectedViewModel = new HumidifierDetailsViewModel();
                    break;
                case "Purificator":
                    selectedViewModelStore.SelectedViewModel = new PurificatorDetailsViewModel();
                    break;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}