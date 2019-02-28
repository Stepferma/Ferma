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
    public class StockRepository : IRepositoryEntity<Stocks>
    {
        public ApplicationContext Database { get; set; }

        public StockRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Stocks item)
        {
            if (item != null)
            {
                Database.Stocks.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<Stocks> GetAll()
        {
            return Database.Stocks;
        }

        public Stocks GetID(int Id)
        {
            Stocks findedStock = Database.Stocks.FirstOrDefault(x => x.IdStock == Id);
            return findedStock;
        }

        public IEnumerable<Stocks> Find(Func<Stocks, bool> predicate)
        {
            return Database.Stocks.Where(predicate);
        }

        public void Update(Stocks item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Stocks deletedStock = Database.Stocks.FirstOrDefault(x => x.IdStock == id);
            if (deletedStock != null)
            {
                Database.Stocks.Remove(deletedStock);
                Database.SaveChanges();
            }
        }
    }
}
