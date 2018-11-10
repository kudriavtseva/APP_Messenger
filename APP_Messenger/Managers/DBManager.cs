﻿using APP_Messenger.Models;
using System.Collections.Generic;
using System.Linq;

namespace APP_Messenger.Managers
{
    public class DBManager
    {
        private static readonly List<User> Users = new List<User>();

        public static bool UserExists(string login)
        {
            return Users.Any(u => u.Login == login);
        }

        public static User GetUserByLogin(string login)
        {
            return Users.FirstOrDefault(u => u.Login == login);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }


    }
}
