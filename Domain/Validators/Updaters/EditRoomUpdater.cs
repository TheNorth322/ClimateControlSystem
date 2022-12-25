using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditRoomUpdater
    {
        private IRoom selectedRoom => SelectedRoomStore.getInstance().SelectedRoom;

        public void Update(double expectedTemperature, double expectedHumidity, double expectedCarbonDioxide)
        {
            selectedRoom.TemperatureSensor.ExpectedTemperature = expectedTemperature;
            selectedRoom.HumiditySensor.ExpectedHumidity = expectedHumidity;
            selectedRoom.CarbonDioxideSensor.ExpectedCarbonDioxide = expectedCarbonDioxide;
        }
    }
}