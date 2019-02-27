namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_Stocks : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stocks");
        }
    }
}
