using System.Windows.Forms.VisualStyles;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditConditionerUpdater
    {
        private IConditioner selectedConditioner => SelectedConditionerStore.getInstance().SelectedConditioner;
        public void Update(bool status, ConditionerMode mode, double workingTemperature)
        {
            selectedConditioner.IsOn = status;
            selectedConditioner.ConditionerMode = mode;
            selectedConditioner.WorkingTemperature = workingTemperature;
        }
    }
}