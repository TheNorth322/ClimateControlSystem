using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class ClimateControlSystemUpdater
    {
        private ClimateControlSystemStore climateControlSystemStore =>
            ClimateControlSystemStore.getInstance();

        public void UpdateLightLevels(LightLevel _lightLevel)
        {
            foreach (Room room in climateControlSystemStore.ClimateControlSystem.Rooms)
                room.UpdateLightLevel(_lightLevel);
        }
        public void Update()
        {
           climateControlSystemStore.ClimateControlSystem.UpdateRoomsData();
           climateControlSystemStore.ClimateControlSystemContentsChangedInvoke();
        } 
    }
}