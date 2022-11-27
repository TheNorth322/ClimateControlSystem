using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.EnterConfigurationPath;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    /// Логика взаимодействия для ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationPathView : Window
    {
        public ConfigurationPathView()
        {
            InitializeComponent();
            DataContext = new ConfigurationPathViewModel();
            Loaded += ConfigurationPathView_Loaded;
            (this.DataContext as ConfigurationPathViewModel).MessageBoxRequest +=
                new EventHandler<MessageBoxEventArgs>(ViewMessageBoxRequest);
        }

        void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }
        private void ConfigurationPathView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
