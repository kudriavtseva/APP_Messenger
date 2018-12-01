using System;
using System.Collections.ObjectModel;

namespace APP_Messenger.Models
{
    [Serializable]
    public class Message
    {
        #region Fields
        private Guid _guid;
        private string _text;
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
        #endregion

        #region Constructor


        public Message(User user, string text) : this()
        {

            _guid = Guid.NewGuid();
            _text = text;
            user.Messages.Add(this);
        }

        private Message()
        {
        }
        #endregion

        public override string ToString()
        {
            return Text;
        }
    }
}