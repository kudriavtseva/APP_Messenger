using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using APP_Messenger.Managers.Authentication;
using APP_Messenger.Models;
using APP_Messenger.Tools;

namespace APP_Messenger.Managers
{
    class MessagingManager : INotifyPropertyChanged
    {

        #region Fields
        private ObservableCollection<Message> _messages;

        private ICommand _SendMessageCommand;
        #endregion
        public MessagingManager() {
            StartMessaging();
                // PropertyChanged += OnPropertyChanged();
        }

        public ICommand SendMessageCommand => _SendMessageCommand ?? (_SendMessageCommand = new RelayCommand<object>(SendMessageExecute));

        private void SendMessageExecute(object obj)
        {
            Message message = new Message(StationManager.CurrentUser, "Message...");
            _messages.Add(message);
        }

        private void StartMessaging()
        {
            _messages = new ObservableCollection<Message>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal event MessageSentHandler MessageSent;
        internal delegate void MessageSentHandler(Message message);

        public event Action<Message> MessageSent1;

        internal virtual void OnWalletSentChanged(Message message)
        {
            MessageSent?.Invoke(message);
            MessageSent1?.Invoke(message);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
