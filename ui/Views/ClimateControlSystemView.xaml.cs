using System.Windows;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.Views
{
    /// <summary>
    ///     Логика взаимодействия для ClimateControlSystemView.xaml
    /// </summary>
    public partial class ClimateControlSystemView : Window
    {
        private readonly ClimateControlSystemStore _climateControlSystemStore;

        public ClimateControlSystemView()
        {
            InitializeComponent();
        }

        public ClimateControlSystemView(ClimateControlSystemStore climateControlSystemStore)
        {
            _climateControlSystemStore = climateControlSystemStore;
            InitializeComponent();
        }
    }
}