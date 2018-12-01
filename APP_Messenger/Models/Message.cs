using System;

namespace APP_Messenger.Models
{
    [Serializable]
    public class Message
    {
        #region Fields
        private Guid _guid;
        private string _text;
        private string _sender;
        #endregion

        #region Proprties
        public Guid Guid {
            get => _guid;
            set => _guid = value;
        }

        public string Text {
            get => _text;
            set => _text = value;
        }

        public string Sender {
            get => _sender;
            set => _sender = value;
        }
        #endregion

        #region Constructor

        public Message(User user, string text, string sender) : this()
        {
            _guid = Guid.NewGuid();
            _text = text;
            _sender = sender;
            user.Messages.Add(this);
        }

        private Message()
        {
        }
        #endregion

        public override string ToString()
        {
            return Sender + " " + Text;
        }
    }
}