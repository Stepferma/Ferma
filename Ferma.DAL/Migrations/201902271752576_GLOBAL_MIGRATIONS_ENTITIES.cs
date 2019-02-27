namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GLOBAL_MIGRATIONS_ENTITIES : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        IdBuilding = c.Int(nullable: false, identity: true),
                        IdTypeBuilding = c.Int(),
                        IsActive = c.Boolean(),
                        DateStart = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdBuilding);
            
            CreateTable(
                "dbo.Cells",
                c => new
                    {
                        IdCell = c.Int(nullable: false, identity: true),
                        IdField = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCell);
            
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        IdFarm = c.Int(nullable: false, identity: true),
                        IdPlayer = c.Int(),
                        IdStock = c.Int(),
                    })
                .PrimaryKey(t => t.IdFarm);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        IdField = c.Int(nullable: false, identity: true),
                        IdBuilding = c.Int(),
                        IdFarm = c.Int(),
                    })
                .PrimaryKey(t => t.IdField);

            CreateTable(
                    "dbo.Players",
                    c => new
                    {
                        IdPlayer = c.Int(nullable: false, identity: true),
                        Money = c.Int(nullable: false),
                        IdUser = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdPlayer);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        IdTypeProduct = c.Int(nullable: false),
                        DateStart = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdProduct);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        IdStock = c.Int(nullable: false, identity: true),
                        Grass = c.Int(),
                        Seed = c.Int(),
                        Pork = c.Int(),
                        Eggs = c.Int(),
                    })
                .PrimaryKey(t => t.IdStock);
            
            CreateTable(
                "dbo.TypeBuildings",
                c => new
                    {
                        IdTypeBuilding = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Price = c.Int(nullable: false),
                        BuildTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdTypeBuilding);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "IdUser", "dbo.Users");
            DropIndex("dbo.Players", new[] { "IdUser" });
            DropTable("dbo.TypeBuildings");
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
            DropTable("dbo.Players");
            DropTable("dbo.Fields");
            DropTable("dbo.Farms");
            DropTable("dbo.Cells");
            DropTable("dbo.Buildings");
        }
    }
}
