using APP_Messenger.Managers;
using APP_Messenger.Managers.Authentication;
using APP_Messenger.Models;
using APP_Messenger.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APP_Messenger.ViewModels
{
    class MessagingViewViewModel : INotifyPropertyChanged
    {
        #region Fileds
        private PhatiqueDialogManager _bot = new PhatiqueDialogManager();
        private string _messageField;
        private Message _selectedMessage;
        private ObservableCollection<Message> _messages;

        #endregion
        private ICommand _SendMessageCommand;

        public ICommand SendMessageCommand => _SendMessageCommand ?? (_SendMessageCommand = new RelayCommand<object>(SendMessage));

        public string MessageField
        {
            get => _messageField;
            set
            {
                _messageField = value;
                OnPropertyChanged();
            }
        }

        public Message SelectedMessage
        {
            get => _selectedMessage;
            set
            {
                _selectedMessage = value;
                _selectedMessage.Text = value.Sender + " :" + value.Text;
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
            if (propertyChangedEventArgs.PropertyName == "MessageField")
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
            Message greet = _bot.StartConversation(StationManager.CurrentUser);
            _selectedMessage = greet;
            _messages.Add(greet);
        }

        private void SendMessage(object o)
        {
            Message message = new Message(StationManager.CurrentUser, MessageField, StationManager.CurrentUser.Login);
            _messages.Add(message);
            message.Text = message.Sender + ": " + message.Text;
            _selectedMessage = message;
            MessageField = "";
            GetAnswer(message);
        }

        private async void GetAnswer(Message message)
        {
            await Task.Delay(750);
            Message responce = _bot.Respond(message, StationManager.CurrentUser);
            _messages.Add(responce);
            responce.Text = responce.Sender + ": " + responce.Text;
            _selectedMessage = responce;
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
