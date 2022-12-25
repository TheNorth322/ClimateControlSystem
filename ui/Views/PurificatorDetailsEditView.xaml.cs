using System.Windows.Controls;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;

namespace ClimateControlSystem.ui.Views
{
    public partial class PurificatorDetailsEditView : UserControl
    {
        public PurificatorDetailsEditView()
        {
            InitializeComponent();
            DataContext = new PurificatorDetailsEditViewModel();
            (DataContext as PurificatorDetailsEditViewModel).MessageBoxRequest +=
                ViewMessageBoxRequest;
        }

        private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }
    }
}