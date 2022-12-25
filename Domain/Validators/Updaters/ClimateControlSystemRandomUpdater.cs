using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class ClimateControlSystemRandomUpdater
    {
        private ClimateControlSystemStore climateControlSystemStore => ClimateControlSystemStore.getInstance();

        public void Update()
        {
            var random = new Random();
            foreach (var room in climateControlSystemStore.ClimateControlSystem.Rooms)
            {
                // Random double in range (-0.3,0.3)
                room.TemperatureSensor.Temperature += random.NextDouble() * (0.15 - -0.15) + -0.15;

                // Random double in range(-0.5, 0.5)
                room.HumiditySensor.Humidity += random.NextDouble() - 0.5;

                // Random double in range (2,5)
                room.CarbonDioxideSensor.CarbonDioxide += random.NextDouble() + 2;
            }

            climateControlSystemStore.ClimateControlSystemContentsChangedInvoke();
        }
    }
}