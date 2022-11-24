using ClimateControlSystemNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class RoomConfigurationViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;
        private string _name;
        private double _area;
        private double _height;
        private double _humidity;
        private double _temperature;
        private double _carbonDioxideLevel;
        private LightLevel _lightLevel;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChange(nameof(Name));
            }
        }

        public double Area
        {
            get { return _area; }
            set
            {
                _area = value;
                OnPropertyChange(nameof(Area));
            }
        }
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChange(nameof(Height));
            }
        }
        public double Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                OnPropertyChange(nameof(Humidity));
            }
        }
        public double Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                OnPropertyChange(nameof(Temperature));
            }
        }
        public double CarbonDioxideLevel
        {
            get { return _carbonDioxideLevel; }
            set
            {
                _carbonDioxideLevel = value;
                OnPropertyChange(nameof(CarbonDioxideLevel));
            }
        }
        public LightLevel LightLevel
        {
            get { return _lightLevel; }
            set
            {
                _lightLevel = value;
                OnPropertyChange(nameof(LightLevel));
            }
        }
        
        public RoomConfigurationViewModel()
        {
            LightLevel = LightLevel.LowIllumination;
        }
    }
}
