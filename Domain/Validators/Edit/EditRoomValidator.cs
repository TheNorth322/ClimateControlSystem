using System;

namespace ClimateControlSystem.Domain
{
    public class EditRoomValidator
    {
        public void Validate(double expectedHumidity, double expectedCarbonDioxideLevel)
        {
            if (expectedHumidity <= 0 || expectedHumidity > 100)
                throw new ArgumentException("Wrong expected humidity value!");
            if (expectedCarbonDioxideLevel <= 0)
                throw new ArgumentException("Wrong carbon dioxide level value!");
        }
    }
}