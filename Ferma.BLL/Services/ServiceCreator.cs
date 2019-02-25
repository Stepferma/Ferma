using Ferma.BLL.Interfaces;
using Ferma.DAL.Repositories;

namespace Ferma.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserServiceAuth CreateUserService()
        {
            return new UserServiceAuth(new IdentityUnitOfWork());
        }
    }
}
