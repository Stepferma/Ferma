using Ferma.DAL.Entities;
using Ferma.DAL.Identity;

namespace Ferma.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager { get; }
        IRepository<UsersProfiles> Users { get; }
        IRepositoryEntity<Farms> Farms { get; }
        IRepositoryEntity<Players> Players { get; }
        IRepositoryEntity<Buildings> Buildings { get; }
        IRepositoryEntity<Products> Products { get; }
        IRepositoryEntity<Stocks> Stocks { get; }
        IRepositoryEntity<Cells> Cells { get; }
        IRepositoryEntity<Fields> Fields { get; }
        IRepositoryEntity<TypeProducts> TypeProducts { get; }
        IRepositoryEntity<TypeBuildings> TypeBuildings { get; }
        void Save();
        void Dispose();
    }
}