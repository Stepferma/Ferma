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
    public class BuildingRepository : IRepositoryEntity<Buildings>
    {
        public ApplicationContext Database { get; set; }

        public BuildingRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Buildings item)
        {
            if (item != null)
            {
                Database.Buildings.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<Buildings> GetAll()
        {
            return Database.Buildings;
        }

        public Buildings GetID(int Id)
        {
            Buildings findedBuilding = Database.Buildings.FirstOrDefault(x => x.IdBuilding == Id);
            return findedBuilding;
        }

        public IEnumerable<Buildings> Find(Func<Buildings, bool> predicate)
        {
            return Database.Buildings.Where(predicate);
        }

        public void Update(Buildings item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Buildings deletedBuilding = Database.Buildings.FirstOrDefault(x => x.IdBuilding == id);
            if (deletedBuilding != null)
            {
                Database.Buildings.Remove(deletedBuilding);
                Database.SaveChanges();
            }
        }
    }
}
