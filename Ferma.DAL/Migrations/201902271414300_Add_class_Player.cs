namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_Player : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ClientProfiles", newName: "Users");
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        IdPlayer = c.Int(nullable: false, identity: true),
                        Money = c.Int(nullable: false),
                        IdUser = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdPlayer)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "IdUser", "dbo.Users");
            DropIndex("dbo.Players", new[] { "IdUser" });
            DropTable("dbo.Players");
            RenameTable(name: "dbo.Users", newName: "ClientProfiles");
        }
    }
}
