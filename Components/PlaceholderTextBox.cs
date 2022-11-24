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
            Placeholder = this.Placeholder;
        }
       private void OnLostFocusTextBox(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text != "") return;
            textBox.Text = Placeholder;
        }
        private void OnGotFocusTextBox(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text != Placeholder) return;
            textBox.Text = "";
        }
        private void PastingEventHandler(object sender, DataObjectEventArgs e)
        {
            // Prevent/disable paste
            e.CancelCommand();
        } 
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DataObject.AddCopyingHandler(this, PastingEventHandler);
            DataObject.AddPastingHandler(this, PastingEventHandler);
            this.CaretIndex = this.Text.Length;
            this.Text = Placeholder;
            this.LostFocus += OnLostFocusTextBox;
            this.GotFocus += OnGotFocusTextBox;
        }    
    }
}