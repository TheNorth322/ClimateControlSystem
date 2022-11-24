using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ClimateControlSystemNamespace
{
    public enum DeviceMode 
    {
        On,
        Off
    };
    [XmlInclude(typeof(Conditioner))]
    [XmlInclude(typeof(Humidifier))]
    [XmlInclude(typeof(Purificator))]
    public abstract class ClimateControlSystemDevice
    {
        // Fields
        public bool isOn { get; set; }
        // Properties
        

        // Contructors
        public ClimateControlSystemDevice(bool _isOn)
        {
            isOn = _isOn;
        }

        // Methods
        public void Activate() => isOn = true;
        public void Deactivate() => isOn = false;
    }
}
