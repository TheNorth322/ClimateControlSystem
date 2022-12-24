using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ClimateControlSystemViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RoomListingItemViewModel> _roomListingItemViewModels;
        private SelectedRoomStore _selectedRoomStore => SelectedRoomStore.getInstance();
        private EditViewModelStore _editViewModalStore => EditViewModelStore.getInstance();
        private SelectedViewModelStore _selectedViewModelStore => SelectedViewModelStore.getInstance();
        private ClimateControlSystemUpdater climateControlSystemUpdater = new ClimateControlSystemUpdater();
        private ClimateControlSystemRandomUpdater climateControlSystemRandomUpdater = new ClimateControlSystemRandomUpdater();
        
        private string _currentDate;
        private string _currentTime;

        private RoomListingItemViewModel selectedRoomListingItemViewModel;
        public ViewModelBase CurrentEditViewModel => _editViewModalStore.EditViewModel;
        public ViewModelBase selectedViewModel => _selectedViewModelStore.SelectedViewModel;
        public int SelectedRoomIndex { get; set; }

        private void OnCloseModalEvent()
        {
           CloseModalEvent?.Invoke(); 
        }
        public ClimateControlSystemViewModel()
        {
            _roomListingItemViewModels = new ObservableCollection<RoomListingItemViewModel>();
            UpdateListing();
            _selectedViewModelStore.SelectedViewModelChanged += SelectedViewModelStore_SelectedViewModelChanged;
            _editViewModalStore.EditViewModelChanged += EditViewModelStore_EditViewModelChanged;
            _editViewModalStore.CloseModalEvent += OnCloseModalEvent; 
            //SubscribeOnCloseModalEvent();
            var LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        private void EditViewModelStore_EditViewModelChanged()
        {
           OnPropertyChange(nameof(CurrentEditViewModel));
           OpenModalEvent?.Invoke();
        }
        protected override void Dispose()
        {
            _selectedViewModelStore.SelectedViewModelChanged -= SelectedViewModelStore_SelectedViewModelChanged;
            _editViewModalStore.EditViewModelChanged -= EditViewModelStore_EditViewModelChanged;
            _editViewModalStore.CloseModalEvent -= OnCloseModalEvent; 
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
                _selectedRoomStore.SelectedRoom = selectedRoomListingItemViewModel.Room;
                _selectedViewModelStore.SelectedViewModel = new RoomDetailsViewModel(selectedRoomListingItemViewModel.PlotPointsStore);
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
            int roomIndex = 0;
            foreach (var room in ClimateControlSystemStore.getInstance().ClimateControlSystem.Rooms)
            {
                _roomListingItemViewModels.Add(new RoomListingItemViewModel(room));
                roomIndex++;
            }
        }
        public void SerializeClimateControlSystem()
        {
            ClimateControlSystemSerializer serializer = new ClimateControlSystemSerializer();
            serializer.Serialize(ClimateControlSystemStore.getInstance().ClimateControlSystem, ConfigurationPathStore.getInstance().Path);
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second == 0)
                climateControlSystemUpdater.Update();
            if (DateTime.Now.Second == 30)
                climateControlSystemRandomUpdater.Update();
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");
        }
        public event Action CloseModalEvent;
        public event Action OpenModalEvent;
    }
}