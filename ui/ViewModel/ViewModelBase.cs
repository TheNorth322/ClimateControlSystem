﻿using System;
using System.ComponentModel;
using System.Windows;

namespace ClimateControlSystem.ui.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<MessageBoxEventArgs> MessageBoxRequest;
        public event EventHandler CloseEvent;

        protected void MessageBox_Show(Action<MessageBoxResult> resultAction, string messageBoxText,
            string caption = "", MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.None)
        {
            MessageBoxRequest?.Invoke(this,
                new MessageBoxEventArgs(resultAction, messageBoxText, caption,
                    button, icon, defaultResult, options));
        }

        protected virtual void OnPropertyChange(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose()
        {
        }
    }
}