using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditRoomUpdater
    {
        private ClimateControlSystemNamespace.ClimateControlSystem system =
            ClimateControlSystemStore.getInstance().ClimateControlSystem;

        public void Update(double expectedTemperature, double expectedHumidity, double expectedCarbonDioxide, int roomIndex)
        {
            system.Rooms[roomIndex].TemperatureSensor.ExpectedTemperature = expectedTemperature;
            system.Rooms[roomIndex].HumiditySensor.ExpectedHumidity = expectedHumidity;
            system.Rooms[roomIndex].CarbonDioxideSensor.ExpectedCarbonDioxide = expectedCarbonDioxide;
        }
    }
}