namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_Products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        IdTypeProduct = c.Int(nullable: false),
                        DateStart = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdProduct);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
