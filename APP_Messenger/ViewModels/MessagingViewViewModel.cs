using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using APP_Messenger.Annotations;
using APP_Messenger.Managers;
using APP_Messenger.Models;

namespace APP_Messenger.ViewModels
{
    class MessagingViewViewModel: INotifyPropertyChanged
    {

        private MessagingManager _messagingManager;

        private ObservableCollection<Message> _messages;

        private ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged("Messages");
            }
        }

        public MessagingViewViewModel()
        {
            _messagingManager.MessageSent1 += MessagingManagerOnMessageSent1;
        }

        private void MessagingManagerOnMessageSent1(Message obj)
        {
            Messages.Add(obj);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
