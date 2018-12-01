using System.Collections.ObjectModel;
using System.Windows.Input;
using APP_Messenger.Models;

namespace APP_Messenger.Managers
{
    class MessagingManager 
    {

        #region Fields
        private ObservableCollection<Message> _messages;

        private ICommand _SendMessageCommand;
        #endregion
        public MessagingManager()
        {
        }

    }
}
