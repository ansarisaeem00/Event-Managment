using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EventV1.Models
{
    public class DataBindingModel : INotifyPropertyChanged
    {
        string _user;
        public string User
        {
            get => _user;
            set
            {
                if (string.Equals(_user, value))
                    return;

                _user = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
