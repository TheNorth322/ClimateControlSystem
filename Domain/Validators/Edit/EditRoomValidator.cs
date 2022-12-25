using System;

namespace ClimateControlSystem.Domain
{
    public class EditRoomValidator
    {
        public void Validate(double expectedTemperature, double expectedHumidity, double expectedCarbonDioxideLevel)
        {
            if (expectedHumidity <= 0 || expectedHumidity > 100)
                throw new ArgumentException("Wrong expected humidity value!");
            if (expectedCarbonDioxideLevel <= 0)
                throw new ArgumentException("Wrong expected carbon dioxide level value!");
            if (expectedTemperature < -40 || expectedHumidity > 40)
                throw new ArgumentException("Wrong expected temperature!");
        }
    }
}