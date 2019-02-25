using UserStore.DAL.Entities;
using UserStore.DAL.Identity;

namespace UserStore.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager { get; }
        IRepository<ClientProfile> ClientProfile { get; }     
        void Save();
        void Dispose();
    }
}