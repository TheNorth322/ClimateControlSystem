using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditPurificatorUpdater
    {
        private IPurificator selectedPurificator => SelectedPurificatorStore.getInstance().SelectedPurificator;
        public void Update(bool status, double airFlow)
        {
            selectedPurificator.IsOn = status;
        }
    }
}