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
        private FarmRepository farmRepository;
        private PlayerRepository playerRepository;
        private BuildingRepository buildingRepository;
        private ProductRepository productRepository;
        private StockRepository stockRepository;


        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public UnitOfWork()
        {
            db = new ApplicationContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        }
        public IRepository<UsersProfiles> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepositoryEntity<Farms> Farms
        {
            get
            {
                if (farmRepository == null)
                    farmRepository = new FarmRepository(db);
                return farmRepository;
            }
        }

        public IRepositoryEntity<Players> Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(db);
                return playerRepository;
            }
        }

        public IRepositoryEntity<Buildings> Buildings
        {
            get
            {
                if (buildingRepository == null)
                    buildingRepository = new BuildingRepository(db);
                return buildingRepository;
            }
        }

        public IRepositoryEntity<Products> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepositoryEntity<Stocks> Stocks
        {
            get
            {
                if (stockRepository == null)
                    stockRepository = new StockRepository(db);
                return stockRepository;
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
