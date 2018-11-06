using APP_Messenger.Tools;
using  APP_Messenger.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
