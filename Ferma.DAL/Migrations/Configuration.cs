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
            TypeProducts egg = new TypeProducts() { IdTypeProducts = 1, Name = "����" };
            TypeProducts seeds = new TypeProducts() { IdTypeProducts = 2, Name = "������" };
            TypeProducts meats = new TypeProducts() { IdTypeProducts = 3, Name = "����" };
            TypeProducts chickens = new TypeProducts() { IdTypeProducts = 4, Name = "������" };
            TypeProducts pigs = new TypeProducts() { IdTypeProducts = 5, Name = "������" };

            Products eggs = new Products() { IdProduct = 1, IdTypeProduct = 1, Name = "����", Price = 20, BuildTime = 1 };
            Products corn = new Products() { IdProduct = 2, IdTypeProduct = 2, Name = "��������", Price = 15, BuildTime = 0.75 };
            Products millet = new Products() { IdProduct = 3, IdTypeProduct = 2, Name = "�����", Price = 10, BuildTime = 0.5 };
            Products meat = new Products() { IdProduct = 4, IdTypeProduct = 3, Name = "�������", Price = 30, BuildTime = 2 };

            TypeBuildings empty = new TypeBuildings() { IdTypeBuilding = 1, Price = 0, Name = "�����", BuildTime = 0 };
            TypeBuildings chickenCoop = new TypeBuildings() { IdTypeBuilding = 2, IdTypeProduct = 4, Price = 300, Name = "��������", BuildTime = 4 };
            TypeBuildings pigsty = new TypeBuildings() { IdTypeBuilding = 3, IdTypeProduct = 5, Price = 500, Name = "���������", BuildTime = 6 };
            TypeBuildings gardenBed = new TypeBuildings() { IdTypeBuilding = 4,IdTypeProduct = 2, Price = 250, Name = "������", BuildTime = 3 };

            context.TypeBuildings.Add(empty);
            context.TypeBuildings.Add(chickenCoop);
            context.TypeBuildings.Add(pigsty);
            context.TypeBuildings.Add(gardenBed);

            context.TypeProducts.Add(egg);
            context.TypeProducts.Add(seeds);
            context.TypeProducts.Add(meats);
            context.TypeProducts.Add(chickens);
            context.TypeProducts.Add(pigs);

            context.Products.Add(eggs);
            context.Products.Add(corn);
            context.Products.Add(millet);
            context.Products.Add(meat);
            context.SaveChanges();
        }
    }
}
