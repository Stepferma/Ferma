﻿using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Interfaces;

namespace Ferma.DAL.Repositories
{
    public class UserManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public UserManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Users item)
        {
            Database.Users.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}