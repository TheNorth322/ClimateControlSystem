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
        
        private SelectedRoomStore _selectedRoomStore => SelectedRoomStore.getInstance();
        private SelectedConditionerStore _selectedConditionerStore => SelectedConditionerStore.getInstance();
        private SelectedHumidifierStore _selectedHumidifierStore => SelectedHumidifierStore.getInstance();
        private SelectedPurificatorStore _selectedPurificatorStore => SelectedPurificatorStore.getInstance();
        private SelectedViewModelStore _selectedViewModelStore => SelectedViewModelStore.getInstance();

        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }

            set
            {
                _selectedViewModel = value;
                Type t = _selectedViewModel.GetType();
                if (t == typeof(ConditionerListingItemViewModel))
                {
                    _selectedConditionerStore.SelectedConditioner =
                        ((ConditionerListingItemViewModel)_selectedViewModel).Conditioner;
                    _selectedConditionerStore.SelectedConditionerIndex = 
                        ((ConditionerListingItemViewModel)_selectedViewModel).ConditionerIndex;
                    _selectedViewModelStore.SelectedViewModel = new ConditionerDetailsViewModel(RoomIndex);
                }

                if (t == typeof(HumidifierListingItemViewModel))
                {
                    _selectedHumidifierStore.SelectedHumidifier =
                        ((HumidifierListingItemViewModel)_selectedViewModel).Humidifier;
                    _selectedHumidifierStore.SelectedHumidifierIndex =
                        ((HumidifierListingItemViewModel)_selectedViewModel).HumidifierIndex;
                    
                    _selectedViewModelStore.SelectedViewModel = new HumidifierDetailsViewModel();
                }

                if (t == typeof(PurificatorListingItemViewModel))
                {
                    _selectedPurificatorStore.SelectedPurificator =
                        ((PurificatorListingItemViewModel)_selectedViewModel).Purificator;
                    _selectedPurificatorStore.SelectedPurificatorIndex =
                        ((PurificatorListingItemViewModel)_selectedViewModel).PurificatorIndex;
                    
                    _selectedViewModelStore.SelectedViewModel = new PurificatorDetailsViewModel();
                }

                OnPropertyChange(nameof(SelectedViewModel));
            }
        }

        public int RoomIndex { get; set; }

        public RoomListingItemViewModel(Room room, int _roomIndex)
        {
            Room = room;
            RoomIndex = _roomIndex;
            _conditionerListingItemViewModels = new ObservableCollection<ConditionerListingItemViewModel>();
            _humidifierListingItemViewModels = new ObservableCollection<HumidifierListingItemViewModel>();
            _purificatorListingItemViewModels = new ObservableCollection<PurificatorListingItemViewModel>();
            UpdateListing();
        }

        private void UpdateListing()
        {
            _conditionerListingItemViewModels.Clear();
            int conditionerIndex = 0, humidifierIndex = 0, purificatorIndex = 0;
            foreach (var _conditioner in Room.Conditioners)
            {
                _conditionerListingItemViewModels.Add(
                    new ConditionerListingItemViewModel(_conditioner, conditionerIndex, RoomIndex));
                conditionerIndex++;
            }

            foreach (var _humidifier in Room.Humidifiers)
            {
                _humidifierListingItemViewModels.Add(new HumidifierListingItemViewModel(_humidifier, humidifierIndex, RoomIndex));
                humidifierIndex++;
            }

            foreach (var _purificator in Room.Purificators)
            {
                _purificatorListingItemViewModels.Add(
                    new PurificatorListingItemViewModel(_purificator, purificatorIndex, RoomIndex));
                purificatorIndex++;
            }
        }


        public Room Room { get; }

        public string Name => Room.Name;
    }
}