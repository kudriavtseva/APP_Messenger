using System;
using System.Collections.Generic;
using KMA.C2018.DBAdapter;
using KMA.APP_Messenger.DBModels;
using KMA.C2018.ServiceInterface;

namespace KMA.C2018.MessengerService
{
    class MessengerService : IMessengerContract
    {
        public bool UserExists(string login) => EntityWrapper.UserExists(login);

        public User GetUserByLogin(string login) => EntityWrapper.GetUserByLogin(login);

        public User GetUserByGuid(Guid guid) => EntityWrapper.GetUserByGuid(guid);

        public void AddUser(User user) => EntityWrapper.AddUser(user);

        public List<User> GetAllUsers(Guid messageGuid) => EntityWrapper.GetAllUsers(messageGuid);

        public void AddMessage(Message message) => EntityWrapper.AddMessage(message);

        public void SaveMessage(Message message) => EntityWrapper.SaveMessage(message);
    }
}
