namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Stock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "IdPlayer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "IdPlayer");
        }
    }
}
