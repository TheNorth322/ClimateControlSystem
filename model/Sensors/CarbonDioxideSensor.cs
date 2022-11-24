using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class CarbonDioxideSensor : ISensor
    {
        public double CarbonDioxide { get; set; }
        
        public CarbonDioxideSensor(double _carbonDioxide)
        {
            CarbonDioxide = _carbonDioxide;
        }

        public double ProvideData() => CarbonDioxide;
    }
}