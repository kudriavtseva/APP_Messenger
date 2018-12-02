using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using APP_Messenger.Annotations;
using KMA.APP_Messenger.DBModels;

namespace APP_Messenger.Models
{
    public class MessageUIModel : INotifyPropertyChanged
    {
        #region Fields
        private Message _message;
        #endregion

        #region Properties
        internal Message Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get { return _message.Text; }
            set
            {
                _message.Text = value;
                OnPropertyChanged();
            }
        }

        public string Sender
        {
            get { return _message.Sender; }
            set
            {
                _message.Sender = value;
                OnPropertyChanged();
            }
        }

        public Guid Guid
        {
            get { return _message.Guid; }
        }

        #endregion

        public MessageUIModel(Message message)
        {
            _message = message;
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
