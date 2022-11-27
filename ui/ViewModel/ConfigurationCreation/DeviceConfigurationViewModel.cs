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
        private double _humidifierWaterConsumption;
        private bool _humidifierStatus;
        private double _purificatorAirFlow;
        private bool _purificatorStatus;
        private double _conditionerAirFlow;
        private double _conditionerTemperature;
        private bool _conditionerStatus;
        private ConditionerMode _conditionerMode;

        public double HumidifierWaterConsumption
        {
            get { return _humidifierWaterConsumption; }
            set
            {
                _humidifierWaterConsumption = value;
                OnPropertyChange(nameof(HumidifierWaterConsumption));
            }
        }
        public bool HumidifierStatus
        {
            get { return _humidifierStatus; }
            set
            {
                _humidifierStatus = value;
                OnPropertyChange(nameof(HumidifierStatus));
            }
        }
        public double PurificatorAirFlow
        {
            get { return _purificatorAirFlow; }
            set
            {
                _purificatorAirFlow = value;
                OnPropertyChange(nameof(PurificatorAirFlow));
            }
        }
        public bool PurificatorStatus
        {
            get { return _purificatorStatus; }
            set
            {
                _purificatorStatus = value;
                OnPropertyChange(nameof(PurificatorStatus));
            }
        }
        public double ConditionerAirFlow
        {
            get { return _conditionerAirFlow; }
            set
            {
                _conditionerAirFlow = value;
                OnPropertyChange(nameof(ConditionerAirFlow));
            }
        }
        public double ConditionerTemperature
        {
            get { return _conditionerTemperature; }
            set
            {
                _conditionerTemperature = value;
                OnPropertyChange(nameof(ConditionerTemperature));
            }
        }
        public bool ConditionerStatus
        {
            get { return _conditionerStatus; }
            set
            {
                _conditionerStatus = value;
                OnPropertyChange(nameof(ConditionerStatus));
            }
        }
        public ConditionerMode ConditionerMode
        {
            get { return _conditionerMode; }
            set
            {
                _conditionerMode = value;
                OnPropertyChange(nameof(ConditionerMode));
            }
        }
        public DeviceConfigurationViewModel ()
        {
            HumidifierStatus = true;
            PurificatorStatus = true;
            ConditionerStatus = true;
            ConditionerMode = ConditionerMode.Cooling;
        }

    }
}
