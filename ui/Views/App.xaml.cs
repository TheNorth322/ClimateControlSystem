using System.Windows;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    ///     Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Singleton Storages
        private readonly SelectedRoomStore _selectedRoomStore;
        private RoomStore _roomStore;
        public App()
        {
            _selectedRoomStore = SelectedRoomStore.getInstance();
            _roomStore = RoomStore.getInstance();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new ConfigurationPathView();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}