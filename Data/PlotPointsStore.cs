using System;
using System.Collections.Generic;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace ClimateControlSystemNamespace
{
    public class PlotPointsStore
    {
        private SeriesCollection seriesCollection;
        private List<double> axis;
        public PlotPointsStore()
        {
            axis = new List<double>();
            seriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Temperature",
                    Values = new ChartValues<double>()
                },
                new LineSeries
                {
                    Title = "Humidity",
                    Values = new ChartValues<double>()
                },
                new LineSeries
                {
                    Title = "CarbonDioxide",
                    Values = new ChartValues<double>()
                }
            };
        }

        public List<double> Axis
        {
            get { return axis; }
            set
            {
                axis = value;
                SeriesCollectionChanged?.Invoke(); 
            }
        }
        public SeriesCollection SeriesCollection 
        {
            get { return seriesCollection; }
            set
            {
                seriesCollection = value;
                SeriesCollectionChanged?.Invoke();
            }
        }

        public void PointsContentsChangedInvoke()
        {
            PointsContentsChanged?.Invoke();
        }
        
        public event Action SeriesCollectionChanged;
        public event Action PointsContentsChanged;
    }
}