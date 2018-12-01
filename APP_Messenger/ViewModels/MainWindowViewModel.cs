using APP_Messenger.Tools;
using  APP_Messenger.Managers;

namespace APP_Messenger.ViewModels
{
    class MainWindowViewModel
    {
        internal void StartApplication()
        {
            NavigationManager.Instance.Navigate(StationManager.CurrentUser != null ? ModelsEnum.Messaging : ModelsEnum.LogIn);
        }
    }
}
