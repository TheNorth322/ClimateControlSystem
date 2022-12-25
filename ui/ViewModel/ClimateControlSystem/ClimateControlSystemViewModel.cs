using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using ClimateControlSystem.Domain.Updaters;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ClimateControlSystemViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RoomListingItemViewModel> _roomListingItemViewModels;

        private readonly ClimateControlSystemRandomUpdater climateControlSystemRandomUpdater =
            new ClimateControlSystemRandomUpdater();

        private readonly ClimateControlSystemUpdater climateControlSystemUpdater = new ClimateControlSystemUpdater();

        private RoomListingItemViewModel selectedRoomListingItemViewModel;
        private SelectedRoomStore _selectedRoomStore => SelectedRoomStore.getInstance();
        private EditViewModelStore _editViewModalStore => EditViewModelStore.getInstance();
        private SelectedViewModelStore _selectedViewModelStore => SelectedViewModelStore.getInstance();
        public ViewModelBase CurrentEditViewModel => _editViewModalStore.EditViewModel;
        public ViewModelBase selectedViewModel => _selectedViewModelStore.SelectedViewModel;
        public IEnumerable<RoomListingItemViewModel> RoomListingItemViewModels => _roomListingItemViewModels;
        
        private string _currentDate;
        private string _currentTime;
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
            LiveTime.Tick += TimerTick;
            LiveTime.Start();
        }

        public RoomListingItemViewModel SelectedRoomListingItemViewModel
        {
            get => selectedRoomListingItemViewModel;
            set
            {
                selectedRoomListingItemViewModel = value;
                _selectedRoomStore.SelectedRoom = selectedRoomListingItemViewModel.Room;
                _selectedViewModelStore.SelectedViewModel =
                    new RoomDetailsViewModel(selectedRoomListingItemViewModel.PlotPointsStore);
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

        private void OnCloseModalEvent()
        {
            CloseModalEvent?.Invoke();
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

        private void UpdateListing()
        {
            _roomListingItemViewModels.Clear();
            foreach (var room in ClimateControlSystemStore.getInstance().ClimateControlSystem.Rooms)
                _roomListingItemViewModels.Add(new RoomListingItemViewModel(room));
        }

        public void SerializeClimateControlSystem()
        {
            var serializer = new ClimateControlSystemSerializer();
            serializer.Serialize(ClimateControlSystemStore.getInstance().ClimateControlSystem,
                ConfigurationPathStore.getInstance().Path);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            switch (DateTime.Now.Second)
            {
                case 0:
                    climateControlSystemUpdater.Update();
                    break;
                case 30:
                    climateControlSystemRandomUpdater.Update();
                    break;
            }

            switch (DateTime.Now.Hour)
            {
                case 1:
                    climateControlSystemUpdater.UpdateLightLevels(LightLevel.LowIllumination);
                    break;
                case 10:
                    climateControlSystemUpdater.UpdateLightLevels(LightLevel.AverageIllumination);
                    break;
                case 14:
                    climateControlSystemUpdater.UpdateLightLevels(LightLevel.HighIllumination);
                    break;
                case 19:
                    climateControlSystemUpdater.UpdateLightLevels(LightLevel.LowIllumination);
                    break;
            }

            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");
        }

        public event Action CloseModalEvent;
        public event Action OpenModalEvent;
    }
}