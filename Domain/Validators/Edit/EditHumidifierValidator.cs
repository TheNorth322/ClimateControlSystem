using System;

namespace ClimateControlSystem.Domain
{
    public class EditHumidifierValidator
    {
        public void Validate(bool status, double waterConsumption)
        {
            if (waterConsumption <= 0)
                throw new ArgumentException("Wrong water consumption value!");
        }
    }
}