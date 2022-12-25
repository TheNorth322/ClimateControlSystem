using System;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Wpf;

namespace ClimateControlSystemNamespace
{
    public class PlotPointsStore
    {
        private List<double> axis;
        private SeriesCollection seriesCollection;

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
            get => axis;
            set
            {
                axis = value;
                SeriesCollectionChanged?.Invoke();
            }
        }

        public SeriesCollection SeriesCollection
        {
            get => seriesCollection;
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