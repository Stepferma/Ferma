using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;

namespace Ferma.DAL.Repositories
{
    public class UserRepository : IRepository<Users>
    {
        private ApplicationContext db;


        public UserRepository(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users;
        }

        public Users GetID(string id)
        {
            return db.Users.Find(id);
        }

        public void Create(Users user)
        {
            db.Users.Add(user);
        }

        public void Update(Users user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public IEnumerable<Users> Find(Func<Users, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }
        public void Delete(string id)
        {
            Users user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}