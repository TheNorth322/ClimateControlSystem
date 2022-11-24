using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimateControlSystem.ui.ViewModel.EnterConfigurationPath
{
    public class ConfigurationPathViewModel : ViewModelBase
    {
        public string ConfigurationPath { get; }

        public ICommand LoadConfiguration { get; }

        public ICommand CreateConfiguration { get; }
    }
}
