using Ferma.DAL.Entities;
using Ferma.DAL.Identity;

namespace Ferma.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserManager UserManager { get; }
        IRepository<ClientProfile> ClientProfile { get; }     
        void Save();
        void Dispose();
    }
}