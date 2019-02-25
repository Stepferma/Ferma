using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;

namespace Ferma.DAL.Repositories
{
    public class UserRepository : IRepository<ClientProfile>
    {
        private ApplicationContext db;


        public UserRepository(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            return db.ClientProfile;
        }

        public ClientProfile GetID(string id)
        {
            return db.ClientProfile.Find(id);
        }

        public void Create(ClientProfile user)
        {
            db.ClientProfile.Add(user);
        }

        public void Update(ClientProfile user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public IEnumerable<ClientProfile> Find(Func<ClientProfile, Boolean> predicate)
        {
            return db.ClientProfile.Where(predicate).ToList();
        }
        public void Delete(string id)
        {
            ClientProfile user = db.ClientProfile.Find(id);
            if (user != null)
                db.ClientProfile.Remove(user);
        }
    }
}