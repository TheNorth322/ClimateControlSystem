using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class CarbonDioxideSensor
    {
        public CarbonDioxideSensor()
        {
        }

        public CarbonDioxideSensor(double _carbonDioxide)
        {
            CarbonDioxide = _carbonDioxide;
        }

        public double CarbonDioxide { get; set; }
        public double ExpectedCarbonDioxide { get; set; }
        public double ProvideData()
        {
            return CarbonDioxide;
        }
    }
}