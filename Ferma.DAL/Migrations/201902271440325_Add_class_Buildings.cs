namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_Buildings : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Buildings");
        }
    }
}
