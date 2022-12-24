using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class ClimateControlSystemUpdater
    {
        private ClimateControlSystemStore climateControlSystemStore =>
            ClimateControlSystemStore.getInstance();
        
        public void Update()
        {
           climateControlSystemStore.ClimateControlSystem.UpdateRoomsData();
           climateControlSystemStore.ClimateControlSystemContentsChangedInvoke();
        } 
    }
}