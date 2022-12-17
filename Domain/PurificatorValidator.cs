using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class PurificatorValidator
    {
        public static bool Validate(Purificator _purificator)
        {
            if (_purificator.AirFlow <= 0)
                throw new ArgumentException("Wrong purificator air flow value!");
            if (_purificator.ExpectedCarbonDioxideLevel <= 0)
                throw new ArgumentException("Wrong expected carbon dioxide level value!");
            return true;
        }
    }
}