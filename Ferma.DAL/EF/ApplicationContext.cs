using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ferma.DAL.Entities;
using System;

namespace Ferma.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("name=DefaultConnection") { }

        public DbSet<UsersProfiles> UsersProfiles { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Farms> Farms { get; set; }  
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<Buildings> Buildings { get; set; }
        public DbSet<TypeBuildings> TypeBuildings { get; set; }
        public DbSet<Cells> Cells { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<TypeProducts> TypeProducts { get; set; }
    }
    class ContextInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            TypeBuildings empty = new TypeBuildings() { IdTypeBuilding = 1, Price = 0, Name = "Пусто", BuildTime = 0 };
            TypeBuildings chickenCoop = new TypeBuildings() { IdTypeBuilding = 2, Price = 300, Name = "Курятник", BuildTime = 4 };
            TypeBuildings pigsty = new TypeBuildings() { IdTypeBuilding = 3, Price = 500, Name = "Свинарник", BuildTime = 6 };
            TypeBuildings milletBed = new TypeBuildings() { IdTypeBuilding = 4, Price = 200, Name = "Пшено", BuildTime = 2 };
            TypeBuildings cornBed = new TypeBuildings() { IdTypeBuilding = 5, Price = 250, Name = "Кукуруза", BuildTime = 3 };

            TypeProducts egg = new TypeProducts() { IdTypeProducts = 1, Name = "Яйца" };
            TypeProducts seeds = new TypeProducts() { IdTypeProducts = 2, Name = "Семена" };
            TypeProducts meats = new TypeProducts() { IdTypeProducts = 3, Name = "Мясо" };

            Products eggs = new Products() { IdProduct = 1, IdTypeProduct = 1, Name = "Яйцо", Price = 20, BuildTime = 1 };
            Products corn = new Products() { IdProduct = 2, IdTypeProduct = 2, Name = "Кукуруза", Price = 15, BuildTime = 0.75 };
            Products millet = new Products() { IdProduct = 3, IdTypeProduct = 2, Name = "Пшено", Price = 10, BuildTime = 0.5 };
            Products meat = new Products() { IdProduct = 4, IdTypeProduct = 3, Name = "Свинина", Price = 30, BuildTime = 2 };

            db.TypeBuildings.Add(empty);
            db.TypeBuildings.Add(chickenCoop);
            db.TypeBuildings.Add(pigsty);
            db.TypeBuildings.Add(milletBed);
            db.TypeBuildings.Add(cornBed);

            db.TypeProducts.Add(egg);
            db.TypeProducts.Add(seeds);
            db.TypeProducts.Add(meats);

            db.Products.Add(eggs);
            db.Products.Add(corn);
            db.Products.Add(millet);
            db.Products.Add(meat);
            db.SaveChanges();
        }
    }
}
