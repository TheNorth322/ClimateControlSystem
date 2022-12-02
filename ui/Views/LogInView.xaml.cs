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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.LogIn;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView(ClimateControlSystem _climateControlSystem)
        {
            InitializeComponent();
            Loaded += ViewLoaded;
            this.DataContext = new LogInViewModel(_climateControlSystem); 
            (this.DataContext as LogInViewModel).MessageBoxRequest +=
                new EventHandler<MessageBoxEventArgs>(ViewMessageBoxRequest);
        }
        void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }
        private void ViewLoaded(object sender, RoutedEventArgs e)
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
