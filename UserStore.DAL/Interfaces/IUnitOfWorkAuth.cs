using UserStore.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace UserStore.DAL.Interfaces
{
    public interface IUnitOfWorkAuth : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
