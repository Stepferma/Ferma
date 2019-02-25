using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Ferma.DAL.EF;
using Ferma.DAL.Entities;
using Ferma.DAL.Identity;
using Ferma.DAL.Interfaces;

namespace Ferma.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private UserRepository userRepository;
        private ApplicationUserManager userManager;
       

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public UnitOfWork()
        {
            db = new ApplicationContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        }
        public IRepository<ClientProfile> ClientProfile
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
       
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
