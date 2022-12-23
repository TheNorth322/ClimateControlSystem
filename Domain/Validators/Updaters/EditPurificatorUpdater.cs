using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditPurificatorUpdater
    {
        private ClimateControlSystemNamespace.ClimateControlSystem system = ClimateControlSystemStore.getInstance().ClimateControlSystem;
        public void Update(bool status, double airFlow, int purificatorIndex, int roomIndex)
        {
            Purificator purificator = system.Rooms[roomIndex].Purificators[purificatorIndex];
            purificator.AirFlow = airFlow;
            purificator.isOn = status;
        }
    }
}