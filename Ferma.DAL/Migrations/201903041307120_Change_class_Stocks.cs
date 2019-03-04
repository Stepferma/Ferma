namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_class_Stocks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "Millet", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "Meat", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "Corn", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "Eggs", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "Grass");
            DropColumn("dbo.Stocks", "Seed");
            DropColumn("dbo.Stocks", "Pork");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Pork", c => c.Int());
            AddColumn("dbo.Stocks", "Seed", c => c.Int());
            AddColumn("dbo.Stocks", "Grass", c => c.Int());
            AlterColumn("dbo.Stocks", "Eggs", c => c.Int());
            DropColumn("dbo.Stocks", "Corn");
            DropColumn("dbo.Stocks", "Meat");
            DropColumn("dbo.Stocks", "Millet");
        }
    }
}
