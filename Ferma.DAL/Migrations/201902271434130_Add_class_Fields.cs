namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_Fields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        IdField = c.Int(nullable: false, identity: true),
                        IdBuilding = c.Int(),
                        IdFarm = c.Int(),
                    })
                .PrimaryKey(t => t.IdField);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fields");
        }
    }
}
