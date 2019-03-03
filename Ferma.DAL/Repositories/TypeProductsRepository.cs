using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Repositories
{
    class TypeProductsRepository : IRepositoryEntity<TypeProducts>
    {
        public ApplicationContext Database { get; set; }

        public TypeProductsRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(TypeProducts item)
        {
            if (item != null)
            {
                Database.TypeProducts.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<TypeProducts> GetAll()
        {
            return Database.TypeProducts;
        }

        public TypeProducts GetID(int Id)
        {
            TypeProducts findedTypeProduct = Database.TypeProducts.FirstOrDefault(x => x.IdTypeProducts == Id);
            return findedTypeProduct;
        }

        public IEnumerable<TypeProducts> Find(Func<TypeProducts, bool> predicate)
        {
            return Database.TypeProducts.Where(predicate);
        }

        public void Update(TypeProducts item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TypeProducts deletedTypeProduct = Database.TypeProducts.FirstOrDefault(x => x.IdTypeProducts == id);
            if (deletedTypeProduct != null)
            {
                Database.TypeProducts.Remove(deletedTypeProduct);
                Database.SaveChanges();
            }
        }
    }
}
