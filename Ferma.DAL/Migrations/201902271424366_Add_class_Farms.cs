namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_Farms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        IdFarm = c.Int(nullable: false, identity: true),
                        IdPlayer = c.Int(),
                        IdStock = c.Int(),
                    })
                .PrimaryKey(t => t.IdFarm);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Farms");
        }
    }
}
