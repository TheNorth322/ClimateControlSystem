using System;
namespace ClimateControlSystemNamespace
{
    
    [Serializable]
    public class Purificator : ClimateControlSystemDevice
    {
        public double ExpectedCarbonDioxideLevel { get; set; }
        
        public double AirFlow { get; }
        
        // Constructors
        public Purificator(bool _isOn, double _airFlow, double _expectedCarbonDioxideLevel) 
            : base(_isOn) 
        {
            AirFlow = _airFlow;
            ExpectedCarbonDioxideLevel = _expectedCarbonDioxideLevel;
        }

        // Methods
        
    }
}
