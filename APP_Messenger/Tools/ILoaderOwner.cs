using System.ComponentModel;
using System.Windows;

namespace APP_Messenger.Managers
{
    internal interface ILoaderOwner : INotifyPropertyChanged

    {
        Visibility LoaderVisibility { get; set; }
        bool IsEnabled { get; set; }
    }
}