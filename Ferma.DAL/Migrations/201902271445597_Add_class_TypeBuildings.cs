namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_TypeBuildings : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.TypeBuildings");
        }
    }
}
