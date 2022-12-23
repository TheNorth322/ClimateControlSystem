using System;
using System.Windows;
using System.Windows.Forms;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystemNamespace;
using ListView = System.Windows.Controls.ListView;
using ListViewItem = System.Windows.Controls.ListViewItem;
using Menu = System.Windows.Controls.Menu;
using MenuItem = System.Windows.Controls.MenuItem;

namespace ClimateControlSystem.ui.Views
{
    /// <summary>
    ///     Логика взаимодействия для ClimateControlSystemView.xaml
    /// </summary>
    public partial class ClimateControlSystemView : Window
    {
        private SelectedViewModelStore selectedViewModelStore => SelectedViewModelStore.getInstance();

        public ClimateControlSystemView()
        {
            InitializeComponent();
            selectedViewModelStore.SelectedViewModelChanged += SelectedViewModelStore_SelectedViewModelChanged;
            Loaded += OnLoaded;
            Closed += OnClosed;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            (DataContext as ClimateControlSystemViewModel).CloseModalEvent += CloseModal;
            (DataContext as ClimateControlSystemViewModel).OpenModalEvent += OpenModal;
        }

        private void OnClosed(object sender, EventArgs e)
        {
            (DataContext as ClimateControlSystemViewModel).SerializeClimateControlSystem();
            System.Windows.Application.Current.Shutdown();
        }
        private void CloseModal()
        {
            Modal.IsOpen = false;
        }

        private void OpenModal()
        {
            Modal.IsOpen = true;
        }

        private void SelectedViewModelStore_SelectedViewModelChanged()
        {
            //TODO
        }
    }
}