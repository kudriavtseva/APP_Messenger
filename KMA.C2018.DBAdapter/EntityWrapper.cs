using KMA.APP_Messenger.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace KMA.C2018.DBAdapter
{
    public static class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (MessageDBContext context = new MessageDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new MessageDBContext())
            {
                return context.Users.Include(u => u.Messages).FirstOrDefault(u => u.Login == login);
            }
        }

        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new MessageDBContext())
            {
                return context.Users.Include(u => u.Messages).FirstOrDefault(u => u.Guid == guid);
            }
        }

        public static List<User> GetAllUsers(Guid messageGuid)
        {
            using (var context = new MessageDBContext())
            {
                return context.Users.Where(u => u.Messages.All(r => r.Guid != messageGuid)).ToList();
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new MessageDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddMessage(Message message)
        {
            using (var context = new MessageDBContext())
            {
                context.Messages.Add(message);
            }
        }

        public static void SaveMessage(Message message)
        {
            using (var context = new MessageDBContext())
            {
                context.Entry(message).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
