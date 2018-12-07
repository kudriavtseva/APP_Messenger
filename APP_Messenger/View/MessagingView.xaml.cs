using System.Windows;
using APP_Messenger.ViewModels;

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
            var messagingViewModel = new MessagingViewModel();
            DataContext = messagingViewModel;
        }
    }
}