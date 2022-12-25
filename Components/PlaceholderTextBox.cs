using System.Windows;
using System.Windows.Controls;

namespace ClimateControlSystem.Components
{
    public class PlaceholderTextBox : TextBox
    {
        private readonly string StartText;

        public PlaceholderTextBox()
        {
            StartText = Text;
        }

        public string Placeholder { get; set; }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.Text = Placeholder;
        }

        private void OnLostFocusTextBox(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(textBox.Text) || textBox.Text != StartText) return;
            textBox.Text = Placeholder;
        }

        private void OnGotFocusTextBox(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != Placeholder) return;
            textBox.Text = "";
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            CaretIndex = Text.Length;
            Loaded += OnLoad;
            LostFocus += OnLostFocusTextBox;
            GotFocus += OnGotFocusTextBox;
        }
    }
}