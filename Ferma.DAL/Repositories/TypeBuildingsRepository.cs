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
    class TypeBuildingsRepository : IRepositoryEntity<TypeBuildings>
    {
        public ApplicationContext Database { get; set; }

        public TypeBuildingsRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(TypeBuildings item)
        {
            if (item != null)
            {
                Database.TypeBuildings.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<TypeBuildings> GetAll()
        {
            return Database.TypeBuildings;
        }

        public TypeBuildings GetID(int Id)
        {
            TypeBuildings findedTypeBuilding = Database.TypeBuildings.FirstOrDefault(x => x.IdTypeBuilding == Id);
            return findedTypeBuilding;
        }

        public IEnumerable<TypeBuildings> Find(Func<TypeBuildings, bool> predicate)
        {
            return Database.TypeBuildings.Where(predicate);
        }

        public void Update(TypeBuildings item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TypeBuildings deletedTypeBuilding = Database.TypeBuildings.FirstOrDefault(x => x.IdTypeBuilding == id);
            if (deletedTypeBuilding != null)
            {
                Database.TypeBuildings.Remove(deletedTypeBuilding);
                Database.SaveChanges();
            }
        }
    }
}
