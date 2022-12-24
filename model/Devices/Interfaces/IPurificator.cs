namespace ClimateControlSystemNamespace
{
    public interface IPurificator : IDevice
    {
        double AirFlow { get; set; }

        double ReceivePurification();
    }
}