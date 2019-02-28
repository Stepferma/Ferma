using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;

namespace Ferma.DAL.Repositories
{
    public class ProductRepository : IRepositoryEntity<Products>
    {
        public ApplicationContext Database { get; set; }

        public ProductRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Products item)
        {
            if (item != null)
            {
                Database.Products.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<Products> GetAll()
        {
            return Database.Products;
        }

        public Products GetID(int Id)
        {
            Products findedProduct = Database.Products.FirstOrDefault(x => x.IdProduct == Id);
            return findedProduct;
        }

        public IEnumerable<Products> Find(Func<Products, bool> predicate)
        {
            return Database.Products.Where(predicate);
        }

        public void Update(Products item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Products deletedProduct = Database.Products.FirstOrDefault(x => x.IdProduct == id);
            if (deletedProduct != null)
            {
                Database.Products.Remove(deletedProduct);
                Database.SaveChanges();
            }
        }
    }
}
