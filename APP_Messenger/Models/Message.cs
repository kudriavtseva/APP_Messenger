using System;

namespace APP_Messenger.Models
{
    [Serializable]
    class Message
    {
        private User _user;
        private string _text;

        #region Constructor

        public Message(User usr, string text) : this()
        {
            _user = usr;
            _text = text;
        }

        private Message()
        {
        }
        #endregion

        internal User CurrentUser
        {
            get => _user;
        }

        internal string Text
        {
            get => _text;
        }
    }
}