using System.Windows;
using System.Windows.Controls;
using APP_Messenger.Managers;

namespace APP_Messenger.View
{
    /// <summary>
    /// Interaction logic for MessagingView.xaml
    /// </summary>
    public partial class MessagingView
    {
        public MessagingView()
        {
            InitializeComponent();
            Visibility = Visibility.Visible;
            var messagingManager = new MessagingManager();
            messagingManager.MessageSent += OnMessageSent;
            DataContext = messagingManager;
        }

        private void OnMessageSent(Models.Message message)
        {
            //currentWalletConfigurationView.DataContext = new WalletConfigurationViewModel(message);
        }
    }
}