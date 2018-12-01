using APP_Messenger.Managers;
using APP_Messenger.Managers.Authentication;
using APP_Messenger.Models;
using APP_Messenger.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace APP_Messenger.ViewModels
{
    class MessagingViewViewModel: INotifyPropertyChanged
    {
        #region Fileds
        //private MessagingManager _messagingManager;
        private Message _selectedMessage;
        private ObservableCollection<Message> _messages;
        #endregion
        private ICommand _SendMessageCommand;

        public ICommand SendMessageCommand => _SendMessageCommand ?? (_SendMessageCommand = new RelayCommand<object>(SendMessage));

        /*
        public MessagingManager MessagingManager {
            get => _messagingManager;
            set => _messagingManager = value;
        }
        */
        public Message SelectedMessage {
            get => _selectedMessage;
            set
            {
                _selectedMessage = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Message> Messages
        {
            get => _messages;
        }


        public MessagingViewViewModel()
        {
            StartMessaging();
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedMessage")
                OnMessageSent(_selectedMessage);
        }
        private void StartMessaging()
        {
            _messages = new ObservableCollection<Message>();
            foreach (var message in StationManager.CurrentUser.Messages)
            {
                _messages.Add(message);
            }
            if (_messages.Count > 0)
            {
                _selectedMessage = Messages[0];
            }
        }

        private void SendMessage(object o)
        {
            Message message = new Message(StationManager.CurrentUser, "Message Text");
            _messages.Add(message);
            _selectedMessage = message;
        }

        #region EventsAndHandlers
        #region Loader
        internal event MessageSentHandler MessageSent;
        internal delegate void MessageSentHandler(Message message);

        internal virtual void OnMessageSent(Message message)
        {
            MessageSent?.Invoke(message);
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
