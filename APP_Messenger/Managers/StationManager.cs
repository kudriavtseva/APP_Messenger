using System;
using System.IO;
using System.Windows;
using APP_Messenger.Models;

namespace APP_Messenger.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }


        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}