using KMA.APP_Messenger.DBModels;
using KMA.C2018.MessengerServiceInterface;

namespace KMA.C2018.Managers
{
    public class DBManager
    {
        //private static readonly List<User> Users;

        public static bool UserExists(string login)
        {
            return MessengerServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return MessengerServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            MessengerServiceWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = MessengerServiceWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void AddMessage(Message message) {
            MessengerServiceWrapper.AddMessage(message);
        }
    }
}
