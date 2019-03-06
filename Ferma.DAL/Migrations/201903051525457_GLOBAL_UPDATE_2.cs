namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GLOBAL_UPDATE_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cells", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cells", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Fields", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Name", c => c.String(maxLength: 30));
            AddColumn("dbo.Products", "BuildTime", c => c.Double(nullable: false));
            AddColumn("dbo.TypeBuildings", "IdTypeProduct", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings", "IdTypeBuilding", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Buildings", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Farms", "IdPlayer", c => c.Int(nullable: false));
            AlterColumn("dbo.Farms", "IdStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Fields", "IdBuilding", c => c.Int(nullable: false));
            AlterColumn("dbo.Fields", "IdFarm", c => c.Int(nullable: false));
            AlterColumn("dbo.TypeBuildings", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.TypeBuildings", "BuildTime", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "DateStart");
            DropColumn("dbo.TypeProducts", "Price");
            DropColumn("dbo.TypeProducts", "BuildTime");
            DropColumn("dbo.TypeProducts", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeProducts", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.TypeProducts", "BuildTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.TypeProducts", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "DateStart", c => c.DateTime());
            AlterColumn("dbo.TypeBuildings", "BuildTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TypeBuildings", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Fields", "IdFarm", c => c.Int());
            AlterColumn("dbo.Fields", "IdBuilding", c => c.Int());
            AlterColumn("dbo.Farms", "IdStock", c => c.Int());
            AlterColumn("dbo.Farms", "IdPlayer", c => c.Int());
            AlterColumn("dbo.Buildings", "DateStart", c => c.DateTime());
            AlterColumn("dbo.Buildings", "IsActive", c => c.Boolean());
            AlterColumn("dbo.Buildings", "IdTypeBuilding", c => c.Int());
            DropColumn("dbo.TypeBuildings", "IdTypeProduct");
            DropColumn("dbo.Products", "BuildTime");
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Fields", "IsActive");
            DropColumn("dbo.Cells", "DateStart");
            DropColumn("dbo.Cells", "IsActive");
        }
    }
}
