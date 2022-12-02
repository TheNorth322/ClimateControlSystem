using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystem.ui.Views;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.LogIn
{
    public class LogInViewModel : ViewModelBase, ICloseWindows
    {
        private string _passCode;
        private readonly ClimateControlSystemNamespace.ClimateControlSystem ClimateControlSystem;
        public string PassCode
        {
            get { return _passCode; }
            set
            {
                _passCode = value;
                OnPropertyChange(nameof(PassCode));
            }
        }

        private RelayCommand _logInCommand;

        public RelayCommand LogInCommand
        {
            get
            {
                return _logInCommand ?? (_logInCommand = new RelayCommand(
                    _execute => LogIn(),
                    _canExecute => ValidatePassCode()));

            }
        }

        public void LogIn()
        {
           try
           {
               PassCodeVerifier passCodeVerifier = new PassCodeVerifier();
               passCodeVerifier.Verify(ClimateControlSystem.PassCode, PassCode);
               ClimateControlSystemView view = new ClimateControlSystemView
                {
                    DataContext = new ClimateControlSystemViewModel(new SelectedRoomStore(), ClimateControlSystem)
                };
                view.Show();
                Close?.Invoke();
            }
            catch (Exception e)
            {
                MessageBox_Show(null, e.Message, "Error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
        public bool ValidatePassCode()
        {
            return !String.IsNullOrEmpty(PassCode);
        }

        public LogInViewModel(ClimateControlSystemNamespace.ClimateControlSystem _climateControlSystem)
        {
            ClimateControlSystem = _climateControlSystem;
        }
        public Action Close { get; set; }
    }
}
