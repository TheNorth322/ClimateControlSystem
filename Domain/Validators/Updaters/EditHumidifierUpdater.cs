using System.Collections.Generic;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditHumidifierUpdater
    {
        private ClimateControlSystemNamespace.ClimateControlSystem system = ClimateControlSystemStore.getInstance().ClimateControlSystem;
        public void Update(bool status, double WaterConsumption, int humidifierIndex, int roomIndex)
        {
            Humidifier humidifier = system.Rooms[roomIndex].Humidifiers[humidifierIndex];
            humidifier.WaterConsumption = WaterConsumption;
            humidifier.isOn = status;
        }
    }
}