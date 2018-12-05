using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APP_Messenger.DBModels;
using KMA.C2018.ServiceInterface;

namespace KMA.C2018.MessengerServiceInterface
{
    public class MessengerServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IMessengerContract>("Server"))
            {
                IMessengerContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IMessengerContract>("Server"))
            {
                IMessengerContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var myChannelFactory = new ChannelFactory<IMessengerContract>("Server"))
            {
                IMessengerContract client = myChannelFactory.CreateChannel();
                return client.GetUserByGuid(guid);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<IMessengerContract>("Server"))
            {
                IMessengerContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddMessage(Message message)
        {
            using (var myChannelFactory = new ChannelFactory<IMessengerContract>("Server"))
            {
                IMessengerContract client = myChannelFactory.CreateChannel();
                client.AddMessage(message);
            }
        }

        public static void SaveMessage(Message message)
        {
            using (var myChannelFactory = new ChannelFactory<IMessengerContract>("Server"))
            {
                IMessengerContract client = myChannelFactory.CreateChannel();
                client.SaveMessage(message);
            }
        }

        public static List<User> GetAllUsers(Guid messageGuid)
        {
            using (var myChannelFactory = new ChannelFactory<IMessengerContract>("Server"))
            {
                IMessengerContract client = myChannelFactory.CreateChannel();
                return client.GetAllUsers(messageGuid);
            }
        }
    }
}
