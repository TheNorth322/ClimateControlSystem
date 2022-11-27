using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class CarbonDioxideSensor
    {
        public double CarbonDioxide { get; set; }
        public CarbonDioxideSensor() {} 
        public CarbonDioxideSensor(double _carbonDioxide)
        {
            CarbonDioxide = _carbonDioxide;
        }

        public double ProvideData() => CarbonDioxide;
    }
}