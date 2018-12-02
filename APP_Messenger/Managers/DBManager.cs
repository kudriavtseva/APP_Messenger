using APP_Messenger.Models;
using APP_Messenger.Tools;
using System.Collections.Generic;
using System.Linq;

namespace APP_Messenger.Managers
{
    internal class DBManager
    {
        private static readonly List<User> Users;

        #region Constructor
        static DBManager()
        {
            Users = SerializationManager.Deserialize<List<User>>(FileFolderHelper.StorageFilePath) ?? new List<User>();
        }
        #endregion

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
            SaveChanges();
        }

        private static void SaveChanges()
        {
            SerializationManager.Serialize(Users, FileFolderHelper.StorageFilePath);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = Users.FirstOrDefault(u => u.Guid == userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void UpdateUser(User currentUser)
        {
            SaveChanges();
        }
    }
}
