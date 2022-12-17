using System;
using System.Windows;

namespace ClimateControlSystem.ui.ViewModel
{
    public class MessageBoxEventArgs : EventArgs
    {
        private readonly MessageBoxButton button;
        private readonly string caption;
        private readonly MessageBoxResult defaultResult;
        private readonly MessageBoxImage icon;
        private readonly string messageBoxText;
        private readonly MessageBoxOptions options;

        private readonly Action<MessageBoxResult> resultAction;

        public MessageBoxEventArgs(Action<MessageBoxResult> resultAction, string messageBoxText,
            string caption = "", MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None,
            MessageBoxOptions options = MessageBoxOptions.None)
        {
            this.resultAction = resultAction;
            this.messageBoxText = messageBoxText;
            this.caption = caption;
            this.button = button;
            this.icon = icon;
            this.defaultResult = defaultResult;
            this.options = options;
        }

        public void Show(Window owner)
        {
            var messageBoxResult =
                MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult, options);
            if (resultAction != null) resultAction(messageBoxResult);
        }

        public void Show()
        {
            var messageBoxResult =
                MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
            if (resultAction != null) resultAction(messageBoxResult);
        }
    }
}