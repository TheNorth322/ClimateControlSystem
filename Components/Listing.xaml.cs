using System.Windows.Controls;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Components
{
    /// <summary>
    ///     Логика взаимодействия для ClimateControlSystemListing.xaml
    /// </summary>
    public partial class Listing : UserControl
    {
        private Details Details;
        public SelectedRoomStore SelectedRoomStore;

        public Listing()
        {
            InitializeComponent();
            Details = new Details();
        }
    }
}