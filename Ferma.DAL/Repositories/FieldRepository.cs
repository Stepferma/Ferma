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
    public class FieldRepository : IRepositoryEntity<Fields>
    {
        public ApplicationContext Database { get; set; }

        public FieldRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Fields item)
        {
            if (item != null)
            {
                Database.Fields.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<Fields> GetAll()
        {
            return Database.Fields;
        }

        public Fields GetID(int Id)
        {
            Fields findedField = Database.Fields.FirstOrDefault(x => x.IdField == Id);
            return findedField;
        }

        public IEnumerable<Fields> Find(Func<Fields, bool> predicate)
        {
            return Database.Fields.Where(predicate);
        }

        public void Update(Fields item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Fields deletedField = Database.Fields.FirstOrDefault(x => x.IdField == id);
            if (deletedField != null)
            {
                Database.Fields.Remove(deletedField);
                Database.SaveChanges();
            }
        }
    }
}
