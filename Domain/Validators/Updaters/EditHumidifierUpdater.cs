using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditHumidifierUpdater
    {
        private readonly IHumidifier selectedHumidifier = SelectedHumidifierStore.getInstance().SelectedHumidifier;

        public void Update(bool status)
        {
            selectedHumidifier.IsOn = status;
        }
    }
}