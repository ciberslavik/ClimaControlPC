using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClimaControl.Data
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        private bool _isModified;

        public bool IsModified { get => _isModified; set => _isModified = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool Update<T>(ref T property,T value,[CallerMemberName]string propertyName="")
        {
            if (!Equals(property, value))
            {
                property = value;
                _isModified = true;
                OnPropertyChanged(this, propertyName);
                return true;
            }
            else
                return false;
        }

        protected virtual void OnPropertyChanged(object sender, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
