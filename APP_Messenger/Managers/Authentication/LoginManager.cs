using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using APP_Messenger.Tools;
using KMA.APP_Messenger.DBModels;
using KMA.C2018.APP_Messenger.Properties;
using KMA.C2018.Managers;

namespace APP_Messenger.Managers.Authentication
{
    sealed class LogInManager : INotifyPropertyChanged
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

        public ICommand LogInCommand => _logInCommand ?? (_logInCommand = new RelayCommand<object>(LogInExecute, LogInCanExecute));

        public ICommand SignUpCommand => _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute));


        internal LogInManager()
        {
        }

        private async void LogInExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
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
                    return false;
                }
                if (currentUser == null)
                {
                    MessageBox.Show(String.Format(Resources.LogIn_UserDoesntExist, _login));
                    return false;
                }
                try
                {
                    if (!currentUser.CheckPassword(_password))
                    {
                        MessageBox.Show(Resources.LogIn_WrongPassword);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format(Resources.LogIn_FailedToValidatePassword, Environment.NewLine,
                        ex.Message));
                    return false;
                }
                StationManager.CurrentUser = currentUser;
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ModelsEnum.Messaging);
        }

        private bool LogInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) || !String.IsNullOrWhiteSpace(_password);
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
