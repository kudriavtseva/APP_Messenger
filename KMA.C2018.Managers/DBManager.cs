﻿using KMA.APP_Messenger.DBModels;
using KMA.C2018.DBAdapter;
using System.Collections.ObjectModel;

namespace KMA.C2018.Managers
{
    public class DBManager
    {
        //private static readonly List<User> Users;


        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void AddMessage(Message message) {
            EntityWrapper.AddMessage(message);
        }

        public static ObservableCollection<Message> GetAllMessages(User user)
        {
            return EntityWrapper.GetAllMessages(user);
        }
    }
}
