using System;

namespace ClimateControlSystem.Domain
{
    public class EditPurificatorValidator
    {
        public void Validate(bool status, double airFlow)
        {
            if (airFlow <= 0 || airFlow >= 100)
                throw new ArgumentException("Wrong air flow value!");
        }
    }
}