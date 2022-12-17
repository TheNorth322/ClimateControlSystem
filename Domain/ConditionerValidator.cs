using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class ConditionerValidator
    {
        public static bool Validate(Conditioner _conditioner)
        {
            if (_conditioner.AirFlow <= 0)
                throw new ArgumentException("Wrong conditioner air flow value!");
            return true;
        }
    }
}