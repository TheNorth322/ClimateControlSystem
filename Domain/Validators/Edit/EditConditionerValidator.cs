using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class EditConditionerValidator
    {
        public void Validate(bool status, ConditionerMode mode, double workingTemperature)
        {
            if (status == null)
                throw new NullReferenceException("Status can't be null!");
        }
    }
}