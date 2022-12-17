using System.Windows;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.EnterConfigurationPath;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    ///     Логика взаимодействия для ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationPathView : Window
    {
        public ConfigurationPathView()
        {
            InitializeComponent();
            Loaded += ConfigurationPathView_Loaded;
            DataContext = new ConfigurationPathViewModel();
            (DataContext as ConfigurationPathViewModel).MessageBoxRequest +=
                ViewMessageBoxRequest;
        }

        private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }

        private void ConfigurationPathView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
                vm.Close += () => { Close(); };
        }
    }
}