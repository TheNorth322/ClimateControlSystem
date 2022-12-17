using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.LogIn;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
            DataContext = new LogInViewModel();
            (DataContext as LogInViewModel).MessageBoxRequest +=
                ViewMessageBoxRequest;
        }

        private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }

        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
                vm.Close += () => { Close(); };
        }
    }
}