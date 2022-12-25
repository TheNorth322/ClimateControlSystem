using System.Xml.Serialization;

namespace ClimateControlSystemNamespace
{
    [XmlInclude(typeof(Conditioner))]
    [XmlInclude(typeof(Humidifier))]
    [XmlInclude(typeof(Purificator))]
    public abstract class ClimateControlSystemDevice : IDevice
    {
        public ClimateControlSystemDevice()
        {
            IsOn = true;
        }

        public ClimateControlSystemDevice(bool _isOn)
        {
            IsOn = _isOn;
        }

        public bool IsOn { get; set; }

        public void TurnOn()
        {
            IsOn = true;
        }

        public void TurnOff()
        {
            IsOn = false;
        }
    }
}