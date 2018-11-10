using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using APP_Messenger.Models;
using  APP_Messenger.Properties;
using APP_Messenger.Tools;


namespace APP_Messenger.Managers.Authentication
{
    sealed class LoginManager : INotifyPropertyChanged
    {
        private string _password;
        private string _login;

        private ICommand _closeCommand;
        private ICommand _logInCommand;
        private ICommand _signUpCommand;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));

        public ICommand LoginCommand => _logInCommand ?? (_logInCommand = new RelayCommand<object>(LoginExecute));

        public ICommand SignUpCommand => _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute));


        internal LoginManager()
        {
        }

        private void LoginExecute(object obj)
        {
            User currentUser;
            try
            {
                currentUser = DBManager.GetUserByLogin(_login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.LogIn_FailedToGetUser, Environment.NewLine,
                    ex.Message));
                return;
            }
            if (currentUser == null)
            {
                MessageBox.Show(String.Format(Resources.LogIn_UserDoesntExist, _login));
                return;
            }
            try
            {
                if (!currentUser.CheckPassword(_password))
                {
                    MessageBox.Show(Resources.LogIn_WrongPassword);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.LogIn_FailedToValidatePassword, Environment.NewLine,
                    ex.Message));
                return;
            }
            StationManager.CurrentUser = currentUser;
            NavigationManager.Instance.Navigate(ModelsEnum.Messaging);
        }

        private void SignUpExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModelsEnum.SignUp);
        }

        private void CloseExecute(object obj)
        {
            StationManager.CloseApp();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
