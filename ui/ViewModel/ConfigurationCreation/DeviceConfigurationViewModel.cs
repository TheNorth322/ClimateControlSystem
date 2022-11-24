using ClimateControlSystemNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimateControlSystem.ui.ViewModel.ConfigurationCreation
{
    public class DeviceConfigurationViewModel : ViewModelBase
    {
        public double HumidifierWaterConsumption { get; }
        public bool HumidifierStatus { get; }
        public double PurificatorAirFlow { get; }
        public bool PurificatorStatus { get; }
        public double ConditionerAirFlow { get; }
        public double ConditionerTemperature { get; }
        public bool ConditionerStatus { get; }
        public ConditionerMode ConditionerMode { get; }
        public DeviceConfigurationViewModel ()
        {
            HumidifierStatus = true;
            PurificatorStatus = true;
            ConditionerStatus = true;
            ConditionerMode = ConditionerMode.Cooling;
        }

    }
}
