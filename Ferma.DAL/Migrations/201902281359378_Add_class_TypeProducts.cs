namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_class_TypeProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeProducts",
                c => new
                    {
                        IdTypeProducts = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Price = c.Int(nullable: false),
                        BuildTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTypeProducts);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeProducts");
        }
    }
}
