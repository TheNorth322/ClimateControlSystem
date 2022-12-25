using System.Collections.Generic;

namespace ClimateControlSystemNamespace
{
    public interface IRoom
    {
        string Name { get; }
        double Area { get; }
        double CeilingHeight { get; }
        HumiditySensor HumiditySensor { get; set; }
        TemperatureSensor TemperatureSensor { get; set; }
        CarbonDioxideSensor CarbonDioxideSensor { get; set; }
        LightLevel LightLevel { get; set; }
        List<Conditioner> Conditioners { get; }
        List<Humidifier> Humidifiers { get; }
        List<Purificator> Purificators { get; }
        void UpdateData();
        void UpdateLightLevel(LightLevel _lightLevel);
        void AddConditioner(Conditioner _conditioner);
        void AddHumidifier(Humidifier _humidifier);
        void AddPurificator(Purificator _purificator);
    }
}