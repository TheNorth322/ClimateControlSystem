namespace ClimateControlSystemNamespace
{
    public interface IDevice
    {
        bool IsOn { get; set; }
        void TurnOn();
        void TurnOff();
    }
}