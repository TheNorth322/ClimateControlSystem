namespace ClimateControlSystemNamespace
{
    public interface IConditioner : IDevice
    {
        double AirFlow { get; set; }
        ConditionerMode ConditionerMode { get; set; }

        double WorkingTemperature { get; set; }

        void TurnOnHeatingMode();

        void TurnOnCoolingMode();

        double ProvideHeat();
    }
}