using System;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class ClimateControlSystemRandomUpdater
    {
        private ClimateControlSystemStore climateControlSystemStore => ClimateControlSystemStore.getInstance();
        
        public void Update()
        {
            Random random = new Random();
            foreach (Room room in climateControlSystemStore.ClimateControlSystem.Rooms)
            {
                // Random double in range (-0.3,0.3)
                room.TemperatureSensor.Temperature += Math.Round(random.NextDouble(), 2) * 0.3 - 0.15;
                
                // Random double in range(-0.5, 0.5)
                room.HumiditySensor.Humidity += Math.Round(random.NextDouble(), 2) - 0.5;
                
                // Random double in range (3,5)
                room.CarbonDioxideSensor.CarbonDioxide += random.NextDouble() * 2 + 3;
            }
                
            climateControlSystemStore.ClimateControlSystemContentsChangedInvoke();
        }
    }
}