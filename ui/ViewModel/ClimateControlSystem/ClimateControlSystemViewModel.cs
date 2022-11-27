using System;
using System.Windows.Threading;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ClimateControlSystemViewModel : ViewModelBase
    {
        public ListingViewModel ListingViewModel { get; }
        public RoomDetailsViewModel DetailsViewModel { get; }
        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                OnPropertyChange(nameof(CurrentTime));
            }
        }
        private string _currentDate;
        public string CurrentDate
        {
            get { return _currentDate; }
            set
            {
                _currentDate = value;
                OnPropertyChange(nameof(CurrentDate));
            }
        }
        public ClimateControlSystemViewModel(SelectedRoomStore _selectedRoomStore, ClimateControlSystemNamespace.ClimateControlSystem _system)
        {
            ListingViewModel = new ListingViewModel(_selectedRoomStore, _system);
            DetailsViewModel = new RoomDetailsViewModel(_selectedRoomStore);
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start(); 
        }
        void timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}