using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using ClimateControlSystem.Commands;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ClimateControlSystemViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RoomListingItemViewModel> _roomListingItemViewModels;
        private SelectedRoomStore _selectedRoomStore;
        private SelectedViewModelStore _selectedViewModelStore; 
        
        private string _currentDate;
        private string _currentTime;

        private RoomListingItemViewModel selectedRoomListingItemViewModel;

        private ViewModelBase selectedViewModel => _selectedViewModelStore.SelectedViewModel;

        public ClimateControlSystemViewModel(SelectedRoomStore selectedRoomStore)
        {
            _selectedRoomStore = selectedRoomStore;
            _roomListingItemViewModels = new ObservableCollection<RoomListingItemViewModel>();
            UpdateListing();
            _selectedViewModelStore.SelectedViewModelChanged += SelectedViewModelStore_SelectedViewModelChanged;            
            var LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        protected override void Dispose()
        {
            _selectedViewModelStore.SelectedViewModelChanged -= SelectedViewModelStore_SelectedViewModelChanged;
            base.Dispose();
        } 
        private void SelectedViewModelStore_SelectedViewModelChanged()
        {
            OnPropertyChange(nameof(selectedViewModel));
        }
        public IEnumerable<RoomListingItemViewModel> RoomListingItemViewModels => _roomListingItemViewModels;

        public RoomListingItemViewModel SelectedRoomListingItemViewModel
        {
            get => selectedRoomListingItemViewModel;
            set
            {
                selectedRoomListingItemViewModel = value;
                _selectedViewModelStore.SelectedViewModel = new RoomDetailsViewModel();
                _selectedRoomStore.SelectedRoom = selectedRoomListingItemViewModel.Room;
                OnPropertyChange(nameof(SelectedRoomListingItemViewModel));
            }
        }

        public string CurrentTime
        {
            get => _currentTime;
            set
            {
                _currentTime = value;
                OnPropertyChange(nameof(CurrentTime));
            }
        }

        public string CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChange(nameof(CurrentDate));
            }
        }

        private void UpdateListing()
        {
            _roomListingItemViewModels.Clear();
            foreach (var _room in ClimateControlSystemStore.getInstance().ClimateControlSystem.Rooms)
                _roomListingItemViewModels.Add(new RoomListingItemViewModel(_room));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}