using System;
using APP_Messenger.Models;

namespace APP_Messenger.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }

        public static void Initialize()
        {
        }


        internal static void CloseApp()
        {
            Environment.Exit(1);
        }
    }
}