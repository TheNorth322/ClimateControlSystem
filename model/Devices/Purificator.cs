using System;

namespace ClimateControlSystemNamespace
{
    [Serializable]
    public class Purificator : ClimateControlSystemDevice, IPurificator
    {
        public Purificator()
        {
        }

        // Constructors
        public Purificator(bool _isOn, double _airFlow)
            : base(_isOn)
        {
            AirFlow = _airFlow;
        }

        public double AirFlow { get; set; }

        public double ReceivePurification()
        {
            return (IsOn) ? AirFlow : 0;
        } 
    }
}