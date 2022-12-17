using System;
using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystem.ui.Views;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.ViewModel.LogIn
{
    public class LogInViewModel : ViewModelBase, ICloseWindows
    {
        private RelayCommand _logInCommand;
        private string _passCode;

        public string PassCode
        {
            get => _passCode;
            set
            {
                _passCode = value;
                OnPropertyChange(nameof(PassCode));
            }
        }

        public RelayCommand LogInCommand
        {
            get
            {
                return _logInCommand ?? (_logInCommand = new RelayCommand(
                    _execute => LogIn(),
                    _canExecute => ValidatePassCode()));
            }
        }

        public Action Close { get; set; }

        public void LogIn()
        {
            try
            {
                var passCodeVerifier = new PassCodeVerifier();
                passCodeVerifier.Verify(ClimateControlSystemStore.getInstance().ClimateControlSystem.PassCode,
                    PassCode);
                var view = new ClimateControlSystemView
                {
                    DataContext = new ClimateControlSystemViewModel(SelectedRoomStore.getInstance())
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
            return !string.IsNullOrEmpty(PassCode);
        }
    }
}