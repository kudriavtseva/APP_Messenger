using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using  APP_Messenger.Properties;
using APP_Messenger.Tools;


namespace APP_Messenger.Managers.Authentication
{
    sealed class LoginManager : INotifyPropertyChanged
    {
        private string _password;
        private string _login;

        private ICommand _closeCommand;
        private ICommand _loginCommand;
        private ICommand _signupCommand;

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

        public ICommand CloseCommand
        {
            get => _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
        }

        public ICommand LoginCommand
        {
            get => _loginCommand ?? (_loginCommand = new RelayCommand<object>(LoginExecute, LoginCanExecute));
        }

        public ICommand SignUpCommand
        {
            get => _signupCommand ?? (_signupCommand = new RelayCommand<object>(SignUpExecute));
        }



        internal LoginManager()
        {
        }

        private void LoginExecute(object obj)
        {
            LoaderManager.Instance.S
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
