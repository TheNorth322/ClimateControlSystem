namespace ClimateControlSystemNamespace
{
    public interface IHumidifier : IDevice
    {
        double WaterConsumption { get; set; }

        double ProvideHumidity();
    }
}