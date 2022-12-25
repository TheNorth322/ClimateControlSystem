using System;
using System.Windows;
using ClimateControlSystem.ui.ViewModel.ClimateControlSystem;
using ClimateControlSystemNamespace;

namespace ClimateControlSystem.ui.Views
{
    /// <summary>
    ///     Логика взаимодействия для ClimateControlSystemView.xaml
    /// </summary>
    public partial class ClimateControlSystemView : Window
    {
        public ClimateControlSystemView()
        {
            InitializeComponent();
            selectedViewModelStore.SelectedViewModelChanged += SelectedViewModelStore_SelectedViewModelChanged;
            Loaded += OnLoaded;
            Closed += OnClosed;
        }

        private SelectedViewModelStore selectedViewModelStore => SelectedViewModelStore.getInstance();

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            (DataContext as ClimateControlSystemViewModel).CloseModalEvent += CloseModal;
            (DataContext as ClimateControlSystemViewModel).OpenModalEvent += OpenModal;
        }

        private void OnClosed(object sender, EventArgs e)
        {
            (DataContext as ClimateControlSystemViewModel).SerializeClimateControlSystem();
            Application.Current.Shutdown();
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