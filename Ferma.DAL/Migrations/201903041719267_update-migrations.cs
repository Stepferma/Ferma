namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Farms", "IdPlayer", c => c.Int(nullable: false));
            AlterColumn("dbo.Farms", "IdStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Fields", "IdBuilding", c => c.Int(nullable: false));
            AlterColumn("dbo.Fields", "IdFarm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fields", "IdFarm", c => c.Int());
            AlterColumn("dbo.Fields", "IdBuilding", c => c.Int());
            AlterColumn("dbo.Farms", "IdStock", c => c.Int());
            AlterColumn("dbo.Farms", "IdPlayer", c => c.Int());
        }
    }
}
