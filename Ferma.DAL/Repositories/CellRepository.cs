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
    public class CellRepository : IRepositoryEntity<Cells>
    {
        public ApplicationContext Database { get; set; }

        public CellRepository(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Cells item)
        {
            if (item != null)
            {
                Database.Cells.Add(item);
                Database.SaveChanges();
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<Cells> GetAll()
        {
            return Database.Cells;
        }

        public Cells GetID(int Id)
        {
            Cells findedCell = Database.Cells.FirstOrDefault(x => x.IdCell == Id);
            return findedCell;
        }

        public IEnumerable<Cells> Find(Func<Cells, bool> predicate)
        {
            return Database.Cells.Where(predicate);
        }

        public void Update(Cells item)
        {
            if (item != null)
                Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Cells deletedCell = Database.Cells.FirstOrDefault(x => x.IdCell == id);
            if (deletedCell != null)
            {
                Database.Cells.Remove(deletedCell);
                Database.SaveChanges();
            }
        }
    }
}
