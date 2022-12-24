using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class PurificatorValidator
    {
        public static bool Validate(IPurificator _purificator)
        {
            if (_purificator.AirFlow <= 0)
                throw new ArgumentException("Wrong purificator air flow value!");
            return true;
        }
    }
}