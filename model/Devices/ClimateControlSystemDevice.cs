using System.Xml.Serialization;

namespace ClimateControlSystemNamespace
{
    [XmlInclude(typeof(Conditioner))]
    [XmlInclude(typeof(Humidifier))]
    [XmlInclude(typeof(Purificator))]
    public abstract class ClimateControlSystemDevice
    {
        // Contructors
        public ClimateControlSystemDevice()
        {
            isOn = true;
        }

        public ClimateControlSystemDevice(bool _isOn)
        {
            isOn = _isOn;
        }
        // Properties

        public bool isOn { get; set; }

        // Methods
        public void Activate()
        {
            isOn = true;
        }

        public void Deactivate()
        {
            isOn = false;
        }
    }
}