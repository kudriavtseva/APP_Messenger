using APP_Messenger.Managers;
using APP_Messenger.Managers.Authentication;
using APP_Messenger.Models;
using APP_Messenger.Tools;
using KMA.APP_Messenger.DBModels;
using KMA.C2018.APP_Messenger.Properties;
using KMA.C2018.Managers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Exception = System.Exception;

namespace APP_Messenger.ViewModels
{
    class MessagingViewModel : INotifyPropertyChanged
    {
        #region Fileds
        private PhatiqueDialogManager _bot = new PhatiqueDialogManager();
        private string _messageField;
        private ObservableCollection<MessageUIModel> _messages;
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

        public ObservableCollection<MessageUIModel> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }


        public MessagingViewModel()
        {

            StartMessaging();
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "MessageField")
                OnMessageSent(_messages);
        }

        private void StartMessaging()
        {
            _messages = new ObservableCollection<MessageUIModel>();
            try
            {
                foreach (var message in DBManager.GetAllMessages(StationManager.CurrentUser))
                {
                    _messages.Add(new MessageUIModel(message));
                }
            }
            catch (Exception)
            {
            }

            MessageUIModel greet = _bot.StartConversation(StationManager.CurrentUser);
            _messages.Add(greet);
        }

        private void SendMessage(object o)
        {
            Message message = new Message(StationManager.CurrentUser, MessageField,
                StationManager.CurrentUser.Login);
            DBManager.AddMessage(message);

            var messageUIModel = new MessageUIModel(message);
            try
            {
                _messages.Add(messageUIModel);
            }
            catch (Exception)
            {
                MessageBox.Show(String.Format(Resources.Messaging_FailedToSend, Environment.NewLine,
                    MessageField));
            }
            message.Text = message.Sender + ": " + message.Text;
            MessageField = "";
            Task.Delay(750).Wait();
            GetAnswer(messageUIModel, StationManager.CurrentUser);

        }

        private void GetAnswer(MessageUIModel messageUIModel, User user)
        {
            try
            {
                MessageUIModel responce = _bot.Respond(messageUIModel, user);
                Messages.Add(responce);
                responce.Text = responce.Sender + ": " + responce.Text;
            }
            catch (Exception)
            {
                MessageBox.Show(String.Format(Resources.Messaging_FailedToSend, Environment.NewLine));
            }
        }

        #region EventsAndHandlers
        #region Loader
        internal event MessageSentHandler MessageSent;
        internal delegate void MessageSentHandler(ObservableCollection<MessageUIModel> messages);

        internal virtual void OnMessageSent(ObservableCollection<MessageUIModel> messages)
        {
            MessageSent?.Invoke(messages);
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
