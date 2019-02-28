using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;
using System.Data.Entity;

namespace Ferma.DAL.Repositories
{
    public class FarmRepository : IRepositoryEntity<Farms>
    {
        public ApplicationContext Database { get; set; }

        public FarmRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Farms item)
        {
            if (item != null)
            {
                Database.Farms.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<Farms> GetAll()
        {
            return Database.Farms;
        }

        public Farms GetID(int Id)
        {
            Farms findedFarm = Database.Farms.FirstOrDefault(x => x.IdFarm == Id);
            return findedFarm;
        }

        public IEnumerable<Farms> Find(Func<Farms, bool> predicate)
        {
            return Database.Farms.Where(predicate);
        }

        public void Update(Farms item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Farms deletedFarm = Database.Farms.FirstOrDefault(x => x.IdFarm == id);
            if (deletedFarm != null)
            {
                Database.Farms.Remove(deletedFarm);
                Database.SaveChanges();
            }
        }
    }
}
