using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;

namespace Ferma.DAL.Repositories
{
    public class UserRepository : IRepository<UsersProfiles>
    {
        private ApplicationContext db;


        public UserRepository(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<UsersProfiles> GetAll()
        {
            return db.UsersProfiles;
        }

        public UsersProfiles GetID(string id)
        {
            return db.UsersProfiles.Find(id);
        }

        public void Create(UsersProfiles user)
        {
            db.UsersProfiles.Add(user);
        }

        public void Update(UsersProfiles user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public IEnumerable<UsersProfiles> Find(Func<UsersProfiles, Boolean> predicate)
        {
            return db.UsersProfiles.Where(predicate).ToList();
        }
        public void Delete(string id)
        {
            UsersProfiles user = db.UsersProfiles.Find(id);
            if (user != null)
                db.UsersProfiles.Remove(user);
        }
    }
}