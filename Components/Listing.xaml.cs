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
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystem.ui.Views;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.Components
{
    /// <summary>
    /// Логика взаимодействия для ClimateControlSystemListing.xaml
    /// </summary>
    public partial class Listing : UserControl
    {
        public SelectedRoomStore SelectedRoomStore;
        public SelectedConditionerStore SelectedConditionerStore;
        public SelectedHumidifierStore SelectedHumidifierStore;
        public SelectedPurificatorStore SelectedPurificatorStore;
        private Details Details;
        public Listing()
        {
            InitializeComponent();
            Details = new Details();
        }

        private void RoomListViewItemClicked(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Details.DataContext = new RoomDetailsViewModel(SelectedRoomStore);
            }
        }
        private void ConditionerMenuItemClicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            if (item != null)
            {
                Details.DataContext = new ConditionerDetailsViewModel(SelectedConditionerStore);
            }
        }
        private void HumidifierMenuItemClicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            if (item != null) 
            {
                Details.DataContext = new HumidifierDetailsViewModel(SelectedHumidifierStore);
            }
        }
        private void PurificatorMenuItemClicked(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            if (item != null)
            {
                Details.DataContext = new PurificatorDetailsViewModel(SelectedPurificatorStore);
            }
        }
    }
}
