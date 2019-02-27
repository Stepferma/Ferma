namespace Ferma.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GLOBAL_UPDATE_MIGRATION : DbMigration
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
                        IdUser = c.String(),
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsersProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersProfiles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.UsersProfiles", new[] { "Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UsersProfiles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TypeBuildings");
            DropTable("dbo.Stocks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Players");
            DropTable("dbo.Fields");
            DropTable("dbo.Farms");
            DropTable("dbo.Cells");
            DropTable("dbo.Buildings");
        }
    }
}
