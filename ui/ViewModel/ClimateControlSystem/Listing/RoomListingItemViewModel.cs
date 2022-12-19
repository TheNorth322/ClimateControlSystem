using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
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
        private RoomListingItemViewModel selectedRoomViewModel;

        public ConditionerListingItemViewModel SelectedConditionerViewModel
        {
            get { return selectedConditionerViewModel; }
            set
            {
                selectedConditionerViewModel = value;
                _selectedConditionerStore.SelectedConditioner = selectedConditionerViewModel.Conditioner;
                _selectedViewModelStore.SelectedViewModel = new ConditionerDetailsViewModel();
                string str = _selectedViewModelStore.SelectedViewModel.GetType().ToString();
                //OnPropertyChange(nameof(SelectedConditionerViewModel));
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
            _conditionerListingItemViewModels = new ObservableCollection<ConditionerListingItemViewModel>();
            _humidifierListingItemViewModels = new ObservableCollection<HumidifierListingItemViewModel>();
            _purificatorListingItemViewModels = new ObservableCollection<PurificatorListingItemViewModel>();
            UpdateListing();
        }

        private void UpdateListing()
        {
            _conditionerListingItemViewModels.Clear();
            foreach (var _conditioner in Room.Conditioners)
                _conditionerListingItemViewModels.Add(new ConditionerListingItemViewModel(_conditioner));
            foreach (var _humidifier in Room.Humidifiers)
                _humidifierListingItemViewModels.Add(new HumidifierListingItemViewModel(_humidifier));
            foreach (var _purificator in Room.Purificators)
                _purificatorListingItemViewModels.Add(new PurificatorListingItemViewModel(_purificator));
        }

        
        public Room Room { get; }

        public string Name => Room.Name;
    }
}