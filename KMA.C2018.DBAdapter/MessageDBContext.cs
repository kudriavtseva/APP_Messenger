using System.Data.Entity;
using KMA.APP_Messenger.DBModels;
using KMA.C2018.DBAdapter.Migrations;


namespace KMA.C2018.DBAdapter
{
    class MessageDBContext: DbContext
    {
        public MessageDBContext() : base("NewMessageDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MessageDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Message.MessageEntityConfiguration());
        }
    }
}
