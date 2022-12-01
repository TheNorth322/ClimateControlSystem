using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClimateControlSystem.Domain;

namespace ClimateControlSystemNamespace
{
    /// <summary>
    /// Логика взаимодействия для CreateConfigurationWindow.xaml
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
            {
                if (value.Equals(one))
                    return EnumExtensionMethods.GetEnumDescription((Enum) one);
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            foreach (var one in Enum.GetValues(parameter as Type))
            {
                if (value.ToString() == EnumExtensionMethods.GetEnumDescription((Enum) one))
                {
                    return one;
                }
            }

            return null;
        }
    }

    public partial class ConfigurationCreationView : Window
    {
        public ConfigurationCreationView()
        {
            InitializeComponent();
            Loaded += ConfigurationCreationView_Loaded;
        }
        private void ConfigurationCreationView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}