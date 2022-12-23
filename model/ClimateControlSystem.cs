using System;
using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class ClimateControlSystem
    {
        // Constructors
        public ClimateControlSystem()
        {
            Rooms = new List<Room>();
            ExpectedTemperature = 24;
            ExpectedCarbonDioxideLevel = 600;
            ExpectedHumidityLevel = 60;
        }

        public ClimateControlSystem(List<Room> _rooms, double _expectedTemperature,
            double _expectedCarbonDioxideLevel, double _expectedHumidityLevel)
        {
            Rooms = _rooms;
            ExpectedTemperature = _expectedTemperature;
            ExpectedHumidityLevel = _expectedHumidityLevel;
            ExpectedCarbonDioxideLevel = _expectedCarbonDioxideLevel;
        }

        // Properties 
        public List<Room> Rooms { get; }
        public byte[] PassCode { get; set; }
        
        public double ExpectedTemperature { get; set; }
        
        public double ExpectedCarbonDioxideLevel { get; set; }
        
        public double ExpectedHumidityLevel { get; set; }
    }
}