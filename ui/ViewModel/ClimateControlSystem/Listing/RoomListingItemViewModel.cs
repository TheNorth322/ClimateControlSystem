using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using ClimateControlSystem.Commands;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class RoomListingItemViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ConditionerListingItemViewModel> _conditionerListingItemViewModels;

        public IEnumerable<ConditionerListingItemViewModel> ConditionerListingItemViewModels =>
            _conditionerListingItemViewModels;

        private readonly ObservableCollection<HumidifierListingItemViewModel> _humidifierListingItemViewModels;

        public IEnumerable<HumidifierListingItemViewModel> HumidifierListingItemViewModels =>
            _humidifierListingItemViewModels;

        private readonly ObservableCollection<PurificatorListingItemViewModel> _purificatorListingItemViewModels;

        public IEnumerable<PurificatorListingItemViewModel> PurificatorListingItemViewModels =>
            _purificatorListingItemViewModels;

        private SelectedConditionerStore _selectedConditionerStore => SelectedConditionerStore.getInstance();
        private SelectedHumidifierStore _selectedHumidifierStore => SelectedHumidifierStore.getInstance();
        private SelectedPurificatorStore _selectedPurificatorStore => SelectedPurificatorStore.getInstance();
        private SelectedViewModelStore _selectedViewModelStore => SelectedViewModelStore.getInstance();
        
        private ConditionerListingItemViewModel selectedConditionerViewModel;
        private HumidifierListingItemViewModel selectedHumidifierViewModel;
        private PurificatorListingItemViewModel selectedPurificatorViewModel;

        public ConditionerListingItemViewModel SelectedConditionerViewModel
        {
            get { return selectedConditionerViewModel; }
            set
            {
                selectedConditionerViewModel = value;
                _selectedViewModelStore.SelectedViewModel = new ConditionerDetailsViewModel();
                _selectedConditionerStore.SelectedConditioner = selectedConditionerViewModel.Conditioner;
                OnPropertyChange(nameof(SelectedConditionerViewModel));
            }
        }

        public HumidifierListingItemViewModel SelectedHumidifierViewModel
        {
            get { return selectedHumidifierViewModel; }
            set
            {
                selectedHumidifierViewModel = value;
                _selectedViewModelStore.SelectedViewModel = new HumidifierDetailsViewModel();
                _selectedHumidifierStore.SelectedHumidifier = selectedHumidifierViewModel.Humidifier;
                OnPropertyChange(nameof(SelectedHumidifierViewModel));
            }
        }

        public PurificatorListingItemViewModel SelectedPurificatorViewModel
        {
            get { return selectedPurificatorViewModel; }
            set
            {
                selectedPurificatorViewModel = value;
                _selectedViewModelStore.SelectedViewModel = new PurificatorDetailsViewModel();
                _selectedPurificatorStore.SelectedPurificator = selectedPurificatorViewModel.Purificator;
                OnPropertyChange(nameof(SelectedPurificatorViewModel));
            }
        }

        public RoomListingItemViewModel(Room room)
        {
            Room = room;
        }

        public Room Room { get; }

        public string Name => Room.Name;
    }
}