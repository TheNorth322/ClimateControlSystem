using System;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Domain
{
    public class EditConditionerValidator
    {
        public void Validate(bool status, double airFlow, ConditionerMode mode, double workingTemperature)
        {
            if (airFlow <= 0)
                throw new ArgumentException("Wrong air flow value!");
        }
    }
}