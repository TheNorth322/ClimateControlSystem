using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimateControlSystem.ui.ViewModel.LogIn
{
    public class LogInViewModel : ViewModelBase
    {
        public string PassCode { get; }

        public ICommand LogInCommmand { get; }
    }
}
