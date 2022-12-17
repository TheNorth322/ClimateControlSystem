﻿using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class HumidifierValidator
    {
        public static bool Validate(Humidifier _humidifier)
        {
            if (_humidifier.WaterConsumption <= 0)
                throw new ArgumentException("Wrong humidifier water consumption value!");
            if (_humidifier.ExpectedHumidityLevel <= 0)
                throw new ArgumentException("Wrong expected humidity level value!");
            return true;
        }
    }
}