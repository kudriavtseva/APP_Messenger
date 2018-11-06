using System;
using APP_Messenger.View;
using APP_Messenger.View.Authentication;
using SignUpView =  APP_Messenger.View.Authentication.SignUpView;


namespace APP_Messenger.Tools
{
    internal enum ModelsEnum
    {
        LogIn,
        SignUp,
        Messaging
    }

    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;

        private LoginView _loginView;

        private SignUpView _signUpView;

        private MessagingView _messagingView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModelsEnum model)
        {
            switch (model)
            {
                case ModelsEnum.LogIn:
                    _contentWindow.ContentControl.Content = _loginView ?? (_loginView = new LoginView());
                    break;
                case ModelsEnum.SignUp:
                    _contentWindow.ContentControl.Content = _signUpView ?? (_signUpView = new SignUpView());
                    break;
                case ModelsEnum.Messaging:
                    _contentWindow.ContentControl.Content = _messagingView ?? (_messagingView = new MessagingView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), model, null);
            }
        }
    }
}