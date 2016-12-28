using Microsoft.AspNet.SignalR.Client;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FSL.XamarinForms
{
    public sealed class SignalrPageViewModel : INotifyPropertyChanged
    {
        private HubConnection _connection;
        private IHubProxy _plaugroundHub;

        public IHubProxy PlaygroundHub
        {
            get
            {
                return _plaugroundHub;
            }
        }

        public SignalrPageViewModel()
        {
            _connection = new HubConnection("http://10.0.2.2/SignalR.FSL.Mvc/");
            _plaugroundHub = _connection.CreateHubProxy("PlaygroundHub");
            _plaugroundHub.On<string>("sendMessage", message => Messages += "\r\n - " + message);
            _connection.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _messages;
        public string Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
