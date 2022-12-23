using System.Windows.Controls;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.DeviceEditViewModels;

namespace ClimateControlSystem.ui.Views
{
    public partial class ConditionerDetailsEditView : UserControl
    {
        public ConditionerDetailsEditView()
        {
            InitializeComponent();
            this.DataContext = new ConditionerDetailsEditViewModel();
            (DataContext as ConditionerDetailsEditViewModel).MessageBoxRequest +=
                ViewMessageBoxRequest;
        }
        private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }
    }
}