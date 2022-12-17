using System;
using System.Windows.Threading;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ClimateControlSystem
{
    public class ClimateControlSystemViewModel : ViewModelBase
    {
        private string _currentDate;
        private string _currentTime;

        public ClimateControlSystemViewModel(SelectedRoomStore _selectedRoomStore)
        {
            ListingViewModel = new ListingViewModel(_selectedRoomStore);
            DetailsViewModel = new RoomDetailsViewModel(_selectedRoomStore);
            var LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }

        public ListingViewModel ListingViewModel { get; }
        public RoomDetailsViewModel DetailsViewModel { get; }

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

        private void timer_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            CurrentDate = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}