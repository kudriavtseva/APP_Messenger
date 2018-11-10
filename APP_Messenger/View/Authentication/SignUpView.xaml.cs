using APP_Messenger.Managers.Authentication;
namespace APP_Messenger.View.Authentication
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView
    {
        public SignUpView()
        {
            InitializeComponent();
            var signUpManager = new SignUpManager();
            DataContext = signUpManager;
        }
    }
}
