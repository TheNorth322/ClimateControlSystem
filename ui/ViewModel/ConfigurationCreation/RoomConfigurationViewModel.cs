using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class RoomConfigurationViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;
        private double _area;
        private double _carbonDioxideLevel;
        private double _height;
        private double _humidity;
        private LightLevel _lightLevel;
        private string _name;
        private double _temperature;

        public RoomConfigurationViewModel()
        {
            LightLevel = LightLevel.LowIllumination;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChange(nameof(Name));
            }
        }

        public double Area
        {
            get => _area;
            set
            {
                _area = value;
                OnPropertyChange(nameof(Area));
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChange(nameof(Height));
            }
        }

        public double Humidity
        {
            get => _humidity;
            set
            {
                _humidity = value;
                OnPropertyChange(nameof(Humidity));
            }
        }

        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertyChange(nameof(Temperature));
            }
        }

        public double CarbonDioxideLevel
        {
            get => _carbonDioxideLevel;
            set
            {
                _carbonDioxideLevel = value;
                OnPropertyChange(nameof(CarbonDioxideLevel));
            }
        }

        public LightLevel LightLevel
        {
            get => _lightLevel;
            set
            {
                _lightLevel = value;
                OnPropertyChange(nameof(LightLevel));
            }
        }
    }
}