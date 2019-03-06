namespace Ferma.DAL.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ferma.DAL.EF.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ferma.DAL.EF.ApplicationContext context)
        {
            TypeBuildings empty = new TypeBuildings() { IdTypeBuilding = 1, Price = 0, Name = "�����", BuildTime = 0 };
            TypeBuildings chickenCoop = new TypeBuildings() { IdTypeBuilding = 2, Price = 300, Name = "��������", BuildTime = 4 };
            TypeBuildings pigsty = new TypeBuildings() { IdTypeBuilding = 3, Price = 500, Name = "���������", BuildTime = 6 };
            TypeBuildings milletBed = new TypeBuildings() { IdTypeBuilding = 4, Price = 200, Name = "�����", BuildTime = 2 };
            TypeBuildings cornBed = new TypeBuildings() { IdTypeBuilding = 5, Price = 250, Name = "��������", BuildTime = 3 };

            TypeProducts egg = new TypeProducts() { IdTypeProducts = 1, Name = "����" };
            TypeProducts seeds = new TypeProducts() { IdTypeProducts = 2, Name = "������" };
            TypeProducts meats = new TypeProducts() { IdTypeProducts = 3, Name = "����" };

            Products eggs = new Products() { IdProduct = 1, IdTypeProduct = 1, Name = "����", Price = 20, BuildTime = 1 };
            Products corn = new Products() { IdProduct = 2, IdTypeProduct = 2, Name = "��������", Price = 15, BuildTime = 0.75 };
            Products millet = new Products() { IdProduct = 3, IdTypeProduct = 2, Name = "�����", Price = 10, BuildTime = 0.5 };
            Products meat = new Products() { IdProduct = 4, IdTypeProduct = 3, Name = "�������", Price = 30, BuildTime = 2 };

            context.TypeBuildings.Add(empty);
            context.TypeBuildings.Add(chickenCoop);
            context.TypeBuildings.Add(pigsty);
            context.TypeBuildings.Add(milletBed);
            context.TypeBuildings.Add(cornBed);

            context.TypeProducts.Add(egg);
            context.TypeProducts.Add(seeds);
            context.TypeProducts.Add(meats);

            context.Products.Add(eggs);
            context.Products.Add(corn);
            context.Products.Add(millet);
            context.Products.Add(meat);
            context.SaveChanges();
        }
    }
}
