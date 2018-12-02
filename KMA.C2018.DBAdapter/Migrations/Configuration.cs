using System.Data.Entity.Migrations;

namespace KMA.C2018.DBAdapter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MessageDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MessageDBContext context)
        {
        }
    }
}
