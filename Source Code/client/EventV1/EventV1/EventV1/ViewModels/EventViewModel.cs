using EventV1.Models;
using EventV1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventV1.ViewModels
{
    public class EventViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();
        private List<EventUpload> _content;

        public string AccessToken { get; set; }
        public List<EventUpload> Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }


        public ICommand GetEventCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Content = await apiServices.GetEventsAsync(AccessToken);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
