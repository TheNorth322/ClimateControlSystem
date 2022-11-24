using System;
namespace ClimateControlSystemNamespace
{
    public class HeatSourceObject
    {
        // Fields
        private string name;
        private double heatingCapacity;
        private bool status;

        // Properties
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Wrong name value! Shouldn't be null or contain whitespace!");
                name = value;
            }
        }

        public double HeatingCapacity
        {
            get { return heatingCapacity; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Wrong heating capacity value! Must be greater than zero!");
            }
        }

        public bool Status
        {
            get { return status; }
            set
            {
                status = Convert.ToBoolean(value);
            }
        }

        // Constructors
        public HeatSourceObject(string _name, double _heatingCapacity, bool _status)
        {
            Name = _name;
            HeatingCapacity = _heatingCapacity;
            Status = _status;
        }

        // Methods
        public double ProduceHeat()
        {
            // TODO
            return HeatingCapacity;   
        }

        public void changeStatus()
        {
            status = (status == true) ? false : true;
        }
    }
}
