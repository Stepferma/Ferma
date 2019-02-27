namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_Cells : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cells",
                c => new
                    {
                        IdCell = c.Int(nullable: false, identity: true),
                        IdField = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCell);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cells");
        }
    }
}
