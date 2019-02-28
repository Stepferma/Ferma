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
    public class PlayerRepository : IRepositoryEntity<Players>
    {
        private ApplicationContext db;
        public PlayerRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(Players item)
        {
            if (item != null)
            {
                db.Players.Add(item);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Players player = db.Players.FirstOrDefault(pl => pl.IdPlayer == id);
            if (player != null)
            {
                db.Players.Remove(player);
                db.SaveChanges();
            }
        }
        public IEnumerable<Players> Find(Func<Players, bool> predicate)
        {
            return db.Players.Where(predicate);
        }
        public IEnumerable<Players> GetAll()
        {
            return db.Players;
        }
        public Players GetID(int id)
        {
            return db.Players.FirstOrDefault(player => player.IdPlayer == id);
        }
        public void Update(Players item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
