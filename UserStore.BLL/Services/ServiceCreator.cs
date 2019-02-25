using UserStore.BLL.Interfaces;
using UserStore.DAL.Repositories;

namespace UserStore.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserServiceAuth CreateUserService()
        {
            return new UserServiceAuth(new IdentityUnitOfWork());
        }
    }
}
