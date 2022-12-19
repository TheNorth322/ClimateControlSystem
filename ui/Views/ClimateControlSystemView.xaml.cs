using System.Windows;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.Views
{
    /// <summary>
    ///     Логика взаимодействия для ClimateControlSystemView.xaml
    /// </summary>
    public partial class ClimateControlSystemView : Window
    {
        private ClimateControlSystemStore _climateControlSystemStore => ClimateControlSystemStore.getInstance();

        public ClimateControlSystemView()
        {
            InitializeComponent();
        }
    }
}