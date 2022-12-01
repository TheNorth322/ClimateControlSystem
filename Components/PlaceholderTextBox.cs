using System;
using System.Windows;
using System.Windows.Controls;

namespace ClimateControlSystem.Components
{
    public class PlaceholderTextBox : TextBox
    {
        public string Placeholder { get; set; }
        
        public PlaceholderTextBox()
        {
            this.Text = Placeholder;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = Placeholder;
        }
        private void OnLostFocusTextBox(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!String.IsNullOrWhiteSpace(textBox.Text)) return;
            textBox.Text = Placeholder;
        }
        private void OnGotFocusTextBox(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text != Placeholder) return;
            textBox.Text = "";
        }
         
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.CaretIndex = this.Text.Length;
            this.LostFocus += OnLostFocusTextBox;
            this.GotFocus += OnGotFocusTextBox;
        }    
    }
}