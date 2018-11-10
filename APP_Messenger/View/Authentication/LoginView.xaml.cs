using APP_Messenger.Managers.Authentication;

namespace APP_Messenger.View
{
    internal partial class LoginView
    {
        internal LoginView()
        {
            InitializeComponent();
            var loginManager = new LoginManager();
            DataContext = loginManager;
        }
    }
}
