using System.Windows.Forms.VisualStyles;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain.Updaters
{
    public class EditConditionerUpdater
    {
        public void Update(bool status, double airFlow, ConditionerMode mode, double workingTemperature,
            int conditionerIndex, int roomIndex)
        {
            Conditioner conditioner = ClimateControlSystemStore.getInstance().ClimateControlSystem.Rooms[roomIndex]
                .Conditioners[conditionerIndex];
            conditioner.isOn = status;
            conditioner.AirFlow = airFlow;
            conditioner.ConditionerMode = mode;
            conditioner.WorkingTemperature = workingTemperature;
        }
    }
}