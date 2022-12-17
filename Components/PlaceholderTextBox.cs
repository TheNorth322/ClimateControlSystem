using System.Windows;
using System.Windows.Controls;

namespace ClimateControlSystem.Components
{
    public class PlaceholderTextBox : TextBox
    {
        public PlaceholderTextBox()
        {
            Text = Placeholder;
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
            if (!string.IsNullOrWhiteSpace(textBox.Text)) return;
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
            LostFocus += OnLostFocusTextBox;
            GotFocus += OnGotFocusTextBox;
        }
    }
}