using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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

        public PlotPointsStore PlotPointsStore;
        
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
        private ClimateControlSystemStore _climateControlSystemStore => ClimateControlSystemStore.getInstance();
        
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
                    _selectedViewModelStore.SelectedViewModel = new ConditionerDetailsViewModel();
                }

                if (t == typeof(HumidifierListingItemViewModel))
                {
                    _selectedHumidifierStore.SelectedHumidifier =
                        ((HumidifierListingItemViewModel)_selectedViewModel).Humidifier;
                    _selectedViewModelStore.SelectedViewModel = new HumidifierDetailsViewModel();
                }

                if (t == typeof(PurificatorListingItemViewModel))
                {
                    _selectedPurificatorStore.SelectedPurificator =
                        ((PurificatorListingItemViewModel)_selectedViewModel).Purificator;
                    _selectedViewModelStore.SelectedViewModel = new PurificatorDetailsViewModel();
                }

                OnPropertyChange(nameof(SelectedViewModel));
            }
        }

        public RoomListingItemViewModel(Room room)
        {
            Room = room;
            _conditionerListingItemViewModels = new ObservableCollection<ConditionerListingItemViewModel>();
            _humidifierListingItemViewModels = new ObservableCollection<HumidifierListingItemViewModel>();
            _purificatorListingItemViewModels = new ObservableCollection<PurificatorListingItemViewModel>();
            _climateControlSystemStore.ClimateControlSystemContentsChanged += OnClimateControlSystemContentsChanged; 
            PlotPointsStore = new PlotPointsStore();            
            UpdateListing();
        }

        private void OnClimateControlSystemContentsChanged()
        {
            PlotPointsStore.SeriesCollection[0].Values.Add(Room.TemperatureSensor.Temperature);
            PlotPointsStore.SeriesCollection[1].Values.Add(Room.HumiditySensor.Humidity);  
            PlotPointsStore.SeriesCollection[2].Values.Add(Room.CarbonDioxideSensor.CarbonDioxide);
            
            if (PlotPointsStore.Axis.Count == 0)
                PlotPointsStore.Axis.Add(0); 
            else 
                PlotPointsStore.Axis.Add(PlotPointsStore.Axis.Last() + 1);
            
            PlotPointsStore.PointsContentsChangedInvoke();
        }
        private void UpdateListing()
        {
            _conditionerListingItemViewModels.Clear();
            foreach (var _conditioner in Room.Conditioners)
                _conditionerListingItemViewModels.Add(
                    new ConditionerListingItemViewModel(_conditioner));

            foreach (var _humidifier in Room.Humidifiers)
                _humidifierListingItemViewModels.Add(new HumidifierListingItemViewModel(_humidifier));

            foreach (var _purificator in Room.Purificators)
                _purificatorListingItemViewModels.Add(
                    new PurificatorListingItemViewModel(_purificator));
        }


        public Room Room { get; }

        public string Name => Room.Name;
    }
}