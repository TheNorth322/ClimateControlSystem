using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using ClimateControlSystem.Domain;
using ClimateControlSystem.ui.ViewModel;
using ClimateControlSystem.ui.ViewModel.ConfigurationCreation;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    ///     Логика взаимодействия для CreateConfigurationWindow.xaml
    /// </summary>
    public class EnumToItemsSource : MarkupExtension
    {
        private readonly Type _type;

        public EnumToItemsSource(Type type)
        {
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _type.GetMembers().SelectMany(member => member
                .GetCustomAttributes(typeof(DescriptionAttribute), true)
                .Cast<DescriptionAttribute>()).Select(x => x.Description).ToList();
        }
    }

    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            foreach (var one in Enum.GetValues(parameter as Type))
                if (value.Equals(one))
                    return ((Enum)one).GetEnumDescription();

            return "";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            foreach (var one in Enum.GetValues(parameter as Type))
                if (value.ToString() == ((Enum)one).GetEnumDescription())
                    return one;

            return null;
        }
    }

    public partial class ConfigurationCreationView : Window
    {
        public ConfigurationCreationView()
        {
            InitializeComponent();
            DataContext = new ConfigurationCreationViewModel();
            (DataContext as ConfigurationCreationViewModel).MessageBoxRequest +=
                ViewMessageBoxRequest;
            Loaded += ConfigurationCreationView_Loaded;
        }

        private void ConfigurationCreationView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
                vm.Close += () => { Close(); };
        }

        private void ViewMessageBoxRequest(object sender, MessageBoxEventArgs e)
        {
            e.Show();
        }
    }
}