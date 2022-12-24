using System;
using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    public interface IClimateControlSystem
    {
        List<Room> Rooms { get; }
        
        byte[] PassCode { get; set; }

        double ExpectedTemperature { get; set; }

        double ExpectedCarbonDioxideLevel { get; set; }

        double ExpectedHumidityLevel { get; set; }

        void UpdateRoomsData();
    }
}