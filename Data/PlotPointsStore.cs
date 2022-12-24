using System;
using System.Windows.Media;

namespace ClimateControlSystemNamespace
{
    public class PlotPointsStore
    {
        private PointCollection _temperaturePoints;
        private PointCollection _humidityPoints;
        private PointCollection _carbonDioxidePoints;

        public PlotPointsStore()
        {
            _temperaturePoints = new PointCollection();
            _humidityPoints = new PointCollection();
            _carbonDioxidePoints = new PointCollection();
        }

        public PointCollection TemperaturePoints
        {
            get { return _temperaturePoints; }
            set
            {
                _temperaturePoints = value;
                PointsChanged?.Invoke();
            }
        }

        public PointCollection HumidityPoints
        {
            get { return _humidityPoints; }
            set
            {
                _humidityPoints = value;
                PointsChanged?.Invoke();
            }
        }

        public PointCollection CarbonDioxidePoints
        {
            get { return _carbonDioxidePoints; }
            set
            {
                _carbonDioxidePoints = value;
                PointsChanged?.Invoke();
            }
        }

        public void PointsContentsChangedInvoke()
        {
            PointsContentsChanged?.Invoke();
        }
        
        public event Action PointsChanged;
        public event Action PointsContentsChanged;
    }
}