using APP_Messenger.Managers.Authentication;
namespace APP_Messenger.View.Authentication
{
    internal partial class LogInView
    {
        public LogInView()
        {
            InitializeComponent();
            var logInManager = new LogInManager();
            DataContext = logInManager;
        }
    }
}
