using System.Windows.Controls;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;

namespace ClimateControlSystem.ui.Views
{
    public partial class RoomDetailsEditView : UserControl
    {
        public RoomDetailsEditView()
        {
            InitializeComponent();
            DataContext = new RoomDetailsEditViewModel();
            (DataContext as RoomDetailsEditViewModel).MessageBoxRequest +=
                ViewMessageBoxRequest;
        }
        private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }
    }
}