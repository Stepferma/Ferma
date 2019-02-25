using Ferma.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace Ferma.DAL.Interfaces
{
    public interface IUnitOfWorkAuth : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
