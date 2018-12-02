namespace KMA.C2018.DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Email = c.String(),
                    Login = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    LastLoginDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Guid);

            CreateTable(
                "dbo.Message",
                c => new
                {
                    Guid = c.Guid(nullable: false),
                    Text = c.String(nullable: false),
                    Sender = c.String(nullable: false),
                    UserGuid = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Users", t => t.UserGuid, cascadeDelete: true)
                .Index(t => t.UserGuid);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Message", "UserGuid", "dbo.Users");
            DropIndex("dbo.Message", new[] { "UserGuid" });
            DropTable("dbo.Message");
            DropTable("dbo.Users");
        }
    }
}
