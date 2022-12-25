using System.Windows.Controls;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;

namespace ClimateControlSystem.ui.Views
{
    public partial class HumidifierDetailsEditView : UserControl
    {
        public HumidifierDetailsEditView()
        {
            InitializeComponent();
            DataContext = new HumidifierDetailsEditViewModel();
            (DataContext as HumidifierDetailsEditViewModel).MessageBoxRequest +=
                ViewMessageBoxRequest;
        }

        private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }
    }
}