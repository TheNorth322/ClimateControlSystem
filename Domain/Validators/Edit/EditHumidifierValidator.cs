using System;

namespace ClimateControlSystem.Domain
{
    public class EditHumidifierValidator
    {
        public void Validate(bool status, double waterConsumption)
        {
            if (waterConsumption <= 0 || waterConsumption > 100)
                throw new ArgumentException("Wrong water consumption value!");
        }
    }
}