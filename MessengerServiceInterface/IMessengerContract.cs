using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APP_Messenger.DBModels;

namespace KMA.C2018.ServiceInterface
{
    [ServiceContract]
    public interface IMessengerContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        List<User> GetAllUsers(Guid messengerGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddMessage(Message message);
        [OperationContract]
        void SaveMessage(Message message);
    }
}
